using System.Diagnostics;
using AoCHelper;
using System.Drawing;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2022;

public class Day15 : BaseDay
{
    private readonly string _input;
    private readonly int _y;

    private readonly int _searchMax;

    public Day15()
    {
        _input = File.ReadAllText(InputFilePath);
        _y = 2000000;
        _searchMax = 4000000;
    }

    public Day15(string input, int y, int searchMax = 0)
    {
        _input = input;
        _y = y;
        _searchMax = searchMax;
    }

    public override ValueTask<string> Solve_1()
    {
        var sensors = new List<Sensor>();

        using var stringReader = new StringReader(_input);
        while (stringReader.ReadLine() is { } line)
        {
            var match = Regex.Match(line,
                "Sensor at x=(?<sensorX>-?\\d+), y=(?<sensorY>-?\\d+): closest beacon is at x=(?<beaconX>-?\\d+), y=(?<beaconY>-?\\d+)");
            var sensorPoint = new Point(int.Parse(match.Groups["sensorY"].Value), int.Parse(match.Groups["sensorX"].Value));
            var beaconPoint = new Point(int.Parse(match.Groups["beaconY"].Value), int.Parse(match.Groups["beaconX"].Value));
            var sensor = new Sensor(sensorPoint, beaconPoint);
            sensors.Add(sensor);
        }

        var allPoints = sensors.Select(x => x.sensor).Union(sensors.Select(x => x.beacon));

        var lineY = new Dictionary<long, char>();

        foreach (var sensor in sensors)
        {
            var sensorMinRow = sensor.sensor.X - sensor.ManhattenDistance;
            var sensorMaxRow = sensor.sensor.X + sensor.ManhattenDistance;

            if (_y >= sensorMinRow && _y <= sensorMaxRow)
            {
                long row = _y;
                var sensorMinColumn = sensor.sensor.Y - (sensor.ManhattenDistance - Math.Abs(sensor.sensor.X - row));
                var sensorMaxColumn = sensor.sensor.Y + (sensor.ManhattenDistance - Math.Abs(sensor.sensor.X - row));
                for (long column = sensorMinColumn; column <= sensorMaxColumn; column++)
                {
                    if (!allPoints.Any(point => point.X == row && point.Y == column))
                    {
                        if (!lineY.ContainsKey(column))
                        {
                            lineY[column] = '#';
                        }
                    }
                }
            }
        }

        return new ValueTask<string>(lineY.Count.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        var sensors = new List<Sensor>();

        using var stringReader = new StringReader(_input);
        while (stringReader.ReadLine() is { } line)
        {
            var match = Regex.Match(line,
                "Sensor at x=(?<sensorX>-?\\d+), y=(?<sensorY>-?\\d+): closest beacon is at x=(?<beaconX>-?\\d+), y=(?<beaconY>-?\\d+)");
            var sensorPoint = new Point(int.Parse(match.Groups["sensorY"].Value), int.Parse(match.Groups["sensorX"].Value));
            var beaconPoint = new Point(int.Parse(match.Groups["beaconY"].Value), int.Parse(match.Groups["beaconX"].Value));
            var sensor = new Sensor(sensorPoint, beaconPoint);
            sensors.Add(sensor);
        }

        Point? hiddenBeacon = null;

        for (int row = 0; row <= _searchMax; row++)
        {
            var sensorsForRow = sensors.Where(sensor => row >= sensor.SensorMinRow && row <= sensor.SensorMaxRow).ToList();
            foreach (var sensor in sensorsForRow)
            {
                var outsidePerimeterLeft = sensor.SensorMinColumn(row) - 1;
                var outsidePerimeterRight = sensor.SensorMaxColumn(row) + 1;

                var leftInsideAny = outsidePerimeterLeft < 0 || outsidePerimeterLeft > _searchMax;
                var rightInsideAny = outsidePerimeterRight < 0 || outsidePerimeterRight > _searchMax;
                foreach (var sensorCompare in sensorsForRow.Where(x => x != sensor))
                {
                    var sensorMinColumn = sensorCompare.SensorMinColumn(row);
                    var sensorMaxColumn = sensorCompare.SensorMaxColumn(row);
                    if (outsidePerimeterLeft >= sensorMinColumn && outsidePerimeterLeft <= sensorMaxColumn)
                    {
                        leftInsideAny = true;
                    }

                    if (outsidePerimeterRight >= sensorMinColumn && outsidePerimeterRight <= sensorMaxColumn)
                    {
                        rightInsideAny = true;
                    }

                    if (leftInsideAny && rightInsideAny)
                    {
                        break;
                    }
                }

                if (!leftInsideAny || !rightInsideAny)
                {
                    if (!leftInsideAny)
                    {
                        hiddenBeacon = new Point(row, outsidePerimeterLeft);
                    }
                    else if (!rightInsideAny)
                    {
                        hiddenBeacon = new Point(row, outsidePerimeterRight);
                    }
                    break;
                }
            }

            if (hiddenBeacon is not null)
            {
                break;
            }
        }

        // needs to be long; chonky number
        var tuningFrequency = (hiddenBeacon.Value.Y * 4000000l) + hiddenBeacon.Value.X;

        return new ValueTask<string>(tuningFrequency.ToString());
    }

    private void PrintAll(IEnumerable<Sensor> sensors)
    {
        var sb = new StringBuilder();
        for (int row = 0; row <= _searchMax; row++)
        {
            for (int column = 0; column <= _searchMax; column++)
            {
                if (sensors.Any(x => x.sensor.X == row && x.sensor.Y == column))
                {
                    sb.Append('S');
                }
                else if (sensors.Any(x => x.beacon.X == row && x.beacon.Y == column))
                {
                    sb.Append('B');
                }
                else if (sensors.Any(sensor => column >= sensor.SensorMinColumn(row) && column <= sensor.SensorMaxColumn(row)))
                {
                    sb.Append('#');
                }
                else
                {
                    sb.Append('.');
                }
            }

            sb.AppendLine();
        }

        sb.AppendLine();
        var str = sb.ToString();
        Debug.Write(str);
    }

    private void Print(Sensor sensor)
    {
        var sb = new StringBuilder();
        for (int row = 0; row <= _searchMax; row++)
        {
            var minColumn = sensor.SensorMinColumn(row);
            var maxColumn = sensor.SensorMaxColumn(row);
            for (int column = 0; column <= _searchMax; column++)
            {
                if (sensor.sensor.X == row && sensor.sensor.Y == column)
                {
                    sb.Append('S');
                }
                else if (sensor.beacon.X == row && sensor.beacon.Y == column)
                {
                    sb.Append('B');
                }
                else if (column >= minColumn && column <= maxColumn)
                {
                    sb.Append('#');
                }
                else
                {
                    sb.Append('.');
                }
            }

            sb.AppendLine();
        }

        sb.AppendLine();
        var str = sb.ToString();
        Debug.Write(str);
    }

    record Sensor(Point sensor, Point beacon)
    {
        public int ManhattenDistance => Math.Abs(sensor.X - beacon.X) + Math.Abs(sensor.Y - beacon.Y);

        public int SensorMinRow => sensor.X - ManhattenDistance;

        public int SensorMaxRow => sensor.X + ManhattenDistance;

        public int SensorMinColumn(int row)
            => sensor.Y - (ManhattenDistance - Math.Abs(sensor.X - row));

        public int SensorMaxColumn(int row)
            => sensor.Y + (ManhattenDistance - Math.Abs(sensor.X - row));
    }
}

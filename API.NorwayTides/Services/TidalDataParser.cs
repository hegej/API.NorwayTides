using API.NorwayTides.Models;
using System.Globalization;
using System.Linq.Expressions;

namespace API.NorwayTides.Services
{
    public class TidalDataParser
    {
        public List<TidalData> ParseTidalData(string rawData)
        {
            try{
                var lines = rawData.Split('\n');
                var tidalDataList = new List<TidalData>();

                foreach (var line in lines.Skip(9))
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    try
                    {
                        var parts = line.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (parts.Length < 13)
                        {
                            Console.WriteLine($"Warning: Line has insufficient data: {line}");
                            continue;
                        }

                        var tidalData = new TidalData
                        {
                            Year = int.Parse(parts[0]),
                            Month = int.Parse(parts[1]),
                            Day = int.Parse(parts[2]),
                            Hour = int.Parse(parts[3]),
                            PrognosisLength = int.Parse(parts[4]),
                            Surge = double.Parse(parts[5], CultureInfo.InvariantCulture),
                            Tide = double.Parse(parts[6], CultureInfo.InvariantCulture),
                            Total = double.Parse(parts[7], CultureInfo.InvariantCulture),
                            Percentile0 = double.Parse(parts[8], CultureInfo.InvariantCulture),
                            Percentile25 = double.Parse(parts[9], CultureInfo.InvariantCulture),
                            Percentile50 = double.Parse(parts[10], CultureInfo.InvariantCulture),
                            Percentile75 = double.Parse(parts[11], CultureInfo.InvariantCulture),
                            Percentile100 = double.Parse(parts[12], CultureInfo.InvariantCulture)
                        };

                        tidalDataList.Add(tidalData);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error parsing line: {line}");
                        Console.WriteLine($"Exception: {ex.GetType().Name}, Message: {ex.Message}");
                    }
                }

                Console.WriteLine($"Successfully parsed {tidalDataList.Count} tidal data points");

                return tidalDataList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in ParseTidal data: {ex}");
                throw;
            }
        }
    }
}


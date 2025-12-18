using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Linq;

public class UsdCourse
{
        public static float Current = 0;

        public async static Task<float> GetUsdCourseAsync()
        {
                using var wc = new HttpClient();
                var response = await wc.GetAsync("https://api.nbp.pl/api/exchangerates/tables/a/?format=xml");
                if (!response.IsSuccessStatusCode)
                        throw new InvalidOperationException("Nie udało się pobrać kursu USD.");

                var xml = await response.Content.ReadAsStringAsync();
                XDocument doc = XDocument.Parse(xml);
                        var midUsdValue = doc.Descendants("Rate")
                                .Where(rate => rate.Element("Code") != null && rate.Element("Code")!.Value == "USD")
                                .Select(rate => rate.Element("Mid")?.Value)
                                .FirstOrDefault();

                        if (string.IsNullOrWhiteSpace(midUsdValue))
                                throw new InvalidOperationException("Nie znaleziono kursu USD w odpowiedzi.");

                        return Convert.ToSingle(midUsdValue, System.Globalization.CultureInfo.InvariantCulture);
        }
}
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace WebApplication1.Services
{
    public class CountryNames
    {
        public List<string> countryNames;

        public List<string> CountryName { get { return countryNames = GetCountryNames(); } }
        public List<string> GetCountryNames()
        {
            countryNames = new List<string>();
            foreach (CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                var country = new RegionInfo(new CultureInfo(cul.Name, false).LCID);
                countryNames.Add(country.DisplayName.ToString());
            }

            return countryNames.OrderBy(c=>c.ElementAt(0)).ToList();
        }
    }
}
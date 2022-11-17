using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace paySite
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            countryList.DataSource = CountryList();
            countryList.DataBind();
        }

        public static List<string> CountryList()
        {
            List<string> countryList=new List<string>();
            CultureInfo[] getCultureInfos = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            foreach (CultureInfo itemInfo in getCultureInfos)
            {
                RegionInfo region=new RegionInfo(itemInfo.LCID);
                if (!(countryList.Contains(region.EnglishName)))
                {
                    countryList.Add(region.EnglishName);
                }
            }
            countryList.Sort();
            return countryList;
        }

    }
}
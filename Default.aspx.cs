using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Text;

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
      

        protected void alertBox(object sender, EventArgs e)
        {
          //  ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Insert is successfull')", true);
           StringBuilder sb=new StringBuilder();
           sb.Append("The details which sent are:\n");
           sb.Append(amountTxt.Text+ currencyTxt.Text+ " from cc:"+ cardNumber.Text+ "\t");
           detailsSent.InnerText = sb.ToString();
           Panel1.Visible = true;
           //creating get request and sent the details

           //show the response
        }
    }
}
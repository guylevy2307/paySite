using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace paySite
{
   
    public partial class _Default : Page
    {

       
        public class SignatureCreate
        {

            public static string GenerateSHA256(string value)
            {
                System.Security.Cryptography.SHA256 sh = System.Security.Cryptography.SHA256.Create();
                byte[] hashValue = sh.ComputeHash(System.Text.Encoding.UTF8.GetBytes(value));
                return HttpUtility.UrlEncode(System.Convert.ToBase64String(hashValue));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
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
                if (!(countryList.Contains(region.TwoLetterISORegionName)))
                {
                    countryList.Add(region.TwoLetterISORegionName);
                }
            }
            countryList.Sort();
            return countryList;
        }
      

        protected async void AlertBoxAsync(object sender, EventArgs e)
        {
          //  ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Insert is successfull')", true);
           StringBuilder sb=new StringBuilder();
           sb.Append("The details which sent are:\n");
           sb.Append(amountTxt.Text+ currencyTxt.Text+ " from cc:"+ cardNumber.Text+ "\t");
           detailsSent.InnerText = sb.ToString();
           Panel1.Visible = true;
            //creating get request and sent the details

            string merchantID = "3355796", transAmount = amountTxt.Text, transType="1", transCurrency= currencyTxt.Text;
            string  transInstallments = "1", PersonalHashKey = "7ZIQHB7YYN";

            string sendDetail = merchantID + transType + transInstallments + transAmount + transCurrency+ emailTxt.Text  + fullName.Text
                                + addressTxt.Text+zipTxt.Text+countryList.Text + PersonalHashKey;
         

            string sSig = SignatureCreate.GenerateSHA256(sendDetail);
            string src = "https://uiservices.coriunder.cloud/hosted/default.aspx?merchantId=" + merchantID + "&trans_type=" + transType +
                       "&trans_installments=" + transInstallments + "&trans_amount=" + transAmount + "&trans_currency=" +
                       transCurrency + "&client_email="+emailTxt.Text  + "&client_fullName="+ fullName.Text +
                       "&client_billAddress1=" + addressTxt.Text +"&client_billZipcode="+zipTxt.Text  + "&client_billCountry="+countryList.Text 
                       + "&signature=" + sSig;

            HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(src);
            webReq.Method = "GET";
            try
            {
                HttpWebResponse webRes = (HttpWebResponse)webReq.GetResponse();
                StreamReader sr = new StreamReader(webRes.GetResponseStream());
                pnlUserdata.Controls.Add(new LiteralControl(sr.ReadToEnd()));

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            //show the response
        }

    }
}
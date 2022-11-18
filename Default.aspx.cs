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
                return System.Convert.ToBase64String(hashValue);
            }
        }
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
      

        protected async void AlertBoxAsync(object sender, EventArgs e)
        {
          //  ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Insert is successfull')", true);
           StringBuilder sb=new StringBuilder();
           sb.Append("The details which sent are:\n");
           sb.Append(amountTxt.Text+ currencyTxt.Text+ " from cc:"+ cardNumber.Text+ "\t");
           detailsSent.InnerText = sb.ToString();
           Panel1.Visible = true;
            //creating get request and sent the details

            string merchantID = "3355796", trans_amount = amountTxt.Text, trans_type="1", TypeCredit = "1", trans_currency= currencyTxt.Text;
            string CardNum = cardNumber.Text, trans_installments="1",RefTransID = "", PersonalHashKey = "7ZIQHB7YYN";
            string sendDetail = merchantID + 0 + trans_installments + trans_amount + trans_currency + PersonalHashKey;
            string sSig = SignatureCreate.GenerateSHA256(sendDetail);
            string src = "https://uiservices.coriunder.cloud/hosted/default.aspx?merchantId=" + merchantID + "&trans_type=" + 1 + "&trans_comment="  +
                         "&trans_refNum="  + "&trans_installments=" + trans_installments + "&trans_amount=" + trans_amount + "&trans_currency=" +
                         trans_currency + "&disp_payFor="  + "&client_email="  + "&client_fullName="  + "&client_phoneNum=" + "&client_billAddress1="  + "&client_billAddress2="  +
                         "&client_billCity="  + "&client_billZipcode="  + "&client_billState=" +
                         "&client_billCountry="  + "&PLID="  + "&trans_storePm="  + "&disp_lng=" +
                         "&ui_version="  + "&Brand="  + "&url_redirect="  +
                         "& notification_url=" + "&hashtype="  + "&signature=" + sSig;

            HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(src);
            webReq.Method = "GET";
            try
            {
                HttpWebResponse webRes = (HttpWebResponse)webReq.GetResponse();
                StreamReader sr = new StreamReader(webRes.GetResponseStream());
                String resStr = sr.ReadToEnd();
                Response.Write("Response String: " + resStr + "<br />");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            //show the response
        }

    }
}
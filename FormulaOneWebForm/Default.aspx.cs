using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FormulaOneDLL;

namespace FormulaOneWebForm
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // Inizializzazioni che vengono eseguite solo la prima volta
                lblMessaggio.Text = "Selezionare una voce dalla lista";
                List<string> Tablenames = DbTools.GetTables();
                DropDownList1.DataSource = Tablenames;
                DropDownList1.DataBind();
                GetCountry();
            }
            else
            {
                //Elaborazioni da eseguire tutte le volte che la pagina viene caricata
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DbTools dbt = new DbTools();
            GridViewTable.DataSource = dbt.GetData(DropDownList1.SelectedValue);
            GridViewTable.DataBind();
        }

        private void GetCountry(string isoCode="")
        {
            HttpWebRequest apiRequest = WebRequest.Create("https://localhost:5001/api/country" + isoCode+"") as HttpWebRequest;
            string apiResponse = "";

            try
            {
                using(HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    apiResponse = reader.ReadToEnd();
                    Country[] oCountry = Newtonsoft.Json.JsonConvert.DeserializeObject<Country[]>(apiResponse);
                    lbxNazioni.DataSource = oCountry;
                    lbxNazioni.DataBind();
                    lbxNazioni.Visible = true;
                }
            }
            catch (System.Net.WebException ex)
            {
                Console.Write(ex.Message);
            }
        }
    }
}
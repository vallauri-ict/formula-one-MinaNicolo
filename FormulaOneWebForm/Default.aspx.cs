using System;
using System.Collections.Generic;
using System.Linq;
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
            }
            else
            {
                //Elaborazioni da eseguire tutte le volte che la pagina viene caricata
            }
        }

        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            DbTools dbt = new DbTools();
            GridViewTable.DataSource = dbt.GetData(DropDownList1.SelectedValue);
            GridViewTable.DataBind();
        }
    }
}
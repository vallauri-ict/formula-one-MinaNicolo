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
                List<string> names = DbTools.GetTables();
                DropDownList1.DataSource = names;
                DropDownList1.DataBind();
                DropDownList1.Text = "";
            }
            else
            {
                //Elaborazioni da eseguire tutte le volte che la pagina viene caricata
            }
        }

        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            DbTools dbt = new DbTools();
            switch (DropDownList1.SelectedValue)
            {
                case "Countries":
                    {
                        GridViewTable.DataSource = dbt.GetData("Countries");
                        GridViewTable.DataBind();
                        break;
                    }
                case "Team":
                    {
                        GridViewTable.DataSource = dbt.GetData("Team");
                        GridViewTable.DataBind();
                        break;
                    }
                case "Driver":
                    {
                        GridViewTable.DataSource = dbt.GetData("Driver");
                        GridViewTable.DataBind();
                        break;
                    }
            }
        }
    }
}
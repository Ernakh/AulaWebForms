using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AulaWebForms
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ViewState["btnDinamico"] != null)
            {
                if ((bool)ViewState["btnDinamico"] == true)
                {
                    Button1_Click(null, null);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Banco bd = new Banco();

            string sql = "select * from pessoa";

            DataTable dt = new DataTable();
            dt = bd.executarConsultaGenerica(sql);

            GridView1.DataSource = dt;
            GridView1.DataBind();


            //*******************

            Button btn = new Button();
            btn.Text = "botão dinamico";

            btn.Click += Btn_Click;

            ViewState["btnDinamico"] = true;

            PlaceHolder1.Controls.Add(btn);
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            ViewState["label"] = textBox.Text;
            label.Text = ViewState["label"].ToString();
        }

        [WebMethod]
        public static string alerta1()
        {
            return "webservice 1";
        }

        [WebMethod]
        public static string alerta2(int valor)
        {
            return (valor * 2).ToString();
        }


        protected void btnAlert_Click(object sender, EventArgs e)
        {
            Literal1.Text = "<script>alert('" + textBox.Text + "');</script>";
        }

      
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppCalculadora_2
{
    public partial class SiteMaster : MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void limpar_Click(object sender, EventArgs e)
        {
            lblInput.Text = string.Empty;
            lblInput.ForeColor = Color.Black;
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            Button invokeBtn = sender as Button;
            if (invokeBtn != null)
            {
                lblInput.Text += invokeBtn.Text;
            }
        }

        protected void btn_calcular(object sender, EventArgs e)
        {
            string expressao = lblInput.Text;
            var resultado = new DataTable();

            try
            {
                double validarResultado = Convert.ToDouble(resultado.Compute(expressao, null));
                if (double.IsInfinity(validarResultado) || double.IsNaN(validarResultado))
                {
                    lblInput.Text = "Expressão não foi validada! Erro de sintaxe";
                    lblInput.ForeColor = Color.Red;
                    return;
                }
                
                lblInput.Text = validarResultado.ToString();
                lblInput.ForeColor = Color.Black;
            }
            
            catch (System.Data.SyntaxErrorException)
            {
                lblInput.Text = "Expressão não foi validada! Erro de sintaxe";
                lblInput.ForeColor = Color.Red;
            }
        }
    }
}


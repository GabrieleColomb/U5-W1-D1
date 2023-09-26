using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace U5_W1_D1
{
    public partial class Pagamenti : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateEmployeeList();
            }
        }

        protected void PopulateEmployeeList()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT idDipendente, Nome + ' ' + Cognome AS NomeCompleto FROM Dipendenti";
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader reader = command.ExecuteReader();

                ddlDipendente.Items.Add(new ListItem("Seleziona un dipendente", ""));

                while (reader.Read())
                {
                    string idDipendente = reader["idDipendente"].ToString();
                    string nomeCompleto = reader["NomeCompleto"].ToString();
                    ddlDipendente.Items.Add(new ListItem(nomeCompleto, idDipendente));
                }

                reader.Close();
            }
        }

        protected void btnSalvaPagamento_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                int idDipendente = Convert.ToInt32(ddlDipendente.SelectedValue);
                DateTime periodoPagamento = DateTime.Parse(txtPeriodoPagamento.Text);
                decimal ammontarePagamento = Convert.ToDecimal(txtAmmontarePagamento.Text);
                string tipoPagamento = ddlTipoPagamento.SelectedValue;

                string queryInserimentoPagamento = "INSERT INTO Pagamenti (idDipendente, PeriodoPagamento, Ammontare, TipoPagamento) " +
                                           "VALUES (@idDipendente, @PeriodoPagamento, @Ammontare, @TipoPagamento)";

                SqlCommand commandInserimentoPagamento = new SqlCommand(queryInserimentoPagamento, conn);
                commandInserimentoPagamento.Parameters.AddWithValue("@idDipendente", idDipendente);
                commandInserimentoPagamento.Parameters.AddWithValue("@PeriodoPagamento", periodoPagamento);
                commandInserimentoPagamento.Parameters.AddWithValue("@Ammontare", ammontarePagamento);
                commandInserimentoPagamento.Parameters.AddWithValue("@TipoPagamento", tipoPagamento);

                commandInserimentoPagamento.ExecuteNonQuery();

                conn.Close();

                Response.Redirect("Default.aspx");
            }
        }
    }
}
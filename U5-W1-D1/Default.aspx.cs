using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace U5_W1_D1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateEmployeeGrid();
                PopulatePaymentsGrid();
            }
        }

        private void PopulateEmployeeGrid()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT idDipendente, Nome, Cognome, Indirizzo, CodiceFiscale, Mansione FROM Dipendenti";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        private void PopulatePaymentsGrid()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT idPagamenti, idDipendente, PeriodoPagamento, Ammontare, TipoPagamento FROM Pagamenti";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                GridView2.DataSource = dt;
                GridView2.DataBind();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idDipendente = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["idDipendente"]);
            bool success = DeleteEmployee(idDipendente);

            if (success)
            {
                lblErrorMessage.Text = string.Empty;
                PopulateEmployeeGrid();
            }
            else
            {
                lblErrorMessage.Text = "Errore durante l'eliminazione del dipendente.";
            }
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idPagamento = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Values["idPagamenti"]);
            bool success = DeletePayment(idPagamento);

            if (success)
            {
                lblErrorMessage.Text = string.Empty;
                PopulatePaymentsGrid();
            }
            else
            {
                lblErrorMessage.Text = "Errore durante l'eliminazione del pagamento.";
            }
        }

        private bool DeleteEmployee(int idDipendente)
         { 
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "DELETE FROM Dipendenti WHERE idDipendente = @idDipendente";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@idDipendente", idDipendente);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool DeletePayment(int idPagamento)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "DELETE FROM Pagamenti WHERE idPagamenti = @idPagamenti";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@idPagamenti", idPagamento);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
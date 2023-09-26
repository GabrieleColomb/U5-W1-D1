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
    public partial class AggiungiDipendenti : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSalvaDipendete_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string nome = txtNome.Text;
                    string cognome = txtCognome.Text;
                    string indirizzo = txtIndirizzo.Text;
                    string codiceFiscale = txtCodiceFiscale.Text;
                    bool coniugato = chkConiugato.Checked;
                    int numeroFigli = string.IsNullOrEmpty(txtFigli.Text) ? 0 : Convert.ToInt32(txtFigli.Text);
                    string mansione = ddlMansione.SelectedValue;

                    string query = "INSERT INTO Dipendenti (Nome, Cognome, Indirizzo, CodiceFiscale, Coniugato, NumeroFigli, Mansione)" +
                        "VALUES (@Nome, @Cognome, @Indirizzo, @CodiceFiscale, @Coniugato, @NumeroFigli, @Mansione)";

                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@Cognome", cognome);
                    command.Parameters.AddWithValue("@Indirizzo", indirizzo);
                    command.Parameters.AddWithValue("@CodiceFiscale", codiceFiscale);
                    command.Parameters.AddWithValue("@Coniugato", coniugato);
                    command.Parameters.AddWithValue("@NumeroFigli", numeroFigli);
                    command.Parameters.AddWithValue("@Mansione", mansione);

                    command.ExecuteNonQuery();
                }

                catch (Exception ex)
                {
                    Response.Write("Si è verificato un errore durante l'inserimento del dipendente: " + ex.Message);
                }
            }
        }
    }
}
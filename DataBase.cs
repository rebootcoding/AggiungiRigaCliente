using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AggiungiRigaCliente
{
    public class DataBase
    {
        private SqlConnectionStringBuilder connectionStringBuilder
        {
            get
            {
                var builder = new SqlConnectionStringBuilder();
                builder.DataSource = "WINAPHS2OH2TH8K\\SQLEXPRESS";
                builder.InitialCatalog = "AcademyNet";
                builder.IntegratedSecurity = true; //unione tra sistemi diversi, aumenta livello di sicurezza integrato, APPROFONDIRE
                return builder;
            }
        }
        private SqlConnection GetConnection()
        {
            return new SqlConnection(connectionStringBuilder.ConnectionString);
        }

        public DataTable GetListaClienti()
        {
            using (var conn = GetConnection())
            {
                var command = new SqlCommand();
                command.CommandText = $"SELECT * " + "FROM sales.customers c";
                command.Connection = conn;

                try
                {
                    conn.Open();
                    var reader = command.ExecuteReader();
                    var dt = new DataTable();
                    dt.Load(reader);
                    reader.Close();
                    return dt;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public DataTable UpdateListaClienti()
        {
            using (var conn = GetConnection())
            {
                var command = new SqlCommand();
                command.CommandText = $"SELECT * "+"FROM sales.customers c "+"ORDER BY c.customer_id DESC";
                command.Connection = conn;

                try
                {
                    conn.Open();
                    var reader = command.ExecuteReader();
                    var dt = new DataTable();
                    dt.Load(reader);
                    reader.Close();
                    return dt;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public void InsertNewCustomer(string nome, string cognome, string email, string telefono, string indirizzo, string città, string stato, string cap)
        {
            using (var conn = GetConnection())
            {
                var command = new SqlCommand();
                command.CommandText = $"INSERT INTO sales.customers (first_name, last_name, phone, email, street, city, state, zip_code) " + "VALUES ('" + nome + "','" + cognome + "','" + telefono + "','" + email + "','" + indirizzo + "','" + città + "','" + stato + "','" + cap + "')";
                command.Connection = conn;
                try
                {
                    conn.Open();
                    var writer = command.ExecuteNonQuery();
                    MessageBox.Show("Hai inserito un nuovo cliente!");
                    // la connessione si chiude in automatico dato USING ?
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}

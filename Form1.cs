using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AggiungiRigaCliente
{
    public partial class Form1 : Form
    {
        public DataBase db;
        public Form1()
        {
            InitializeComponent();
            db = new DataBase();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var conn = new SqlConnection())
            {
                var rows = db.GetListaClienti().DefaultView;
                dgr_lista_clienti.DataSource = rows;
            }
        }

        private void btn_nuovo_cliente_Click(object sender, EventArgs e)
        {
            var nome = tbx_nome.Text;
            var cognome = tbx_cognome.Text;
            var città = tbx_città.Text;
            var stato = tbx_stato.Text;
            var email = tbx_email.Text;
            var telefono = tbx_telefono.Text;
            var cap = tbx_cap.Text;
            var indirizzo = tbx_Indirizzo.Text;

            db.InsertNewCustomer(nome, cognome, email, telefono, indirizzo, città, stato, cap);
        }

        private void btn_carica_lista_Click(object sender, EventArgs e)
        {
            using (var conn = new SqlConnection())
            {
                var rows = db.UpdateListaClienti().DefaultView;
                dgr_lista_clienti.DataSource = rows;
            }
        }
    }
}

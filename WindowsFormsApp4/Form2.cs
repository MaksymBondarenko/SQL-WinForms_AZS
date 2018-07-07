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

namespace WindowsFormsApp4
{
    public partial class AZS : Form
    {
        SqlDataReader reader = null;
        SqlConnection connection = null;
        String connectionString = @"Data Source=МАКСИМ-ПК\SQLEXPRESS; Initial Catalog=PetrolStation; Integrated Security=true;";
        public AZS()
        {

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("insert into AZS values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", connection);
            command.Parameters.AddWithValue("@p1",textBox1.Text);
            command.Parameters.AddWithValue("@p2", textBox2.Text);
            command.Parameters.AddWithValue("@p3", Convert.ToDouble(textBox3.Text));
            command.Parameters.AddWithValue("@p4", Convert.ToDouble(textBox4.Text));
            command.Parameters.AddWithValue("@p5", Convert.ToDouble(textBox5.Text));
            command.Parameters.AddWithValue("@p6", Convert.ToDouble(textBox6.Text));
            command.Parameters.AddWithValue("@p7", Convert.ToDouble(textBox7.Text));
            command.Parameters.AddWithValue("@p8", Convert.ToDouble(textBox8.Text));
            command.ExecuteNonQuery();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

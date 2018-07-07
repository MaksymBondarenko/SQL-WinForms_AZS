﻿using System;
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

    public partial class Employe : Form
    {
        SqlDataReader reader = null;
        SqlConnection connection = null;
        String connectionString = @"Data Source=МАКСИМ-ПК\SQLEXPRESS; Initial Catalog=PetrolStation; Integrated Security=true;";
        public Employe()
        {
            InitializeComponent();
            initializeAZS();
        }
        private void initializeAZS()
        {
            List<string> lists = new List<string>();
            connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select * from AZS", connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    lists.Add($"{reader[1]}");
                }
                comboBox1.DataSource = null;
                comboBox1.DataSource = lists;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
                reader.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("insert into Employees values (@p1,@p2,@p3,@p4,@p5)", connection);
            command.Parameters.AddWithValue("@p1", textBox1.Text);
            command.Parameters.AddWithValue("@p2", textBox2.Text);
            command.Parameters.AddWithValue("@p3", textBox3.Text);
            command.Parameters.AddWithValue("@p4", dateTimePicker1.Value.ToString());
            command.Parameters.AddWithValue("@p5", (comboBox1.SelectedIndex)+1);
            command.ExecuteNonQuery();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

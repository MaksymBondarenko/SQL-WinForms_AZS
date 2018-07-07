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
    public partial class Form1 : Form
    {
        AZS F2;
        Employe F3;
        Product F4;
        Password F5;
        SqlDataReader reader = null;
        SqlConnection connection = null;
        ToolTip toolTip1 = new ToolTip();
        
        String connectionString = @"Data Source=МАКСИМ-ПК\SQLEXPRESS; Initial Catalog=PetrolStation; Integrated Security=true;";
        public Form1()
        {
            F2 = new AZS();
            F3 = new Employe();
            F4 = new Product ();
          
            InitializeComponent();
            initializeAZS();
            initializeProducts();
            initializeEmployees();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            toolTip1.SetToolTip(this.button5, "2222");
            toolTip1.SetToolTip(this.button4, "1111");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox5.Enabled = false;

            label1.Enabled = false;
            label2.Enabled = false;
            label3.Enabled = false;
            label4.Enabled = false;
            label5.Enabled = false;
            label6.Enabled = false;
            label7.Enabled = false;
            label8.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            ADD_AZS.Enabled = false;
            ADD_Employe.Enabled = false;
            ADD_Product.Enabled = false;
            button6.Enabled = false;

            label4.Enabled = false;
            label5.Enabled = false;
            label6.Enabled = false;
            label7.Enabled = false;
            textBox4.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";

        }

        //инициализация AZS
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
        
        //инициализация Products
        private void initializeProducts()
        {
            List<string> lists = new List<string>();
            connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(" select distinct (Products.ProductName) from Products", connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    lists.Add($"{reader[0]}");
                }
                comboBox2.DataSource = null;
                comboBox2.DataSource = lists;
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

        //инициализация Products
        private void initializeEmployees()
        {
            List<string> lists = new List<string>();
            connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(" select * from Employees", connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    lists.Add($"{reader[1]} {reader[2]}");
                }
                comboBox3.DataSource = null;
                comboBox3.DataSource = lists;
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

        //режим управляющего
        private void button4_Click(object sender, EventArgs e)
        {
           
            bool pas = false;
            F5 = new Password(pas);
            if (F5.ShowDialog() == DialogResult.OK)
            {
                label4.Enabled = false;
                label5.Enabled = false;
                label6.Enabled = false;
                label7.Enabled = false;
                label8.Enabled = false;
                textBox4.Enabled = false;
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                comboBox3.Enabled = false;
                button6.Enabled = false;

                label1.Enabled = true;
                label2.Enabled = true;
                label3.Enabled = true;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                ADD_AZS.Enabled = true;
                ADD_Employe.Enabled = true;
                ADD_Product.Enabled = true;

                comboBox1.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
            }
          
        }

        //режим оператора
        private void button5_Click(object sender, EventArgs e)
        {
           
            bool pas = true;
            F5 = new Password(pas);
            if (F5.ShowDialog() == DialogResult.OK)
            {
                label1.Enabled = false;
                label2.Enabled = false;
                label3.Enabled = false;
                label4.Enabled = false;
                label5.Enabled = false;
                label6.Enabled = false;
                label7.Enabled = false;
                label8.Enabled = true;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                ADD_AZS.Enabled = false;
                ADD_Employe.Enabled = false;
                ADD_Product.Enabled = false;

                label4.Enabled = true;
                label5.Enabled = true;
                label6.Enabled = true;
                label7.Enabled = true;
                textBox4.Enabled = true;
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                button6.Enabled = true;

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
        }

        //печать чека
        private void button6_Click(object sender, EventArgs e)
        {
            string AZS = comboBox1.Text;
            string ProductName = comboBox2.Text;

            if (comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Одно из полей не заполнено!");
            }
            else
            {
                textBox5.Text += ("АЗС: " + comboBox1.Text + " || " +
                        "Топливо: " + comboBox2.Text + " || " +
                        "Заправщик: " + comboBox3.Text + " || " +
                        "Количество: " + textBox4.Text + " || ");

              connection = new SqlConnection(connectionString);
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("select distinct Orders.ProductPrice from Orders, AZS, Products where Orders.id = AZS.id and AZS.AZSName = '"+AZS+"' and Products.ProductName ='"+ProductName+"' ", connection);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        textBox5.Text += ("Цена: " + " "+ $"{reader[0]}" + " || " + "Стоимость: " + (Convert.ToDouble(textBox4.Text)*Convert.ToDouble($"{reader[0]}"))+ Environment.NewLine);            
                    }
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
        }

        private void ADD_AZS_Click(object sender, EventArgs e)
        {
            if (F2.ShowDialog() == DialogResult.OK)
            {
                initializeAZS();
            }
        }

        private void ADD_Employe_Click(object sender, EventArgs e)
        {
            if (F3.ShowDialog() == DialogResult.OK)
            {
                initializeEmployees();
            }
        }

        private void ADD_Product_Click(object sender, EventArgs e)
        {
            if (F4.ShowDialog() == DialogResult.OK)
            {
                initializeProducts();
            }
        }
    }
}

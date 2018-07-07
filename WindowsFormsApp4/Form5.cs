using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Password : Form
    {
        bool pas;     
        public Password(bool pas)
        {
            this.pas = pas;
            InitializeComponent();
        }
        private void Password_Input_Click(object sender, EventArgs e)
        {
            if (pas == false)
            {
                string Password = "1111";
                if (Password == textBox1.Text)
                {
                    MessageBox.Show("Пароль введен верно");
                    textBox1.Text = "";
                    this.DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Пароль введен неправильно. Повторите ввод!");
                    textBox1.Text = "";
                }
            }
            else if (pas == true)
            {
                string Password_oper = "2222";
                if (Password_oper == textBox1.Text)
                {
                    MessageBox.Show("Пароль введен верно");
                    textBox1.Text = "";
                    this.DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Пароль введен неправильно. Повторите ввод!");
                    textBox1.Text = "";
                }

            }
           
        }
    }
}

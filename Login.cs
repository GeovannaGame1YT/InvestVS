using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invest_VS
{
    public partial class Login : Form
    {
        static public string usernow;
        Banco _banco = new Banco();
        public Login()
        {
            InitializeComponent();
            
        }

        private void btnSing_Click(object sender, EventArgs e)
        {
            Form TelaCadastro = new SingUp();
            TelaCadastro.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var Logado = _banco.Login(txtUser.Text,txtPassword.Text);
            if (Logado == true)
            {
                this.Hide();
                usernow = txtUser.Text;
                Form Main = new Main();
                Main.Show();
            }
            else
            {
                usernow = null;
            }
           
            
            
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2CircleButton1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

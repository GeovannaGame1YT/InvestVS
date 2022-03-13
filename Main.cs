using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invest_VS
{
    public partial class Main : Form
    {
        public static CTRLancamento telaLancamentoCtrl = new CTRLancamento();
        
        public static Resumo telaResumo = new Resumo();
        
        public Main()
        {
            InitializeComponent();
            AbrirTelaResumo();   
        }
        public Resumo AbrirTelaResumo()
        {

            telaResumo.Parent = pnlMain;
            telaResumo.Dock = DockStyle.Fill;
            telaResumo.Show();
            return telaResumo;   
        }

        public CTRLancamento AbrirTelaLancamento()
        {
            telaLancamentoCtrl.Parent = pnlMain;
            telaLancamentoCtrl.Dock = DockStyle.Fill;          
            telaLancamentoCtrl.Show();
            return telaLancamentoCtrl;
        }

        private void MoveImageBox(object sender)
        {
            Guna2Button b = (Guna2Button)sender;
            imgSlide.Location = new Point(b.Location.X + 181, b.Location.Y - 33);
            imgSlide.SendToBack();
        }

        private void Guna2Button1_CheckedChanged(object sender, EventArgs e)
        {
            MoveImageBox(sender);
        }

        private void BtnResumo_Click(object sender, EventArgs e)
        {
            telaResumo.AtualizaGrafico();
            telaLancamentoCtrl.Hide();
            AbrirTelaResumo();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnLancamento_Click(object sender, EventArgs e)
        {
            telaLancamentoCtrl.AtualizarTabela();
            telaResumo.Hide();
            AbrirTelaLancamento();
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Invest_VS.Modelos;

namespace Invest_VS
{
    public partial class CTRLancamento : UserControl
    {
        Lancamento lancamento = new Lancamento();
        UPDLancamento telaLancamento = new UPDLancamento();
        UPDLancamento alterTelaLancamento = new UPDLancamento();
        static Banco _banco = new Banco();
        public CTRLancamento()
        {
            InitializeComponent();
            AtualizarTabela();
        }

        public void AtualizarTabela()
        {
            String query = "select id_lancamento, Sigla, tipo as Evento, Data_movimento as Data, Quantidade, Valor, acrescimos as Despesas, cast(((Quantidade * Valor) + acrescimos) as decimal(10,2)) as Total  from lancamento where usuario = " + Login.usernow;
            dtgLaunch.DataSource = _banco.ExecutarQueryRetorna(query);
        }


        public UPDLancamento AbrirTelaLancamentoUPD(Lancamento lancamento)
        {
            this.Hide();
            alterTelaLancamento.Parent = Main.pnlMain;
            alterTelaLancamento.Dock = DockStyle.Fill;
            alterTelaLancamento.CUPDLancamento(lancamento);
            alterTelaLancamento.Show();
            return telaLancamento;
        }

        public UPDLancamento AbrirTelaLancamentoUPD()
        {
            this.Hide();
            telaLancamento.Parent = Main.pnlMain;
            telaLancamento.Dock = DockStyle.Fill;
            telaLancamento.Show();
            return telaLancamento;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                AbrirTelaLancamentoUPD();
            }
            catch
            {
                MessageBox.Show("Houve um erro, favor tentar novamente, caso persistir chame o administrador.");
            }
        }

        private void dtgLaunch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult confirm = MessageBox.Show("Deseja realmente excluir o lançamento?", "Confirmação do usuário", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                if (confirm.ToString().ToUpper() == "YES")
                {

                    _banco.ExecutarQuery("DELETE FROM lancamento WHERE id_lancamento = " + dtgLaunch.CurrentRow.Cells[0].Value);
                    MessageBox.Show("Lançamento foi excluido com sucesso!");
                    AtualizarTabela();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
                throw new Exception();
            }
        }

        private void btnAlter_Click(object sender, EventArgs e)
        {
            try
            {

                var query = _banco.CommandRow("SELECT sigla, tipo, valor, data_movimento, acrescimos, quantidade from lancamento WHERE id_lancamento = " + dtgLaunch.CurrentRow.Cells[0].Value);
                Lancamento lancamento = new Lancamento
                {
                    Sigla = query["sigla"].ToString(),
                    Tipo = query["tipo"].ToString(),
                    Valor = Convert.ToDecimal(query["valor"]),
                    Data_movimento = Convert.ToDateTime(query["data_movimento"]),
                    Acrescimos = Convert.ToDecimal(query["acrescimos"]),
                    Quantidade = Convert.ToInt32(query["quantidade"]),
                };

                AbrirTelaLancamentoUPD(lancamento);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
    }
}

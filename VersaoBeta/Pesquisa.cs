using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using VersaoBeta.classe;


namespace VersaoBeta
{
    public partial class Pesquisa : Form
    {
        public Pesquisa()
        {
            InitializeComponent();
        }

        private void Pesquisar_Click(object sender, EventArgs e)
        {

        }

        private void txtPesquisar_Click(object sender, EventArgs e)
        {
            if (rdCodigo.Checked == true)
            {

                Conexao cnn = new Conexao();
                MySqlCommand  com = new MySqlCommand();
                com.Connection = cnn.AbreConexao();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "sp_BuscaCodigo";

                com.Parameters.AddWithValue("_codigo", txtPesquisa.Text);
              MySqlDataAdapter  da = new MySqlDataAdapter(com);
                DataTable dtlista = new DataTable();
                //caminho.AbreConexao();
                da.Fill(dtlista);
            dgDados.DataSource = dtlista;

            }
            if (rdNome.Checked == true)
            {

                               
                Conexao cnn = new Conexao();
                // usando a variavel de com
                MySqlCommand com = new MySqlCommand();
                com.Connection = cnn.AbreConexao();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "sp_listar";


                com.Parameters.AddWithValue("_nome", txtPesquisa.Text);
                MySqlDataAdapter da = new MySqlDataAdapter(com);
                DataTable dtlista = new DataTable();
                //caminho.AbreConexao();
                da.Fill(dtlista);
                dgDados.DataSource = dtlista;

            }



        }

        private void dgDados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Hide();
            frmCliente cli = new frmCliente();

            frmCliente.objCodigo.Text = dgDados.CurrentRow.Cells["tb_cli_codigo"].Value.ToString();
            frmCliente.objNome.Text = dgDados.CurrentRow.Cells["tb_cli_Nome"].Value.ToString();
            frmCliente.objCep.Text = dgDados.CurrentRow.Cells["tb_cli_Cep"].Value.ToString();
            frmCliente.objEndereco.Text = dgDados.CurrentRow.Cells["tb_cli_Endereco"].Value.ToString();
            frmCliente.objCidade.Text = dgDados.CurrentRow.Cells["tb_cli_Cidade"].Value.ToString();
            frmCliente.objBairro.Text = dgDados.CurrentRow.Cells["tb_cli_Bairro"].Value.ToString();
            frmCliente.objUF.Text = dgDados.CurrentRow.Cells["tb_cli_Estado"].Value.ToString();

            cli.ShowDialog();
        }
    }
}

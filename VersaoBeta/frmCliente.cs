using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VersaoBeta.classe;

namespace VersaoBeta
{
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
            objCodigo = txtCodigo;
            objNome = txtNome;
            objCep = txtCep;
            objEndereco = txtEnd;
            objBairro = txtBairro;
            objCidade = txtCidade;
            objUF = txtUF;
            //objXX = textBox1;

        }
        // acessando os atributos
        public static TextBox objCodigo { get; set; }
        public static TextBox objNome { get; set; }
        public static MaskedTextBox objCep { get; set; }
        public static TextBox objEndereco { get; set; }
        public static TextBox objBairro { get; set; }
        public static TextBox objCidade { get; set; }
        public static TextBox objUF { get; set; }
        public static TextBox objXX { get; set; }


    

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
           Cliente us = new Cliente(txtNome.Text,txtCep.Text,txtEnd.Text,txtCidade.Text,txtBairro.Text,txtUF.Text);
            us.InserirCliente();
            //retornado o codigo para caixa de texto
            txtCodigo.Text = Convert.ToString(us.idRetorno);
            //caixa de mensagem
            MessageBox.Show("Código gerado " +us.idRetorno, "Cadastro",
                             MessageBoxButtons.OK, MessageBoxIcon.Information);
            //chamar a rotina limpar
           
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            Pesquisa pesq = new Pesquisa();
            pesq.ShowDialog();
        }
    }
}

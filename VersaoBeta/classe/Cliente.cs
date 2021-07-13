using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using VersaoBeta.classe;

namespace VersaoBeta.classe
{
    public class Cliente
    {
        public string mensagem;
        public int idRetorno;
        public int Id=0;

        public int ID { get; set; }
        public string Nome{ get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Uf { get; set; }

        public Cliente() { }

        public Cliente(string nome,string cep,string endereco,string cidade,string bairro,string uf )
        {
            this.Nome = nome;
            this.Cep = cep;
            this.Endereco = endereco;
            this.Cidade = cidade;
            this.Bairro = bairro;
            this.Uf = uf;
        }

        public Cliente(int id,string nome, string cep, string endereco, string cidade, string bairro, string uf)
        {
            this.ID = id;
            this.Nome = nome;
            this.Cep = cep;
            this.Endereco = endereco;
            this.Cidade = cidade;
            this.Bairro = bairro;
            this.Uf = uf;
        }


        public void InserirCliente()
        {
            try
            {

              
                Conexao cnn = new Conexao();
              
            MySqlCommand com = new MySqlCommand();
                com.Connection =cnn.AbreConexao() ;
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.CommandText = "sp_Inserir";

                // passando os parametros de entrada
                com.Parameters.AddWithValue("_Codigo", 0);
                com.Parameters.AddWithValue("_nome",Nome);
                com.Parameters.AddWithValue("_cep", Cep);
                com.Parameters.AddWithValue("_endereco", Endereco);
                com.Parameters.AddWithValue("_bairro", Bairro);
                com.Parameters.AddWithValue("_cidade", Cidade);
                com.Parameters.AddWithValue("_estado", Uf);
                              //executa a gravacao no banco
                com.ExecuteNonQuery();

                com = new MySqlCommand("select MAX(tb_cli_codigo) FROM TB_CLIENTES", cnn.AbreConexao());

               idRetorno = (int)com.ExecuteScalar();


                mensagem = "Cliente catalogado com sucesso!";
                //fecha a conexao
             //   cnn.FechaConexao();

            }
            catch (Exception ex)
            {
                mensagem = ex.Message;

            }

        }

    }
}

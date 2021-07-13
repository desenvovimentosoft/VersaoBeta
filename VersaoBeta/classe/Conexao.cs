using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace VersaoBeta.classe
{
  public  class Conexao
    {

        //criar algumas variaveis
        //strConexaoSQL, vnome da variavel
        static string strConexaoSQL = @"server=localhost;database=DBCadastro;user id=root;password=usbw";

        //variavel de conexao
        MySqlConnection cnn = new MySqlConnection(strConexaoSQL);
        
        //variavel de leitura
        public MySqlDataReader dr;


        //abrir a conexao
        public MySqlConnection AbreConexao()
        {   //State, estado
            //Closed, fechado
            if (cnn.State ==  System.Data.ConnectionState.Closed)
            {
                cnn.Open();
                return cnn;
            }
            else { return cnn; }
        }


        //fecha a conexao
        public MySqlConnection FechaConexao()
        {
            if (cnn.State == System.Data.ConnectionState.Open)
            {
                cnn.Close();
                return cnn;
            }
            else { return cnn; }
        }



    }
}


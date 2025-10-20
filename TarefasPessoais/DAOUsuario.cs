using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TarefasPessoais
{
    class DAOUsuario
    {
        public MySqlConnection conexao;
        public string dados;
        public string comando;
        public int[] codigo;
        public string[] nome;
        public string[] senha;
        public int i;
        public int contador;
        public string msg;
        public int posicao;
        
        public DAOUsuario()
        {
            conexao = new MySqlConnection("server=localhost;DataBase=gerenciadorTarefas;Uid=root;Password=;Convert Zero DateTime=True");
            try
            {
                conexao.Open();
            }//Fim do Try
            catch (Exception erro)
            {
                MessageBox.Show($"Algo deu errado!\n\n {erro}");
                conexao.Close();
            }//Fim do Catch
        }//Fim do Construtor

        public void Inserir(string nome, string senha)
        {
            try
            {
                dados = $"('','{nome}', '{senha}')";
                comando = $"Insert into usuario(codigo, nome, senha) values{dados}";
                MySqlCommand sql = new MySqlCommand(comando, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                MessageBox.Show($"Inserido com sucesso! {resultado}");
            }//Fim do Try
            catch (Exception erro)
            {
                MessageBox.Show($"Algo deu Errado!!!\n\n {erro}");
            }//Fim do Catch
        }//Fim do Inserir

        public void PreencherVetor()
        {
            string query = "select * from usuario";
            codigo = new int[100];
            nome = new string[100];
            senha = new string[100];

            for (i = 0; i < 100; i++)
            {
                codigo[i] = 0;
                nome[i] = "";
                senha[i] = "";
            }//Fim do For

            MySqlCommand coletar = new MySqlCommand(query, conexao);
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            contador = 0;

            while (leitura.Read())
            {
                codigo[i] = Convert.ToInt32(leitura["codigo"]);
                nome[i] = leitura["nome"] + "";
                senha[i] = leitura["senha"] + "";
                i++;
                contador++; 
            }//Fim do While
            leitura.Close();
        }//Fim do PreencherVetor


    }//Fim da classe
}//Fim do Projeto

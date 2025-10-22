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

        public string ConsultarTudo()
        {
            PreencherVetor();
            msg = "";
            for (i = 0; i < contador; i++)
            {
                msg += $"\n\nCódigo: {codigo[i]} \nNome: {nome[i]} \nSenha: {senha[i]}";
            }//Fim do For
            return msg;
        }//Fim do ConsultarTudo

        public string ConsultarPorCodigo(int codigo)
        {
            PreencherVetor();
            msg = "";
            for (i = 0; i < contador; i++)
            {
                if (this.codigo[i] == codigo)
                {
                    msg = $"\n\nCódigo: {this.codigo[i]} \nNome: {nome[i]} \nSenha: {senha[i]}";
                    return msg;
                }//Fim do If
            }//Fim do For
            return "\n\nCódigo informado não foi encontrado!";
        }//Fim do ConsultarPorCodigo

        public int ConsultarPorNome(string nome)
        {
            PreencherVetor();
            msg = "";
            for (i = 0; i < contador; i++)
            {
                if (this.nome[i] == nome)
                {
                    return codigo[i];
                }//Fim do If
            }//Fim do For
            return -1;
        }//Fim do ConsultarPorNome

        public int ValidarUsuarioSenha(string nome, string senha)
        {
            PreencherVetor();
            msg = "";
            for (i = 0; i < contador; i++)
            {
                if (this.nome[i] == nome && this.senha[i] == senha)
                {
                    this.posicao = i;
                    return this.posicao + 1;
                }//Fim do If
            }//Fim do For
            return -1;
        }//Fim do ValidarUsuarioSenha

        public string Atualizar(int codigo, string campo, string novoDado)
        {
            try
            {
                string query = $"update usuario set {campo} = '{novoDado}' where codigo = '{codigo}'";
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + " dado atualizado com sucesso!";
            }//Fim do Try
            catch (Exception erro)
            {
                return $"\nAlgo deu errado!\n\n {erro}";
            }//Fim do Catch
        }//Fim do Atualizar

        public string Deletar(int codigo)
        {
            try
            {
                string query = $"delete from usuario where codigo = '{codigo}'";
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + " dado excluído!";
            }//Fim do Try
            catch (Exception erro)
            {
                return $"Algo deu errado\n\n {erro}";
            }//Fim do Catch
        }//Fim do Deletar
    }//Fim da Classe
}//Fim do Projeto

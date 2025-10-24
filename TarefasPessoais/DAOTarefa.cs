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
    class DAOTarefa
    {
        public MySqlConnection conexao;
        public string dados;
        public string comando;
        public int[] codigo;
        public string[] tarefa;
        public string[] prioridade;
        public DateTime[] prazo;
        public string[] lembrete;
        public int[] codigoUsuario;
        public int i;
        public int contador;
        public string msg;
        public int posicao;

        public DAOTarefa()
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

        public void Inserir(string tarefa, string prioridade, DateTime prazo, string lembrete, int codigoUsuario)
        {
            try
            {
                dados = $"('','{tarefa}', '{prioridade}','{prazo}', '{lembrete}','{codigoUsuario}')";
                comando = $"Insert into tarefa(codigo, tarefa, prioridade, prazo, lembrete, codigoUsuario) values{dados}";
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
            string query = "select * from tarefa";
            codigo = new int[100];
            tarefa = new string[100];
            prioridade = new string[100];
            prazo = new DateTime[100];
            lembrete = new string[100];
            codigoUsuario = new int[100];

            for (i = 0; i < 100; i++)
            {
                codigo[i] = 0;
                tarefa[i] = "";
                prioridade[i] = "";
                prazo[i] = new DateTime();
                lembrete[i] = "";
                codigoUsuario[i] = 0;
            }//Fim do For

        MySqlCommand coletar = new MySqlCommand(query, conexao);
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            contador = 0;

            while (leitura.Read())
            {
                codigo[i] = Convert.ToInt32(leitura["codigo"]);
                tarefa[i] = leitura["tarefa"] + "";
                prioridade[i] = leitura["prioridade"] + "";
                prazo[i] = Convert.ToDateTime(leitura["prazo"]);
                lembrete[i] = leitura["lembrete"] + "";
                codigoUsuario[i] = Convert.ToInt32(leitura["codigoUsuario"]);
                i++;
                contador++;
            }//Fim do While
            leitura.Close();
        }//Fim do PreencherVetor

        public int QuantidadeDeDados()
        {
            return contador;
        }//Fim do método

        public string ConsultarTudo()
        {
            PreencherVetor();
            msg = "";
            for (i = 0; i < contador; i++)
            {
                msg += $"\n\nCódigo: {codigo[i]} \nTarefa: {tarefa[i]} \nPrioridade: {prioridade[i]} \nPrazo: {prazo[i]} \nLembrete: {lembrete[i]} " +
                       $"\nCódigo Usuário: {codigoUsuario[i]}";
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
                    msg = $"\n\nCódigo: {this.codigo[i]} \nTarefa: {tarefa[i]} \nPrioridade: {prioridade[i]} \nPrazo: {prazo[i]} \nLembrete: {lembrete[i]} " +
                          $"\nCódigo Usuário: {codigoUsuario[i]}";
                    return msg;
                }//Fim do If
            }//Fim do For
            return "\n\nCódigo informado não foi encontrado!";
        }//Fim do ConsultarPorCodigo

        public int ConsultarPorTarefa(string tarefa)
        {
            PreencherVetor();
            msg = "";
            for (i = 0; i < contador; i++)
            {
                if (this.tarefa[i] == tarefa)
                {
                    return codigo[i];
                }//Fim do If
            }//Fim do For
            return -1;
        }//Fim do ConsultarPorTarefa

        public int ConsultarPorPrioridade(string prioridade)
        {
            PreencherVetor();
            msg = "";
            for (i = 0; i < contador; i++)
            {
                if (this.prioridade[i] == prioridade)
                {
                    return codigo[i];
                }//Fim do If
            }//Fim do For
            return -1;
        }//Fim do ConsultarPorPrioridade

        public int ConsultarPorPrazo(DateTime prazo)
        {
            PreencherVetor();
            msg = "";
            for (i = 0; i < contador; i++)
            {
                if (this.prazo[i] == prazo)
                {
                    return codigo[i];
                }//Fim do If
            }//Fim do For
            return -1;
        }//Fim do ConsultarPorPrazo

        public int ConsultarPorUsuario(int codigoUsuario)
        {
            PreencherVetor();
            msg = "";
            for (i = 0; i < contador; i++)
            {
                if (this.codigoUsuario[i] == codigoUsuario)
                {
                    return codigo[i];
                }//Fim do If
            }//Fim do For
            return -1;
        }//Fim do ConsultarPorUsuario

        public string Atualizar(int codigo, string campo, string novoDado)
        {
            try
            {
                string query = $"update tarefa set {campo} = '{novoDado}' where codigo = '{codigo}'";
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + " dado atualizado com sucesso!";
            }//Fim do Try
            catch (Exception erro)
            {
                return $"\nAlgo deu errado!\n\n {erro}";
            }//Fim do Catch
        }//Fim do Atualizar

        public string Atualizar(int codigo, string campo, DateTime novoDado)
        {
            try
            {
                string query = $"update tarefa set {campo} = '{novoDado}' where codigo = '{codigo}'";
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + " dado atualizado com sucesso!";
            }//Fim do Try
            catch (Exception erro)
            {
                return $"\nAlgo deu errado!\n\n {erro}";
            }//Fim do Catch
        }//Fim do Atualizar

        public string Atualizar(int codigo, string campo, int novoDado)
        {
            try
            {
                string query = $"update tarefa set {campo} = '{novoDado}' where codigo = '{codigo}'";
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
                string query = $"delete from tarefa where codigo = '{codigo}'";
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

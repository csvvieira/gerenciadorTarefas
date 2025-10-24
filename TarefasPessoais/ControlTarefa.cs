using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TarefasPessoais
{
    class ControlTarefa
    {
        private DAOTarefa dao;

        public ControlTarefa(string tarefa, string prioridade, DateTime prazo, string lembrete, int codigoUsuario)
        {
            this.dao = new DAOTarefa();
            this.dao.Inserir(tarefa, prioridade, prazo, lembrete, codigoUsuario);
        }//fim do construtor

        public void Imprimir()
        {
            this.dao = new DAOTarefa();
            MessageBox.Show(this.dao.ConsultarTudo());
        }//fim do imprimir

        //Método para consulta por código
        public void ConsultarPorCodigo()
        {
            this.dao = new DAOTarefa();
            //Pedindo para o usuário digitar
            int codigo = Convert.ToInt32(Console.ReadLine());
            //Acionar o método ConsultarPorCodigo da DAO
            MessageBox.Show(this.dao.ConsultarPorCodigo(codigo));
        }//Fim do método

        public void Atualizar()
        {
            //Criar a instância do banco de dados
            this.dao = new DAOTarefa();
            int escolha = Convert.ToInt32(Console.ReadLine());
            //Pequeno escolha
            switch (escolha)
            {
                case 1:
                    int codigo = Convert.ToInt32(Console.ReadLine());
                    //Nova descrição
                    string tarefa = Console.ReadLine();
                    //Atualizar
                    MessageBox.Show(this.dao.Atualizar(codigo, "tarefa", tarefa));
                    break;
                case 2:
                    int codigo1 = Convert.ToInt32(Console.ReadLine());
                    //Nova descrição
                    string prioridade = Console.ReadLine();
                    //Atualizar
                    MessageBox.Show(this.dao.Atualizar(codigo1, "prioridade", prioridade));
                    break;
                case 3:
                    int codigo2 = Convert.ToInt32(Console.ReadLine());
                    //Nova descrição
                    DateTime prazo = Convert.ToDateTime(Console.ReadLine());
                    //Atualizar
                    MessageBox.Show(this.dao.Atualizar(codigo2, "prazo", prazo));
                    break;
                case 4:
                    int codigo3 = Convert.ToInt32(Console.ReadLine());
                    //Nova descrição
                    string lembrete = Console.ReadLine();
                    //Atualizar
                    MessageBox.Show(this.dao.Atualizar(codigo3, "lembrete", lembrete));
                    break;
                case 5:
                    int codigo4 = Convert.ToInt32(Console.ReadLine());
                    //Nova descrição
                    int codigoUsuario = Convert.ToInt32(Console.ReadLine());
                    //Atualizar
                    MessageBox.Show(this.dao.Atualizar(codigo4, "codigoUsuario", codigoUsuario));
                    break;
                default:
                    MessageBox.Show("Impossível atualizar, algo deu errado!");
                    break;
            }//Fim do switch
        }//fim do atualizar

        public void Excluir()
        {
            this.dao = new DAOTarefa();
            int codigo = Convert.ToInt32(Console.ReadLine());

            //Chama o método para excluir
            MessageBox.Show(this.dao.Deletar(codigo));
        }//Fim do Excluir
    }//Fim da Classe
}//Fim do Projeto

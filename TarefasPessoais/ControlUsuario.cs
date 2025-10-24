using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TarefasPessoais
{
    class ControlUsuario
    {
        private DAOUsuario dao;

        public ControlUsuario(string nome, string senha)
        {
            this.dao = new DAOUsuario();
            this.dao.Inserir(nome, senha);
        }//fim do construtor

        public void Imprimir()
        {
            this.dao = new DAOUsuario();
            MessageBox.Show(this.dao.ConsultarTudo());
        }//fim do imprimir

        //Método para consulta por código
        public void ConsultarPorCodigo()
        {
            this.dao = new DAOUsuario();
            //Pedindo para o usuário digitar
            int codigo = Convert.ToInt32(Console.ReadLine());
            //Acionar o método ConsultarPorCodigo da DAO
            MessageBox.Show(this.dao.ConsultarPorCodigo(codigo));
        }//Fim do método

        public void Atualizar()
        {
            //Criar a instância do banco de dados
            this.dao = new DAOUsuario();
            int escolha = Convert.ToInt32(Console.ReadLine());
            //Pequeno escolha
            switch (escolha)
            {
                case 1:
                    int codigo = Convert.ToInt32(Console.ReadLine());
                    //Nova descrição
                    string nome = Console.ReadLine();
                    //Atualizar
                    MessageBox.Show(this.dao.Atualizar(codigo, "nome", nome));
                    break;
                case 2:
                    int codigo1 = Convert.ToInt32(Console.ReadLine());
                    //Nova descrição
                    string senha = Console.ReadLine();
                    //Atualizar
                    MessageBox.Show(this.dao.Atualizar(codigo1, "senha", senha));
                    break;
                default:
                    MessageBox.Show("Impossível atualizar, algo deu errado!");
                    break;
            }//Fim do switch
        }//fim do atualizar

        public void Excluir()
        {
            this.dao = new DAOUsuario();
            int codigo = Convert.ToInt32(Console.ReadLine());

            //Chama o método para excluir
            MessageBox.Show(this.dao.Deletar(codigo));
        }//Fim do Excluir
    }//Fim da Classe
}//Fim do Projeto

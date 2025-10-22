using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarefasPessoais
{
    class ControlUsuario
    {
        private DAOUsuario dao;

        public ControlAutor()
        {
            autor = new Autor();
        }//fim do construtor

        public ControlAutor(string nome, string nacionalidade)
        {
            this.dao = new DAOAutor();
            this.dao.Inserir(nome, nacionalidade);
        }//fim do construtor

        public void Imprimir()
        {
            this.dao = new DAOAutor();
            Console.WriteLine(this.dao.ConsultarTudoAutor());
        }//fim do imprimir

        //Método para consulta por código
        public void ConsultarPorCodigoAutor()
        {
            this.dao = new DAOAutor();
            //Pedindo para o usuário digitar
            Console.WriteLine("Informe o código que deseja buscar: ");
            int codigo = Convert.ToInt32(Console.ReadLine());
            //Acionar o método ConsultarPorCodigo da DAO
            Console.WriteLine(this.dao.ConsultarPorCodigoAutor(codigo));
        }//Fim do método

        public void AtualizarAutor()
        {
            //Criar a instância do banco de dados
            this.dao = new DAOAutor();
            Console.WriteLine("Escolha o que deseja atualizar: " +
                              "\n1. Nome" +
                              "\n2. Nacionalidade");
            int escolha = Convert.ToInt32(Console.ReadLine());
            //Pequeno escolha
            switch (escolha)
            {
                case 1:
                    Console.WriteLine("\nAtualizar nome");
                    Console.WriteLine("Informe o código de onde vai atualizar");
                    int codigo = Convert.ToInt32(Console.ReadLine());
                    //Nova descrição
                    Console.WriteLine("Informe o novo nome: ");
                    string nome = Console.ReadLine();
                    //Atualizar
                    Console.WriteLine(this.dao.AtualizarAutor(codigo, "nome", nome));
                    break;
                case 2:
                    Console.WriteLine("\nAtualizar nacionalidade");
                    Console.WriteLine("Informe o código de onde vai atualizar");
                    int codigo1 = Convert.ToInt32(Console.ReadLine());
                    //Nova descrição
                    Console.WriteLine("Informe a nova nacionalidade: ");
                    string nacionalidade = Console.ReadLine();
                    //Atualizar
                    Console.WriteLine(this.dao.AtualizarAutor(codigo1, "nacionalidade", nacionalidade));
                    break;
                default:
                    Console.WriteLine("Impossível atualizar, algo deu errado!");
                    break;
            }//Fim do switch
        }//fim do atualizar

        public void ExcluirAutor()
        {
            this.dao = new DAOAutor();

            Console.WriteLine("Informe o código que deseja excluir: ");
            int codigo = Convert.ToInt32(Console.ReadLine());

            //Chama o método para excluir
            Console.WriteLine(this.dao.DeletarAutor(codigo));
        }//Fim do Excluir
    }//Fim da Classe
}//Fim do Projeto

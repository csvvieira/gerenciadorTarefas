using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TarefasPessoais
{
    public partial class CadastrarUsuario : Form
    {
        public CadastrarUsuario()
        {
            InitializeComponent();
        }//Fim do Construtor

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }//Nome

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }//Email

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }//Senha

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Coletar os dados
                int ISBN = Convert.ToInt32(textBox1.Text);
                string titulo = textBox2.Text;
                DateTime data = Convert.ToDateTime(textBox3.Text);
                string editora = textBox4.Text;
                int codigoCategoria = Convert.ToInt32(textBox5.Text);

                //Cadastrar Banco de Dados
                ControlLivro controleLivro = new ControlLivro(ISBN, titulo, data, editora, codigoCategoria);

                //Confirmar que foi inserido
                MessageBox.Show($"Cadastrado com Sucesso!!! \n\nISBN: {ISBN}" +
                                                            $"\nTítulo: {titulo}" +
                                                            $"\nData: {data}" +
                                                            $"\nEditora: {editora}" +
                                                            $"\nCódigo Categoria {codigoCategoria}");

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Algo deu errado!! \n\n{ex}");
            }
        }//Botão Cadastrar

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }//Botão Voltar
    }//Fim da Classe 
}//Fim do Projeto

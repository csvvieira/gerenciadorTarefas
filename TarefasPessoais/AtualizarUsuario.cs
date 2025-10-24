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
    public partial class AtualizarUsuario : Form
    {
        DAOAutor dao;
        public AtualizarUsuario()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }//Código

        private void button1_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(textBox1.Text);
            textBox2.Text = dao.ConsultarISBN(codigo);
            textBox3.Text = dao.ConsultarTitulo(codigo);
            textBox4.Text = dao.ConsultarAno(codigo);
            textBox5.Text = dao.ConsultarEditora(codigo);
            textBox6.Text = dao.ConsultarCategoria(codigo);
        }//Botão Buscar

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }//Nome

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }//Email

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }//Senha

        private void button2_Click(object sender, EventArgs e)
        {
            //Pegar os dados
            int ISBN = Convert.ToInt32(textBox2.Text);
            string titulo = textBox3.Text;
            DateTime data = Convert.ToDateTime(textBox4.Text);
            string editora = textBox5.Text;
            int codigoCategoria = Convert.ToInt32(textBox6.Text);
            //Atualizar
            int codigo = Convert.ToInt32(textBox1.Text);
            dao.AtualizarLivro(codigo, "isbn", ISBN);
            dao.AtualizarLivro(codigo, "titulo", titulo);
            dao.AtualizarLivro(codigo, "data", data);
            dao.AtualizarLivro(codigo, "editora", editora);
            dao.AtualizarLivro(codigo, "categoriaCodigo", codigoCategoria);
            //Mensagem
            MessageBox.Show("Atualizado com sucesso!");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }//Botão Atualizar

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }//Botão Voltar
    }//Fim da classe
}//Fim do projeto

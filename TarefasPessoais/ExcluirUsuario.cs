using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TarefasPessoais
{
    public partial class ExcluirUsuario : Form
    {
        DAOAutor dao;
        public ExcluirUsuario()
        {
            InitializeComponent();
            dao = new DAOAutor();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(textBox1.Text);
            MessageBox.Show(dao.DeletarAutor(codigo));
        }//Botão Excluir

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }//Botão Voltar

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }//Código
    }//Fim da classe
}//Fim do projeto

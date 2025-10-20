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
    public partial class TelaInicial : Form
    {
        public TelaInicial()
        {
            InitializeComponent();
        }//Fim do Construtor

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CadastrarUsuario cadastrarUsuario = new CadastrarUsuario();
            cadastrarUsuario.ShowDialog();
        }//Botão Cadastrar

        private void button3_Click(object sender, EventArgs e)
        {
            LoginUsuario loginUsuario = new LoginUsuario();
            loginUsuario.ShowDialog();
        }//Botão Entar
    }//Fim da Classe
}//Fim do Projeto

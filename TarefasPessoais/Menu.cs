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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }//Fim do Construtor

        private void button2_Click(object sender, EventArgs e)
        {
            MenuTarefa menuTarefa = new MenuTarefa();
            menuTarefa.ShowDialog();
        }//Botão Tarefa

        private void button1_Click(object sender, EventArgs e)
        {
            MenuUsuario menuUsuario = new MenuUsuario();
            menuUsuario.ShowDialog();
        }//Botão Usuário

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }//Botão Voltar
    }//Fim da Classe
}//Fim do Projeto

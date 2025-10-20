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
    public partial class MenuUsuario : Form
    {
        public MenuUsuario()
        {
            InitializeComponent();
        }//Fim do Construtor

        private void button1_Click(object sender, EventArgs e)
        {
            CadastrarUsuario cadastrarUsuario = new CadastrarUsuario();
            cadastrarUsuario.ShowDialog();
        }//Botão Cadastrar

        private void button2_Click(object sender, EventArgs e)
        {
            ConsultarUsuario consultarUsuario = new ConsultarUsuario();
            consultarUsuario.ShowDialog();
        }//Botão Consultar

        private void button3_Click(object sender, EventArgs e)
        {
            AtualizarUsuario atualizarUsuario = new AtualizarUsuario();
            atualizarUsuario.ShowDialog();
        }//Botão Atualizar

        private void button4_Click(object sender, EventArgs e)
        {
            ExcluirUsuario excluirUsuario = new ExcluirUsuario();
            excluirUsuario.ShowDialog();
        }//Botão Excluir

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }//Botão Voltar

        private void MenuUsuário_Load(object sender, EventArgs e)
        {

        }
    }//Fim da Classe
}//Fim do Projeto

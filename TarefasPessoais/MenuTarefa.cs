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
    public partial class MenuTarefa : Form
    {
        public MenuTarefa()
        {
            InitializeComponent();
        }//Fim do Construtor

        private void button1_Click(object sender, EventArgs e)
        {
            CadastrarTarefa cadastrarTarefa = new CadastrarTarefa();
            cadastrarTarefa.ShowDialog();
        }//Botão Cadastrar

        private void button2_Click(object sender, EventArgs e)
        {
            ConsultarTarefa consultarTarefa = new ConsultarTarefa();
            consultarTarefa.ShowDialog();
        }//Botão Consultar

        private void button3_Click(object sender, EventArgs e)
        {
            AtualizarTarefa atualizarTarefa = new AtualizarTarefa();
            atualizarTarefa.ShowDialog();
        }//Botão Atualizar

        private void button4_Click(object sender, EventArgs e)
        {
            ExcluirTarefa excluirTarefa = new ExcluirTarefa(); 
            excluirTarefa.ShowDialog();  

        }//Botão Excluir

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }//Botão Voltar
    }//Fim da Classe
}//Fim do Projeto

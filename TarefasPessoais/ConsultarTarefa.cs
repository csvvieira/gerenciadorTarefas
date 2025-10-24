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
    
    public partial class ConsultarTarefa : Form
    {
        ControlAutor controle;
        DAOAutor dao;
        public ConsultarTarefa()
        {
            InitializeComponent();
            controle = new ControlAutor();
            dao = new DAOAutor();
            ConfigurarGrid();//Estruturando o grid;
            NomeDados();//Nomear as colunas
            dao.PreencherVetorAutor();//Preencher os vetores e consultar o banco
            AdicionarDados();//Inserir os dados na tela, linha por linha
        }//Fim do Construtor

        public void AdicionarDados()
        {
            for (int i = 0; i < dao.QuantidadeDeDados(); i++)
            {
                dataGridView1.Rows.Add(dao.codigo[i], dao.nome[i], dao.nacionalidade[i]);
            }//Fim do for
        }//Fim do método

        public void ConfigurarGrid()
        {
            dataGridView1.AllowUserToAddRows = false;//Adicionar Linhas Proibido
            dataGridView1.AllowUserToDeleteRows = false;//Apagar Linhas Proibido
            dataGridView1.AllowUserToResizeColumns = false;//Modificar Colunas Proibido
            dataGridView1.AllowUserToResizeRows = false;//Modificar Linhas Proibido
            dataGridView1.ColumnCount = 3;
        }//Fim do ConfigurarGrid

        public void NomeDados()
        {
            dataGridView1.Columns[0].Name = "Código";
            dataGridView1.Columns[1].Name = "Nome";
            dataGridView1.Columns[2].Name = "Nacionalidade";
        }//Fim do NomeDados

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }//Fim do DataGridView

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }//Botão Voltar
    }//Fim da classe
}//Fim do projeto

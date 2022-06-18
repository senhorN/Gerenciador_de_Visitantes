using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/* usando o mysql no projeto */
using MySql.Data.MySqlClient;




namespace ProjetoVisitantes01
{
    public partial class Form1 : Form
    {
        //comando com conexão do banco de dados 
        MySqlConnection mConn = new MySqlConnection(
            "Persist Security Info = False;" +
            "Server = localhost;" +
            "database = fatec1sem_linguagem;" +
            "uid = root;" +
            "pwd = "
            );

        int idselecionado = -1;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //direciona para o proximo form [form cadastro de clientes]
            CadastroDeCliente janela = new CadastroDeCliente();
            janela.ShowDialog();

            //usado para atualizar o DGV(data grid views)
            button3.PerformClick();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (idselecionado >= 0)
            {


                frmDeletar frmDel = new frmDeletar(idselecionado);

                frmDel.ShowDialog();
                idselecionado = -1;

                button3.PerformClick();


            }
            else
            {
                MessageBox.Show("selecione um cliente da lista",
                    "informação", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Mensagem de INFORMAÇÃO para a saida do form
            if (MessageBox.Show("Deseja sair?",
                "informação", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //fecha form
                this.Close();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button3.PerformClick();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            try
            {
                //abrindo uma conexão com o banco de dados 
                mConn.Open();

                if(mConn.State == ConnectionState.Open)
                {
                    
                    //limpando o datagridshow para novos dados 
                    dataGridView1.Rows.Clear();

                    //definindo o número de colunas do dgv;
                    dataGridView1.ColumnCount = 4;

                    //definindo a largura e o nome das colunas
                    dataGridView1.Columns[0].Width = 50;
                    dataGridView1.Columns[0].Name = "#";

                    dataGridView1.Columns[1].Width =255;
                    dataGridView1.Columns[1].Name = "Nome";

                    dataGridView1.Columns[2].Width = 225;
                    dataGridView1.Columns[2].Name = "Email";

                    dataGridView1.Columns[3].Width = 225;
                    dataGridView1.Columns[3].Name = "Fone";

                    //variável que terá o comando SQL e a conexão a ser utilizada 
                    MySqlCommand comandoSQL = mConn.CreateCommand();
                    //comando/query SQL que será executada pelo banco 
                    comandoSQL.CommandText = "SELECT idClientes, nomeClientes, emailClientes, foneClientes FROM clientes";
                    //indica a conexão com o banco
                    comandoSQL.Connection = mConn;
                    /* dadosClientes recebe os dados da QUERY acima, os dados 
                     * vem em formato de tabela linha = registros e colunas = Campos*/ 
                    MySqlDataReader dadosClientes = comandoSQL.ExecuteReader();


                    string[] linha;
                    
                    while(dadosClientes.Read())
                    {
                        linha = new string[]
                        {
                            dadosClientes["idClientes"].ToString(),
                            dadosClientes["nomeClientes"].ToString(),
                            dadosClientes["emailClientes"].ToString(),
                            dadosClientes["foneClientes"].ToString()
                        };
                        //adiciona os dados lidos no datagridview 
                        dataGridView1.Rows.Add(linha);
                    }
                    
                }
                //fecha a conexão
                mConn.Close();

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro detectado, entre em contato com Dev. \n\n"+erro.Message,
                    "Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);

               
            }
             
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            
            // retorna o índice da linha 
            int linha = dataGridView1.CurrentRow.Index;

            //índice da coluna que tem o código desejado
            int coluna = 0;


            /*a partir da linha e da coluna pega o valor da célula e converte 
             para inteiro e atribui para veríavel idselecionado, que seja utilizado
             para atualizar o registro  ou exclui.*/ 
            idselecionado = Convert.ToInt32(dataGridView1.Rows[linha].Cells[coluna].Value.ToString());
            //caixa de texto inserindo a informação com o idselcionado 
            //MessageBox.Show(idselecionado.ToString());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (idselecionado >= 0)
            {


                frmAlterar frmAlt = new frmAlterar(idselecionado);

                frmAlt.ShowDialog();
                idselecionado = -1;

                button3.PerformClick();
                

            }
            else
            {
                MessageBox.Show("selecione um cliente da lista",
                    "informação", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

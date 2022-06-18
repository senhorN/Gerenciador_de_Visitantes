using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//impletado o banco de dados 
using MySql.Data.MySqlClient;



namespace ProjetoVisitantes01
{
    public partial class frmDeletar : Form
    {
        //comando com conexão do banco de dados 
        MySqlConnection mConn = new MySqlConnection(
            "Persist Security Info = False;" +
            "Server = localhost;" +
            "database = fatec1sem_linguagem;" +
            "uid = root;" +
            "pwd = "
            );


        int idselecionado;
        public frmDeletar(int ID)
        {   
            InitializeComponent();
            idselecionado = ID;
            try
            {

                //abre uma conexão com banco 
                mConn.Open();
                
                if (mConn.State == ConnectionState.Open)
                {
                    MySqlCommand comandoSQL = mConn.CreateCommand();

                    comandoSQL.CommandText = "SELECT * FROM clientes WHERE idclientes = " + ID;
                    comandoSQL.Connection = mConn;


                    MySqlDataReader linha = comandoSQL.ExecuteReader();

                    //lendo a linha de retorno/pesquisa
                    linha.Read();

                    //mostra os dados do formulário
                    textBox1.Text = linha["nomeClientes"].ToString();
                    textBox2.Text = linha["emailClientes"].ToString();
                    textBox4.Text = linha["foneClientes"].ToString();
                    textBox3.Text = linha["cidadeClientes"].ToString();
                    comboBox1.Text = linha["sexoClientes"].ToString();
                    textBox5.Text = linha["obsClientes"].ToString();



                    mConn.Close();

                }
            }
            catch (Exception Erro)
            {
                MessageBox.Show("Erro detectado, entre em contato com Dev. \n\n" + Erro.Message,
                    "Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente exlcuir o registro?",
              "informação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //se for SIM

                try
                {
                    mConn.Open();
                    if (mConn.State == ConnectionState.Open)
                    {
                        MySqlCommand comandoSQL = mConn.CreateCommand();

                        
                        comandoSQL.CommandText = "DELETE FROM clientes WHERE idclientes=" + idselecionado;
                        comandoSQL.Connection = mConn;
                        comandoSQL.ExecuteNonQuery();
                        //fecha o form 
                        this.Close();
                        
                        //mensagem de exclusão do usuario
                        MessageBox.Show("Registro excluido com sucesso!",
                        "informação", MessageBoxButtons.OK,          MessageBoxIcon.Information); 

                        //fecha a conexão
                        mConn.Close();
                    }

                }
                catch (Exception Erro)
                {
                   //situação de erro caso o banco não conecta
                    MessageBox.Show("Erro detectado, entre em contato com Dev. \n\n" + Erro.Message,
                        "Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {   
                //situação cancelada devido o erro da conexão
                MessageBox.Show("O processo de Exclusão foi cancelado.");
            }
        
                 
                
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

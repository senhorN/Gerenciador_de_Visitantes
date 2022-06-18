using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//mysql
using MySql.Data.MySqlClient;


namespace ProjetoVisitantes01
{
    public partial class CadastroDeCliente : Form
    {
        //comando com conexão do banco de dados 
        MySqlConnection mConn = new MySqlConnection(
            "Persist Security Info = False;" +
            "Server = localhost;" +
            "database = fatec1sem_linguagem;" +
            "uid = root;" +
            "pwd = "
            );
        public CadastroDeCliente()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Fecha form
            this.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //Abre a conexão do banco de dados 
                mConn.Open();
                if(mConn.State == ConnectionState.Open)
                {
                    MySqlCommand comandoSQL = new MySqlCommand();

                   //Insere  os dados no banco de dados indicando os campos e valores.
                    comandoSQL.CommandText = $"INSERT INTO clientes(nomeClientes, emailClientes, cidadeClientes, foneClientes, sexoClientes, obsClientes) VALUES('{textBox1.Text}', '{textBox2.Text}', '{textBox3.Text}', '{textBox4.Text}','{textBox5.Text}', '{comboBox1.Text}')";
                   
                    //qual conexão será utilizada
                    comandoSQL.Connection = mConn;
                    
                    //executa o comando 
                    comandoSQL.ExecuteNonQuery();

                   

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    comboBox1.Text = " ";

                    //informação de registro salvo 
                    MessageBox.Show("Registro salvo com sucesso!", "Informação",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    //Volta ao inicio assim que reiniciado
                    textBox1.Focus();


                    

                }
                
            }
            catch (Exception erro)
            {
                //informação caso o banco de dados tenha erro de conexão
                MessageBox.Show("Erro detecatdo, entre em contato com Dev \n\n" + erro.Message,
                    "Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

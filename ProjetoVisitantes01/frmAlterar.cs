using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//usado para acessar o banco de dados
using MySql.Data.MySqlClient;


namespace ProjetoVisitantes01
{
    public partial class frmAlterar : Form
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
        private object cmbSexo;

        // construtor da classe frmAlterar     (classe  = setup)

        public frmAlterar(int ID)
        {
            InitializeComponent();
            idselecionado = ID;
            try
            {
                
                //abre uma conexão com banco 
                mConn.Open();
                if(mConn.State == ConnectionState.Open)
                {
                    MySqlCommand comandoSQL = mConn.CreateCommand();

                    comandoSQL.CommandText = "SELECT * FROM clientes WHERE idclientes = "+ ID;
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
           
            try
            {
                //conexão aberta do banco 
                mConn.Open();
                if(mConn.State == ConnectionState.Open)
                {
                    MySqlCommand ComandoSQL = mConn.CreateCommand();

                    ComandoSQL.CommandText = "UPDATE clientes SET nomeClientes='" + textBox1.Text +
                        "', emailClientes='" + textBox2.Text +
                        "', cidadeClientes='" + textBox3.Text +
                        "', foneClientes='" + textBox4.Text +
                        "', obsClientes='" + textBox5.Text +
                        "', sexoClientes='" + comboBox1.Text + "'WHERE idclientes=" + idselecionado;

                    ComandoSQL.Connection = mConn;

                    ComandoSQL.ExecuteNonQuery();

                   

                    MessageBox.Show("A ataulização feita com sucesso!",
                    "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //fecha a conexão do banco de dados 

                    this.Close();
                    mConn.Close();


                }

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro detectado, entre em contato com Dev. \n\n" + erro.Message,
                    "Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

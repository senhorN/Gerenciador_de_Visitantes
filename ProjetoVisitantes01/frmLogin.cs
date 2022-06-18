using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//Biblioteca de criptografia habilitada
using System.Security.Cryptography;

//impletado o banco de dados 
using MySql.Data.MySqlClient;


namespace ProjetoVisitantes01
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();

            //comando com conexão do banco de dados 
            MySqlConnection mConn = new MySqlConnection(
                "Persist Security Info = False;" +
                "Server = localhost;" +
                "database = fatec1sem_linguagem;" +
                "uid = root;" +
                "pwd = "
                );
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

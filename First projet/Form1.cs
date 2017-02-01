using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace First_projet
{
    public partial class Form1 : Form
    {

       SqlConnection cnx = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\AA\base de stagaire.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"); 

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            cnx.Open();
            SqlCommand cmd = new SqlCommand("select * from STG ", cnx);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read() == true )
            { 
            
                listBox1.Items.Add (dr["num_stg"]);

            
            }


          cnx.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cnx.State.ToString () == "open")
            {
                MessageBox.Show(" conix daija open ");
            }
            else
            {

                cnx.Open();
                MessageBox.Show("STATE : " + cnx.State.ToString() + " ---- " + " MSG : sucsusfuly ");
                cnx.Close();
            }
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            cnx.Close();
            MessageBox.Show("STATE : " + cnx.State.ToString() + " ---- " + " MSG : sucsusfuly ");
      

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();

            cnx.Open();
            SqlCommand cmd = new SqlCommand("select * from STG ", cnx);

            SqlDataReader dr = cmd.ExecuteReader();
           // ListBox l1 = new ListBox();

            while (dr.Read())
            {
                if ( dr["num_stg"].Equals ( listBox1.SelectedItem ) )
                {
                    string x = (Convert.ToString(dr["num_stg"]) + '-' + dr["nom_stg"] + '-' + dr["prenom_stg"] + '-' + dr["fillier"]);
                   listBox2.Items.Add ( x );
                   
                    break;
                }
                 

            }


            cnx.Close();

        }
    }
}

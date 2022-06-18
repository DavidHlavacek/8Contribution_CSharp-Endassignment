using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Contribution.Classes;
using System.Data.SqlClient;

namespace Contribution
{
    public partial class Form1 : Form
    {
        //private int counter=0;

        //REFRESH ITEM LISTBOX lstContract TO ADD DATA Name - Contribution FROM FLAT FILE "contracts.txt"
        //private void Refresh()
        //{
        //    Club.LoadList();
        //    lstContract.Items.Clear();
        //    List<Contract> contracts = Club.getList(); //function doesn't exist but u get the idea
        //    foreach (Contract c in contracts)
        //    {
        //        lstContracts.Items.Add(c.Member.Name + " - " + c.Contribution);
        //    }
        //}

        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    Refresh();
        //}

        //private void addButton(object sender, EventArgs e)
        //{
        //    Club.AddContract(Member);
        //    Club.SaveList();
        //    Refresh();
        //}
        public Form1()
        {
            Thread t = new Thread(new ThreadStart(StartForm));
            t.Start();
            Thread.Sleep(3000);
            InitializeComponent();
            t.Abort();
            //this.ShowDialog();

        }



        public void StartForm()
        {
            try
            {
                Application.Run(new SplashScreen());
            }
            catch(ThreadAbortException ex)
            {
                Thread.ResetAbort();
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }


       



        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            Club.Populate();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {

            //Club club1 = new Club();
            //Member member1 = new Member("David", new DateTime(2001, 09, 21), new DateTime(2013, 09, 21), false);
            //Member member2 = new Member("Lara", new DateTime(2005, 09, 21), new DateTime(2018, 09, 21), true);
            //Member member3 = new Member("Filip", new DateTime(1989, 09, 21), new DateTime(2018, 09, 21), true);

            //Contract contract1 = new Contract(member1);
            //Contract contract2 = new Contract(member2);
            //Contract contract3 = new Contract(member3);

            //club1.AddContract(contract3);
            //club1.AddContract(contract2);
            //club1.AddContract(contract1);


            //if (counter == 1)
            //{
            //    textBox1.Text = contract1.Contribution().ToString();
            //}
            //else if (counter == 2)
            //{
            //    textBox1.Text = contract2.Contribution().ToString();
            //}
            //else if (counter == 3)
            //{
            //    textBox1.Text = contract3.Contribution().ToString();
            //}
            //else if (counter == 4)
            //{
            //    textBox1.Text = club1.TotalContribution().ToString();
            //}
            //else if (counter == 5)
            //{
            //    textBox1.Text = club1.AverageMembershipDuration().ToString();
            //}
            //else if (counter == 6)
            //{
            //    textBox1.Text = club1.YoungestMember().Name.ToString();
            //}


            //counter++;
            //Form2 f2 = new Form2();
            //f2.ShowDialog();

            string name = textBox1.Text;
            if (String.IsNullOrEmpty(name))
            {
                MessageBox.Show("Name cannot be empty!");
                return;
            }

            DateTime birthDate = dateTimePicker1.Value.Date;
            if (birthDate > DateTime.Today)
            {
                MessageBox.Show("Birth date cannot be in the future!");
                return;
            }

            DateTime joinDate = dateTimePicker2.Value.Date;
            if (joinDate > DateTime.Today)
            {
                MessageBox.Show("Join date cannot be in the future!");
                return;
            }

            if (radioButtonYes.Checked == false && radioButtonNo.Checked == false)
            {
                MessageBox.Show("Choose one radio button!");
                return;
            }
            bool isPlaying = (radioButtonYes.Checked ? true : false);

            Member newMember = new Member(name, birthDate, joinDate, isPlaying);
            Contract newContract = new Contract(newMember);

            Club.AddContract(newContract);


            SqlCommand cmd, cmd2;
            SqlConnection con;


            string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Contribution;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                
            string query1 = @"INSERT INTO Members (name, birthDate, joinDate, isPlaying) " +
                                "VALUES (@name, @birthDate, @joinDate, @isPlaying)";

            String query2 = @"INSERT INTO Contracts " +
                "VALUES ((SELECT ID from Members WHERE name=@name AND birthDate=@birthDate AND joindate=@joinDate AND isPlaying=@isPlaying), @contribution)";

            con = new SqlConnection(connStr);


            try
            {
                con.Open();
                cmd = new SqlCommand(query1, con);
                cmd2 = new SqlCommand(query2, con);
                cmd.Parameters.AddWithValue("@name", newMember.Name);
                cmd.Parameters.AddWithValue("@birthDate", newMember.BirthDate.Date.ToString("dd/MM/yyyy"));
                cmd.Parameters.AddWithValue("@joinDate", newMember.JoinDate.Date.ToString("dd/MM/yyyy"));
                cmd.Parameters.AddWithValue("@isPlaying", newMember.IsPlaying);
                cmd.ExecuteNonQuery();
                cmd2.Parameters.AddWithValue("@name", newMember.Name);
                cmd2.Parameters.AddWithValue("@birthDate", newMember.BirthDate.Date.ToString("dd/MM/yyyy"));
                cmd2.Parameters.AddWithValue("@joinDate", newMember.JoinDate.Date.ToString("dd/MM/yyyy"));
                cmd2.Parameters.AddWithValue("@isPlaying", newMember.IsPlaying);
                cmd2.Parameters.AddWithValue("@Contribution", newContract.Contribution());
                cmd2.ExecuteNonQuery();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }

            textBox1.Text = null;
            dateTimePicker1.Text = null;
            dateTimePicker2.Text = null;
            radioButtonYes.Checked = false;
            radioButtonNo.Checked = false;


        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form ContributionPerMember = new Form2();
            ContributionPerMember.ShowDialog();
        }

        //private List  

        private void button5_Click(object sender, EventArgs e)
        {
            //string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Contribution;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //SqlConnection con = new SqlConnection(connStr);
            //SqlCommand cmd = new SqlCommand("SELECT SUM(contribution) FROM Contracts", con);
            //try
            //{
            //    con.Open();
            //    object total = cmd.ExecuteScalar();
            //    textBox2.Text = Convert.ToString(total);
            //}
            //catch (Exception ex)
            //{
            //     MessageBox.Show(ex.Message);
            //}
            textBox2.Text = Club.TotalContribution().ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox3.Text = Club.AverageMembershipDuration().ToString();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (Club.YoungestMember() == null)
            {
                textBox4.Text = "No members!";
            }
            else
            {
                textBox4.Text = Club.YoungestMember().Name;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if(WindowState==FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
                notifyIcon1.Visible = true;

            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void toolStripTextBox2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form About = new About();
            About.ShowDialog();
        }
        private void toolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            tabControl1.SelectedIndex = 1;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            tabControl1.SelectedIndex = 2;
        }
    }
}

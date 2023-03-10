using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaProject
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        public static string sqlcon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kg462\Desktop\New folder\CinemaProgram\CinemaProject\ProjectDB.mdf;Integrated Security=True";
        SqlConnection con = new SqlConnection(sqlcon);
        SqlCommand cmd;
        public static string UserType,userid;
        public static SnacksShop snacks = new SnacksShop();
        public static MainForm mainForm = new MainForm();
        public static MoviesList moviesList = new MoviesList();
        public static Ticket ticket = new Ticket();
        public static EditSnacksMenu editSnacks = new EditSnacksMenu();
        public static AddMovies addMovies = new AddMovies();
        public static MovieDetails movieDetails = new MovieDetails();
        public static ChooseSeat seat = new ChooseSeat();
        public static LoginForm loginForm = new LoginForm();
        public static OrderDetails orderDetails = new OrderDetails();
        public static AdminPage admin = new AdminPage();

        private void guna2GradientCircleButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        Boolean Login() {
            try
            {
                string query = "select * from Login where UserName='" + username.Text + "' and Password='" + password.Text + "'";
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0) { userid=dt.Rows[0][0].ToString(); return true; }
                else return false;
            }
            catch { con.Close(); return false; }
        }
        private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
           
            if (Login())
            {
                UserType = "Worker";
                username.Clear(); password.Clear(); ShowPass.Checked = false;
                this.Hide();
                mainForm.Show();
            }
            else { MessageBox.Show("the data is worng, Please Try Again");username.Clear();password.Clear(); username.Focus(); }
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPass.Checked == true) password.UseSystemPasswordChar = false;
            else password.UseSystemPasswordChar = true;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            mainForm.TypeSwitch.Checked = false;
            this.Hide();
            mainForm.Show();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string query = "delete from TempOrder where ID > 0";
            con.Open();
            cmd = new SqlCommand(query,con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}

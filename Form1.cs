using Npgsql;
using System.Data;
using System.Windows.Forms;


namespace newrating
{
    public partial class Form1 : Form
    {
       

        public Form1()
        {
            InitializeComponent();
            ReadRating();
        }
        private void ReadRating()
        {
            try
            {
                NpgsqlConnection cnn = new NpgsqlConnection("Server=localhost; Port=5433; user id=postgres; database=Rating; password=12345 ");
                cnn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from wisata";
                NpgsqlDataReader rp = cmd.ExecuteReader();
                if (rp.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(rp);
                    dataGridView1.DataSource = dt;
                }
                cmd.Dispose();
                cmd.Clone();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex.Message);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
   
        }
    }
}



using System.Data.SqlClient;
using System.Data;
namespace sem_03_cs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string chain = "Server=DESKTOP-MJBK07S\\SQLEXPRESS; Database=Lab03_DB; Integrated Security=True";
                SqlConnection connection = new SqlConnection(chain);

                connection.Open();

                MessageBox.Show("Conexión exitosa");

                SqlCommand cmd = new SqlCommand("Select * from Productos", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                connection.Close();

                dataGridView1.DataSource = dataTable;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de conexión");
                throw;
            }
        }

        

    }
}

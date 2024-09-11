using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace WpfApp04
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListData();
        }

        private void ListData(string filter="") 
        {
            try
            {
                string cadena = "Server=DESKTOP-MJBK07S\\SQLEXPRESS; Database=Neptuno; Integrated Security=True";
                using SqlConnection conect = new SqlConnection(cadena);

                conect.Open();

                SqlCommand comand = new SqlCommand("USP_ListarProveedores", conect);
                comand.CommandType = CommandType.StoredProcedure;
                
                List<Producto> listaProductos = new List<Producto>();
                SqlDataReader reader = comand.ExecuteReader();

                while (reader.Read()) 
                {
                    Producto producto = new Producto();
                    producto.idproducto = (int)reader["idProducto"];
                    producto.nombreProducto = reader["nombreProducto"].ToString();
                    producto.precioUnidad = (decimal)reader["precioUnidad"];
                    listaProductos.Add(producto);
                }
                conect.Close();

                listadoProductos.ItemsSource = listaProductos;

            }
            catch { }
        }
    }


}
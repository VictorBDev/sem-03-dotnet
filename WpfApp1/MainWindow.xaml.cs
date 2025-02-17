﻿using System.Data;
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

namespace WpfApp1
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

        private void ListButton_Click(object sender, RoutedEventArgs e)
        {
            ListData();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = cuadroBusqueda.Text;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                ListData(searchTerm);
            }
        }

        private void ListData(string filter = "")
        {
            string cadena = "Server=DESKTOP-MJBK07S\\SQLEXPRESS; Database=Lab03_DB; Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(cadena))
            {
                conn.Open();
                SqlCommand command = new SqlCommand($"SELECT * FROM Students WHERE firstname LIKE '%{filter}%' OR lastname LIKE '%{filter}%'", conn);
                SqlDataReader reader = command.ExecuteReader();
                List<string> students = new List<string>();

                while (reader.Read())
                {
                    students.Add(reader["firstname"].ToString() + " " + reader["lastname"].ToString());
                }

                resultListBox.ItemsSource = students;
                conn.Close();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SQLiteChinnokPAD
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CheckDatabaseConnection();
        }

        private void CheckDatabaseConnection()
        {
            string xd = "E:/Zapisy/C#/Test/SQLiteChinnokPAD/SQLiteChinnokPAD/chinook.db";
            
            var connection = new SQLiteConnection($"Data Source={xd}");
            connection.Open();
            Debug.WriteLine("Database is connected!");

            string query = "SELECT * FROM genres";

            using (var command = new SQLiteCommand(query,connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    //List<Genres> genres = new List<Genres>();

                    while (reader.Read())
                    {
                        Debug.WriteLine(reader);
                        Debug.WriteLine(reader["Name"]);
                    }
                }
            }
        }
    }

    public class Genres
    {
        public int GenreId { get; set; }
        public string ?Name { get; set; }
    }
}

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
using System.Data;
using System.Reflection;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Media3D;

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
        }


        public void CheckDatabaseConnection(string Name)
        {
            string xd = "D:/Zapisy/Git_Repositorys/SQLiteChinnokPAD/SQLiteChinnokPAD/chinook.db";
            SQLiteConnection connection = new SQLiteConnection($"Data Source={xd}");
            connection.Open();
            Debug.WriteLine("Database is connected!");


            string query = "SELECT * FROM "+ Name +" WHERE Name LIKE 'L%' INNER JOIN ";
            //SELECT DISTINCT Name FROM playlist_track 
            //INNER JOIN tracks ON tracks.TrackId = playlist_track.TrackId
            //LIMIT 25

            using (var command = new SQLiteCommand(query,connection))
            {
                using (var reader = command.ExecuteReader())
                {

                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    TabItem tabItem = (TabItem)Jajo.SelectedItem;
                    DataGrid dataGrind = (DataGrid)tabItem.FindName(Name + "Data");
                    dataGrind.ItemsSource = dataTable.DefaultView;
                }
            }
        }

        public void btnSelectedTab_Click(object sender, RoutedEventArgs e)
        {
            TabItem JajoItem = (TabItem)Jajo.SelectedItem;
            if (JajoItem != null)
            {
                string stringowicz = JajoItem.Header.ToString();
                if (stringowicz != null)
                {
                    MessageBox.Show("Selected tab: " + JajoItem.Header);
                    CheckDatabaseConnection(stringowicz);
                }
                
            }
            
        }
    }
}

using I3B_Dapper_Svatoš.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace I3B_Dapper_Svatoš
{
    public partial class MainWindow : Window
    {
        private static string connectionString = "Server=alaska;Database=23IB25_SVATOS;Trusted_Connection=True;TrustServerCertificate=True";
        private static DatabaseConnectionFactory connectionFactory = new DatabaseConnectionFactory(connectionString);
        private static MediaTypeRepository mediaTypeRepository = new MediaTypeRepository(connectionFactory);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            var repo = new GenericRepository(connectionFactory);
        }

        private void btnCreateTable_Click(object sender, RoutedEventArgs e)
        {
            string tableName = txtTableName.Text;

            try
            {
                mediaTypeRepository.CreateTable(tableName);
                MessageBox.Show($"Tabulka {tableName} úspěšně vytvořena.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            string tableName = txtInsertTable.Text;
            string column = txtColumn.Text;
            string data = txtData.Text;

            if (string.IsNullOrWhiteSpace(tableName) ||
                string.IsNullOrWhiteSpace(column) ||
                string.IsNullOrWhiteSpace(data))
            {
                MessageBox.Show("Vyplň všechny údaje (tabulka, sloupec, hodnota).");
                return;
            }

            try
            {
                mediaTypeRepository.InsertIntoTable(tableName, column, data);
                MessageBox.Show($"Data byla úspěšně vložena do tabulky {tableName}.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Chyba při insertu:\n{ex.Message}");
            }
        }
    }
}
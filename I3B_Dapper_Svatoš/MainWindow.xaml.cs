using I3B_Dapper_Svatoš.Data;
using I3B_Dapper_Svatoš.Services;
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

namespace I3B_Dapper_Svatoš
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string connectionString = "Server=alaska;Database=[23IB25_SVATOS];Trusted_Connection=True;TrustServerCertificate=True";
            DatabaseConnectionFactory connectionFactory = new DatabaseConnectionFactory(connectionString);
            MediaTypeRepository mediaTypeRepository = new MediaTypeRepository(connectionFactory);

            mediaTypeService = new MediaTypeService(mediaTypeRepository);
        }
    }
}
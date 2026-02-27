using _236kPractos.Models;
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

namespace _236kPractos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        CinemaContext db = new CinemaContext();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Film_Click(object sender, RoutedEventArgs e)
        {
            MainFraim.Navigate(new FilmsPage());
        }

        private void Hall_Click(object sender, RoutedEventArgs e)
        {
            MainFraim.Navigate(new HallsPage());
        }

        private void Ticket_Click(object sender, RoutedEventArgs e)
        {
            MainFraim.Navigate(new TicketsPage());
        }
    }
}
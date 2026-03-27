using _236kPractos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Логика взаимодействия для TicketsPage.xaml
    /// </summary>
    public partial class TicketsPage : Page
    {

        CinemaContext db = new CinemaContext();
        ObservableCollection<Ticket> tickets = new ObservableCollection<Ticket>();

        public TicketsPage()
        {
            InitializeComponent();


            db.Tickets.Include(t => t.Film)
                .Include(t => t.Hall)
                .Load();

            tickets = db.Tickets.Local.ToObservableCollection();

            TicketGrid.ItemsSource = tickets;

            BoxFilms.ItemsSource = db.Films.ToList();
            BoxHall.ItemsSource = db.Halls.ToList();    
        }

        private void TicketGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TicketGrid.SelectedItem is Ticket t)
            {
                DataContext = t;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (TicketGrid.SelectedItem is Ticket t)
            {
                var q = MessageBox.Show("Вы точно хотите удалить билет?",
                    "Удаление",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (q == MessageBoxResult.Yes)
                    tickets.Remove(t);
                db.SaveChanges();
            }
        }

        private void Sell_Click(object sender, RoutedEventArgs e)
        {
            Ticket t = new Ticket();

            AddTicketsWindow w = new AddTicketsWindow();

            w.BoxFilms.ItemsSource = db.Films.ToList();
            w.BoxHall.ItemsSource = db.Halls.ToList();

            w.DataContext = t;

            if (w.ShowDialog() == true)
            {
                tickets.Add(t);
                db.SaveChanges();
            }

        }
    }
}

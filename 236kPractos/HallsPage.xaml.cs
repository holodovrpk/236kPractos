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
using _236kPractos.Models;
using Microsoft.EntityFrameworkCore;

namespace _236kPractos
{
    /// <summary>
    /// Логика взаимодействия для HallsPage.xaml
    /// </summary>
    public partial class HallsPage : Page
    {
        CinemaContext db = new CinemaContext();
        ObservableCollection<Hall> halls = new ObservableCollection<Hall>();

        public HallsPage()
        {
            InitializeComponent();

            db.Halls.Load();
            halls = db.Halls.Local.ToObservableCollection();
            GroupHall.ItemsSource = halls;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Hall h = new Hall();
            AddHallWindow w = new AddHallWindow();
            w.DataContext = h;

            if (w.ShowDialog() == true)
            {
                halls.Add(h);
                db.SaveChanges();
            }
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).DataContext is Hall h)
            {
                var q = MessageBox.Show("Вы точно хотите удалить зал?",
                    "Удаление",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (q == MessageBoxResult.Yes)
                    halls.Remove(h);

                db.SaveChanges();
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).DataContext is Hall h)
            {
                AddHallWindow w = new AddHallWindow();
                w.DataContext = h;

                w.ShowDialog();

                db.SaveChanges();
            }
        }
    }
}

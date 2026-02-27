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
    /// Логика взаимодействия для FilmsPage.xaml
    /// </summary>
    public partial class FilmsPage : Page
    {
        CinemaContext db = new CinemaContext();
        ObservableCollection<Film> films = new ObservableCollection<Film>();


        public FilmsPage()
        {
            InitializeComponent();

            db.Films.Load();
            films = db.Films.Local.ToObservableCollection();
            FilmGrid.ItemsSource = films;
        }
    }
}

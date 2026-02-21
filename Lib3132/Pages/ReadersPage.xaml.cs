using Lib3132.DbConnection;
using System;
using System.Collections.Generic;
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

namespace Lib3132.Pages
{
    /// <summary>
    /// Логика взаимодействия для ReadersPage.xaml
    /// </summary>
    public partial class ReadersPage : Page
    {
        public static List<Reader> readers {  get; set; }
        public static List<string> sorts { get; set; }
        public static List<Gender> genders { get; set; }
        public ReadersPage()
        {
            InitializeComponent();
            readers = new List<Reader>(ConnectionString.libraryKIUEntities.Reader.ToList());
            sorts = new List<string> { "Сбросить сортировку", "А - Я", "Я - А" };
            SortCmb.ItemsSource = sorts;
            genders = new List<Gender>(ConnectionString.libraryKIUEntities.Gender.ToList());
            this.DataContext = this;
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchTb.Text != "")
                ReadersLv.ItemsSource = new List<Reader>(ConnectionString.libraryKIUEntities.Reader.
                Where(i => i.FIO.Contains(SearchTb.Text)).ToList());
            else
                ReadersLv.ItemsSource = readers;
        }

        private void SortCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SortCmb.SelectedItem.ToString() == "А - Я")
                ReadersLv.ItemsSource = new List<Reader>(ConnectionString.libraryKIUEntities.Reader.
                    OrderBy(i => i.FIO).ToList());
            else if(SortCmb.SelectedItem.ToString() == "Я - А")
                ReadersLv.ItemsSource = new List<Reader>(ConnectionString.libraryKIUEntities.Reader.
                    OrderByDescending(i => i.FIO).ToList());
            else
                ReadersLv.ItemsSource = readers;

        }

        private void FilterCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var gen = FilterCmb.SelectedItem as Gender;
            ReadersLv.ItemsSource = new List<Reader>(ConnectionString.libraryKIUEntities.Reader.
                Where(i => i.IdGender == gen.Id).ToList());
        }
    }
}

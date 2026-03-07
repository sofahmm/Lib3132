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
    /// Логика взаимодействия для AddReadersPage.xaml
    /// </summary>
    public partial class AddReadersPage : Page
    {
        public static List<Gender> genders {  get; set; } 
        public static List<Reader> readers { get; set; }
        public AddReadersPage()
        {
            InitializeComponent();
            genders = new List<Gender>(ConnectionString.libraryKIUEntities.Gender.ToList());
            readers = new List<Reader>(ConnectionString.libraryKIUEntities.Reader.ToList());
            this.DataContext = this;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var readerExist = readers.Any(i => i.FIO.Trim() == FioTb.Text.Trim() &&
                i.NumberPhone == NumberPhoneTb.Text.Trim());
            if (readerExist)
            {
                MessageBox.Show($"Пользователь с ФИО: {FioTb.Text} и " +
                    $"номером телефона: {NumberPhoneTb.Text} существует");
            }
            if (FioTb.Text != null && EmailTb.Text != null && NumberPhoneTb.Text != null
                && BirthDateDb.SelectedDate != null && GenderCmb.SelectedItem != null)
            {
                Reader reader = new Reader();
                reader.FIO = FioTb.Text.Trim();
                reader.Email = EmailTb.Text.Trim();
                reader.NumberPhone = NumberPhoneTb.Text.Trim();
                reader.BirthDate = BirthDateDb.SelectedDate;
                reader.IdGender = (GenderCmb.SelectedItem as Gender).Id;
                ConnectionString.libraryKIUEntities.Reader.Add(reader);
                ConnectionString.libraryKIUEntities.SaveChanges();
                MessageBox.Show($"Читатель {FioTb.Text} успешно добавлен");
            }
            else
            {
                MessageBox.Show("Заполните все поля!!!");
            }
            
        }

        private void GoBackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ReadersPage());
        }
    }
}

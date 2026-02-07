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
using Lib3132.DbConnection;
using Lib3132.Windows;

namespace Lib3132
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<Employee> employees {  get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            //Создаем контейнеры для того, что введет пользователь
            string login = loginTb.Text.Trim();
            string password = passwordTb.Password.Trim();

            //заполняем динамический массив
            employees = new List<Employee>(ConnectionString.libraryKIUEntities.Employee.ToList());

            //ищем юзера
            Employee currentUser = employees.FirstOrDefault(i => i.Login.Trim() == login && i.Password.Trim() == password);
            if (currentUser != null)
            {
                MenuBiblioteqarWindow menuBiblioteqarWindow = new MenuBiblioteqarWindow();
                menuBiblioteqarWindow.Show();
            }
            else
                MessageBox.Show("Not good!");

        }
    }
}

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
using System.Windows.Shapes;
using Lib3132.Pages;

namespace Lib3132.Windows
{
    /// <summary>
    /// Логика взаимодействия для MenuBiblioteqarWindow.xaml
    /// </summary>
    public partial class MenuBiblioteqarWindow : Window
    {
        public MenuBiblioteqarWindow()
        {
            InitializeComponent();
        }

        private void readerBtn_Click(object sender, RoutedEventArgs e)
        {
            navFr.NavigationService.Navigate(new ReadersPage());
        }

        private void booksBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void authorsBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

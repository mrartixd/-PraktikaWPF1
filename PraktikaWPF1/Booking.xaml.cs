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

namespace PraktikaWPF1
{
    /// <summary>
    /// Логика взаимодействия для Booking.xaml
    /// </summary>
    public partial class Booking : Window
    {
        public Booking()
        {
            InitializeComponent();
        }
        static Room room1 = new Room();
        static Room room2 = new Room();
        static Room room3 = new Room();
        static Room room4 = new Room();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            room1 = new Room();
        }
    }
}

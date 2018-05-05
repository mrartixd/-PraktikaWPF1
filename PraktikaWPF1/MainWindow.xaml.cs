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

namespace PraktikaWPF1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void plan_Click(object sender, RoutedEventArgs e)
        {
            PlanHotelxaml hotelxaml = new PlanHotelxaml();
            hotelxaml.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Booking booking = new Booking();
            booking.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Clear clearform = new Clear();
            clearform.Show();
        }
    }
}

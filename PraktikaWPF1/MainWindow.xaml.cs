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
        static List<Room> room = new List<Room>();
        public MainWindow()
        {
            InitializeComponent();
            AddRoom();
        }

        public void AddRoom()
        {
            room.Add(new Room("Room#1", 0, null, 2, "A", false));
            room.Add(new Room("Room#2", 1, null, 2, "B", false));
            room.Add(new Room("Room#3", 2, null, 1, "B", false));
            room.Add(new Room("Room#4", 3, null, 1, "A", false));
            room.Add(new Room("Room#5", 4, null, 2, "C", false));
            room.Add(new Room("Room#6", 5, null, 1, "C", false));
            room.Add(new Room("Room#7", 6, null, 2, "A", false));
            room.Add(new Room("Room#8", 7, null, 3, "A", false));
            room.Add(new Room("Room#9", 8, null, 1, "B", false));
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

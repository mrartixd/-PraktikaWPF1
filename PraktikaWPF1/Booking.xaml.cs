﻿using System;
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
        static MainWindow main = new MainWindow();
        static List<Klient> klient = new List<Klient>();
        static List<Room> room = new List<Room>();
        static System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();


      
        private void Window_Loaded(object sender, RoutedEventArgs e)
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

            for (int i = 0; i < room.Count; i++)
            {
                if (!rooms.Items.Contains(RoomText(room[i])))
                    rooms.Items.Add(RoomText(room[i]));

            }
            
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private String RoomText(Room room)
        {
           return room.NameRoom + " rooms: " + room.Rooms + " Class: " + room.ClassRoom; 
        }
     
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            ChangePictures(room[0], door1);
            ChangePictures(room[1], door2);
            ChangePictures(room[2], door3);
            ChangePictures(room[3], door4);
            ChangePictures(room[4], door5);
            ChangePictures(room[5], door6);
            ChangePictures(room[6], door7);
            ChangePictures(room[7], door8);
            ChangePictures(room[8], door9);
        }


        private void ChangePictures(Room room, Image image)
        {
            if (room.Status == true)
            {
                image.Source = redkey.Source;
                
            }
            else if (room.Status == false)
            {
                image.Source = greenkey.Source;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            name.Clear();
            last.Clear();
            numberdoc.Clear();
            telephone.Clear();
            rooms.SelectedIndex = -1;
            starttime.SelectedDate = null;
            endtime.SelectedDate = null;
            agreebox.IsChecked = false;
            
        }

       
    

        private void book_Click(object sender, RoutedEventArgs e)
        {
            if(agreebox.IsChecked == true && room[rooms.SelectedIndex].Status == false)
            {
                room[rooms.SelectedIndex].Status = true;
                Klient kl = new Klient(name.Text, last.Text, telephone.Text, numberdoc.Text, starttime.SelectedDate.Value, endtime.SelectedDate.Value);
                room[rooms.SelectedIndex].Klient = kl;
                klient.Add(kl);
                MessageBox.Show("Welcome", "Success", MessageBoxButton.OK);
            }
            else if(agreebox.IsChecked == false)
            {
                MessageBox.Show("Check agree state", "Agree book room", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Room booked", "Book room", MessageBoxButton.OK);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Save_and_Meet
{
    public partial class EditOkno : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        bool IsUpdating { get; set; }
        Meeting meet;

        public EditOkno(string context)
        {
            InitializeComponent();
            NameError.DataContext = this;
            PlaceError.DataContext = this;
            TimeError.DataContext = this;
            AboutError.DataContext = this;
            HourError.DataContext = this;
            meet = new Meeting();
            DataContext = meet;
            IsUpdating = false;
            s = context;
        }

        static string s;

        public EditOkno(Meeting m)
        {
            InitializeComponent();
            NameError.DataContext = this;
            PlaceError.DataContext = this;
            TimeError.DataContext = this;
            AboutError.DataContext = this;
            HourError.DataContext = this;
            meet = m;
            DataContext = meet;
            IsUpdating = true;
        }

        private Visibility _NameErrorVisible;
        public Visibility NameErrorVisible
        {
            get { return _NameErrorVisible; }
            set
            {
                _NameErrorVisible = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("NameErrorVisible"));
            }
        }

        private void NameBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (meet.Name.Length < 1)
                NameErrorVisible = Visibility.Visible;
            else
                NameErrorVisible = Visibility.Hidden;
        }

        private Visibility _PlaceErrorVisible;
        public Visibility PlaceErrorVisible
        {
            get { return _PlaceErrorVisible; }
            set
            {
                _PlaceErrorVisible = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("PlaceErrorVisible"));
            }
        }

        private void PlaceBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (PlaceBox.Text.Length < 1)
                PlaceErrorVisible = Visibility.Visible;
            else
                PlaceErrorVisible = Visibility.Hidden;
        }

        private Visibility _TimeErrorVisible;
        public Visibility TimeErrorVisible
        {
            get { return _TimeErrorVisible; }
            set
            {
                _TimeErrorVisible = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("TimeErrorVisible"));
            }
        }

        private void TimeBox_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TimeBox.SelectedDate == null)
                TimeErrorVisible = Visibility.Visible;
            else
                TimeErrorVisible = Visibility.Hidden;
        }

        private Visibility _AboutErrorVisible;
        public Visibility AboutErrorVisible
        {
            get { return _AboutErrorVisible; }
            set
            {
                _AboutErrorVisible = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("AboutErrorVisible"));
            }
        }

        private void AboutBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (AboutBox.Text.Length < 1)
                AboutErrorVisible = Visibility.Visible;
            else
                AboutErrorVisible = Visibility.Hidden;
        }

        private Visibility _HourErrorVisible;
        public Visibility HourErrorVisible
        {
            get { return _HourErrorVisible; }
            set
            {
                _HourErrorVisible = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("HourErrorVisible"));
            }
        }

        private void HourBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (HourBox.Text.Length < 1)
                HourErrorVisible = Visibility.Visible;
            else
                HourErrorVisible = Visibility.Hidden;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!NameError.IsVisible && !PlaceError.IsVisible && !TimeError.IsVisible && !AboutError.IsVisible && !TimeError.IsVisible)
                if (IsUpdating == false)
                {
                    if (s == "Save_and_Meet.Meeting")
                        Meeting.AllMeeting.Add(meet);
                    if (s == "Save_and_Meet.PrivateMeeting")
                        PrivateMeeting.AllMeeting.Add(meet);
                    this.Close();
                }
                else
                {
                    this.Close();
                }
            else
            {
                MessageBox.Show("Nebyly splněny všechny požadavky!");
            }
        }       
    }
}

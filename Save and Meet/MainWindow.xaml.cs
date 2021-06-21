using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.IO;

namespace Save_and_Meet
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string me = File.ReadAllText("meeting.txt");
            string pme = File.ReadAllText("privatemeeting.txt");

            var schuze = JsonConvert.DeserializeObject<Rootobject>(me);
            var pschuze = JsonConvert.DeserializeObject<Rootobject>(pme);

            for (int i = 0; i < schuze.Results.Length; i++)
            {
                Meeting.AllMeeting.Add(new Meeting { Name = schuze.Results[i].Name, Place = schuze.Results[i].Place, Time = schuze.Results[i].Time, Participants = schuze.Results[i].Participants, Importance = schuze.Results[i].Importance, About = schuze.Results[i].About, Hour = schuze.Results[i].Hour, Notes = schuze.Results[i].Notes});
            }

            for (int i = 0; i < pschuze.Results.Length; i++)
            {
                PrivateMeeting.AllMeeting.Add(new PrivateMeeting { Name = pschuze.Results[i].Name, Place = pschuze.Results[i].Place, Time = pschuze.Results[i].Time, Participants = pschuze.Results[i].Participants, Importance = pschuze.Results[i].Importance, About = pschuze.Results[i].About, Hour = pschuze.Results[i].Hour, Notes = pschuze.Results[i].Notes});
            }

            //Meeting.InitMeeting();
            //PrivateMeeting.InitMeeting();
            Meeting m = new Meeting();
            PrivateMeeting p = new PrivateMeeting();
            DataContext = m;
            LVMeeting.DataContext = m;
        }

        private void Meeting_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Meeting me = (Meeting)((sender as ListBox).SelectedItem);
            DataContext = me;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LVMeeting.SelectedIndex = 0;
        }

        //private void Meeting_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    Meeting me = (Meeting)((sender as ListBox).SelectedItem);
        //    EditOkno ee = new EditOkno(me);
        //    ee.ShowDialog();
        //}

        private void Meeting_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int cis = LVMeeting.Items.Count;
            if (cis > 0)
            {
                Meeting me = (Meeting)((sender as ListBox).SelectedItem);
                EditOkno ee = new EditOkno(me);
                ee.ShowDialog();
            }
            else
            {
                MessageBox.Show("Není co upravit!");
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            EditOkno ee = new EditOkno(LVMeeting.DataContext.ToString());
            ee.ShowDialog();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string meet = JsonConvert.SerializeObject(Meeting.AllMeeting);
            string privatemeet = JsonConvert.SerializeObject(PrivateMeeting.AllMeeting);
            System.IO.File.WriteAllText("meeting.txt", $"{'{'}{'"'}results{'"'}:{meet}{'}'}");
            System.IO.File.WriteAllText("privatemeeting.txt", $"{'{'}{'"'}results{'"'}:{privatemeet}{'}'}");
            MessageBox.Show("Uloženo");
        }

        private void PrivateButton_Click(object sender, RoutedEventArgs e)
        {
            PrivateMeeting p = new PrivateMeeting();
            LVMeeting.DataContext = p;
            Meeting_SelectionChanged(LVMeeting, null);
            LVMeeting.SelectedIndex = 0;
        }

        private void WorkButton_Click(object sender, RoutedEventArgs e)
        {
            Meeting m = new Meeting();
            LVMeeting.DataContext = m;
            Meeting_SelectionChanged(LVMeeting, null);
            LVMeeting.SelectedIndex = 0;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Meeting> itemsToRemove = new ObservableCollection<Meeting>();

            foreach (Meeting item in LVMeeting.SelectedItems)
            {
                itemsToRemove.Add(item);
            }

            foreach (Meeting item in itemsToRemove)
            {
                ((ObservableCollection<Meeting>)LVMeeting.ItemsSource).Remove(item);
            }
        }
    }
}

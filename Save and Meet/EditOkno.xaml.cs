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

namespace Save_and_Meet
{
    public partial class EditOkno : Window
    {
        bool IsUpdating { get; set; }

        public EditOkno(string context)
        {
            InitializeComponent();
            DataContext = new Meeting();
            IsUpdating = false;
            s = context;
        }

        static string s;

        public EditOkno(Meeting m)
        {
            InitializeComponent();
            DataContext = m;
            IsUpdating = true;           
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsUpdating == false)
            {
                if (s == "Save_and_Meet.Meeting")
                Meeting.AllMeeting.Add((Meeting)DataContext);
                if (s == "Save_and_Meet.PrivateMeeting")
                    PrivateMeeting.AllMeeting.Add((Meeting)DataContext);
            }
            this.Close();
        }
    }
}

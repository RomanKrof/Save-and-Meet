using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Save_and_Meet
{
    public class PrivateMeeting : Meeting, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public static ObservableCollection<Meeting> AllMeeting { get; set; } = new ObservableCollection<Meeting>();

        public static void InitMeeting()
        {
            AllMeeting.Add(new Meeting
            {
                Name = "Pajp",
                Place = "Lajl",
                Time = new DateTime(2002, 12, 17),
                Participants = "Boofa",
                Importance = "Velká",
                About = "Pipel",
                Notes = "Nigel"
            });
        }
    }
}
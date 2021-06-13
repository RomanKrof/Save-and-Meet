using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Save_and_Meet
{
    public class Meeting : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string name;
        public string Name
        {
            get => name;
            set { name = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name")); }
        }

        private string place;
        public string Place
        {
            get => place;
            set { place = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Place")); }
        }

        private DateTime time;
        public DateTime Time
        {
            get => time;
            set { time = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Time")); }
        }

        private string participants;
        public string Participants
        {
            get => participants;
            set { participants = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Participants")); }
        }

        private string importance;
        public string Importance
        {
            get => importance;
            set { importance = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Importance")); }
        }

        private string about;
        public string About
        {
            get => about;
            set { about = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("About")); }
        }

        private string notes;
        public string Notes
        {
            get => notes;
            set { notes = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Notes")); }
        }


        public static ObservableCollection<Meeting> AllMeeting { get; set; } = new ObservableCollection<Meeting>();

        public static void InitMeeting()
        {
            AllMeeting.Add(new Meeting
            {
                Name = "Roman",
                Place = "Krof",
                Time = new DateTime(2002, 12, 17),
                Participants = "Nigga",
                Importance = "Velká",
                About = "Pipel",
                Notes = "Nigel"
            });
        }
    }
}

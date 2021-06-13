using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Save_and_Meet
{

    public class Rootobject
    {
        public result[] Results { get; set; }
    }

    public class result
    {
        public string Name { get; set; }
        public string Place { get; set; }
        public DateTime Time { get; set; }
        public string Participants { get; set; }
        public string Importance { get; set; }
        public string About { get; set; }
        public string Notes { get; set; }
    }

}

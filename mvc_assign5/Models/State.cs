using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace mvc_assign5.Models
{
    public class State
    {
        public int StateID { get; set; }
        public string vStateName { get; set; }
        public string vYear { get; set; }
        public string vSource { get; set; }

    }
}

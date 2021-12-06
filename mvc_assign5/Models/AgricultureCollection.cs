using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_assign5.Models
{
    public class AgricultureCollection
    {
        public Agriculture[] data { get; set; }
        public List<KeyValuePair<string, int>> groupedChartData { get; set; }
    }
}

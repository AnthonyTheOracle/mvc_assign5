using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace mvc_assign5.Models
{
    public class Settlement
    {
        public int SettlementID { get; set; }
        public string vState { get; set; }
        public string vYear { get; set; }
        public string vTopic { get; set; }
        public string vIndicator { get; set; }
        public string vSubMeasure { get; set; }
        public string vAmount { get; set; }
        public string vSource { get; set; }

    }
}

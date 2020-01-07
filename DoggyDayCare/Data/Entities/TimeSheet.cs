using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoggyDayCare.Data.Entities
{
    public class TimeSheet
    {
        public int TimeSheetId { get; set; }

        public DateTimeOffset Date { get; set; }

        public DateTimeOffset TimeIn { get; set; }

        public DateTimeOffset TimeOut { get; set; }

        public decimal TotalCharged { get; set; }

        public decimal TotalPaid { get; set; }

        public int DogId { get; set; }

        public virtual Dog Dog { get; set; }
    }
}

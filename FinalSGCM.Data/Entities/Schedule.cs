
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSGCM.Data.Entities
{
    public class Schedule
    {
        public int ScheduleId { get; set; }

        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }


        // Clave foranea a medic      medic <- 1:M ->schedule
        public int MedicId { get; set; }
        public Medic Medic { get; set; }

    }
}

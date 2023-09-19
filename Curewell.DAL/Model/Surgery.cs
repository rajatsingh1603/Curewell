﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curewell.DAL.Model
{
    public class Surgery
    {
        public int? DoctorId { get; set; }
        public decimal EndTime { get; set; }
        public decimal StartTime { get; set; }
        public string SurgeryCategory { get; set; }
        public DateTime SurgeryDate { get; set; }
        public int SurgeryId { get; set; }
    }
}

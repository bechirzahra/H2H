using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace H2H_WebAdmin.Models
{
    public class RendezVous
    {
        public int RendezVousId { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public Byte Confirmation { get; set; }
        public Byte Critique { get; set; }
        public virtual User User { get; set; }
    }
}
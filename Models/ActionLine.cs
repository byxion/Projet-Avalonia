using System;

namespace GAG.Models
{
    public class ActionLine
    {

        public string Grafcet { get; set; }
        public string Proget { get; set; }
        public string Unité { get; set; }
        public string Action { get; set; }
        public int NuméroAction { get; set; }
        public bool Révision { get; set; }

        public DateTime DateRévision { get; set; }
    }
}

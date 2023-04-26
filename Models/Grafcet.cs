using System;

namespace GAG.Models
{
    public class Grafcet
    {
        public Guid Id { get; set; } = new();
        public string? Nom { get; set; }
        public string? Titre { get; set; }
        public bool Serveur { get; set; }
        public int Revision { get; set; }
        public bool Recette { get; set; }
        public bool Phase { get; set; }
        public string? Type { get; set; }

    }
}
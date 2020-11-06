using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BO
{
    public class Historique
    {
        public int HistoriqueId { get; set; }
        public DateTime DateAjout { get; set; }
        public string CodeInsee { get; set; }
        public string CodeIris { get; set; }
    }
}

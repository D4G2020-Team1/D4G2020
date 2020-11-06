using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BO
{
    public class Commune
    {
        [Key, MaxLength(10)]
        public string CodeInsee { get; set; }
        public string NomCommune { get; set; }
        public string CodePostal { get; set; }

        public List<Score> Scores { get; set; }
    }
}

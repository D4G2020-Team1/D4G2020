using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BO
{
    public class Score
    {
        public int ScoreId { get; set; }
        public string LibelleDepartement { get; set; }
        public string LibelleEpci { get; set; }
        public string LibelleRegion { get; set; }
        public double Population { get; set; }
        public double ScoreGlobalDep { get; set; }
        public double ScoreGlobalEpci { get; set; }
        public double ScoreGlobalReg { get; set; }
        public string NomIris { get; set; }
        public string CodeIris { get; set; }
        public string CodeCommune { get; set; }
        public string CodeDepartement { get; set; }
        public string CodeEpci { get; set; }
        public int CodeRegion { get; set; }
        public string GeoShape { get; set; }
        public string GrandQuart { get; set; }
        public double ScoreAccesInfoDep { get; set; }
        public double ScoreAccesInfoEpci { get; set; }
        public double ScoreAccesInfoReg { get; set; }
        public double ScoreAccesInterDep { get; set; }
        public double ScoreAccesInterEpci { get; set; }
        public double ScoreAccesInterReg { get; set; }
        public double ScoreCompAdminDep { get; set; }
        public double ScoreCompAdminEpci { get; set; }
        public double ScoreCompAdminReg { get; set; }
        public double ScoreCompNumDep { get; set; }
        public double ScoreCompNumEpci { get; set; }
        public double ScoreCompNumReg { get; set; }
        public double ScoreGlobalAccesDep { get; set; }
        public double ScoreGlobalAccesEpci { get; set; }
        public double ScoreGlobalAccesReg { get; set; }
        public double ScoreGlobalCompDep { get; set; }
        public double ScoreGlobalCompEpci { get; set; }
        public double ScoreGlobalCompReg { get; set; }
        public Commune Commune { get; set; }
    }
}

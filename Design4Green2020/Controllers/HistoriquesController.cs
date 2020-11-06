using DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Design4Green2020.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoriquesController : ControllerBase
    {
        [HttpGet]
        public FileResult ExportCommuneHistorique()
        {
            var historiques = DAL_Historique.GetHistoriques();
            Dictionary<string, string> dictionnaire = new Dictionary<string, string>();
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Recherche;Date");
            bool estCommune;
            string code;
            string libelle;
            foreach (var historique in historiques)
            {
                estCommune = historique.CodeIris == null;
                code = estCommune ? historique.CodeInsee : historique.CodeIris;
                // On a déjà le libellé lié au code
                if (dictionnaire.ContainsKey(code))
                {
                    libelle = dictionnaire.GetValueOrDefault(code);
                }
                // On va chercher le libellé lié au code
                else
                {
                    libelle = DAL_Commune.GetLibelle(code, estCommune);
                    dictionnaire.Add(code, libelle);
                }
                stringBuilder.AppendLine(string.Join(';', libelle, historique.DateAjout.ToString()));
            }
            var nomFichier = string.Join('_', "export", "historique", DateTime.Now.ToShortDateString().Replace('/', '-')) + ".csv";
            nomFichier = string.Concat(nomFichier.Split(Path.GetInvalidFileNameChars()));
            return File(Encoding.ASCII.GetBytes(stringBuilder.ToString()), "text/csv", nomFichier);
        }
    }
}

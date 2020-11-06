using BO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public static class DAL_Commune
    {
        /// <summary>
        /// Renvoie les 15 premières communes contenant le nom envoyé
        /// </summary>
        /// <param name="nom">Nom</param>
        /// <param name="regionId"></param>
        /// <param name="departementId"></param>
        /// <param name="epciId"></param>
        /// <returns>Liste des communes</returns>
        public static List<Commune> GetCommunesByNomOrCodePostal(string nom, int regionId, string departementId, string epciId)
        {
            using var db = new DesignDbContext();

            string req = "SELECT DISTINCT CodeInsee, NomCommune, CodePostal, CodeCommune, CodeDepartement, CodeEpci, CodeRegion  FROM Communes com INNER JOIN Scores sco ON com.CodeInsee = sco.CodeCommune WHERE (NomCommune LIKE '%" + nom.ToUpper() + "%' OR CodePostal LIKE '%" + nom.ToUpper() + "%')";
            if (regionId != -1)
                req += " AND CodeRegion = " + regionId.ToString();
            if (!string.IsNullOrEmpty(departementId))
                req += " AND CodeDepartement = '" + departementId + "'";
            if (!string.IsNullOrEmpty(epciId) && epciId!="null")
                req += " AND CodeEpci = '" + epciId + "'";
            req += " GROUP BY CodeInsee, NomCommune, CodePostal, CodeCommune, CodeDepartement, CodeEpci, CodeRegion order by NomCommune LIMIT 50";

            return db.Communes.FromSqlRaw(req).Distinct().ToList();
        }

        /// <summary>
        /// Récupère les scores d'un quartier par son code Iris
        /// </summary>
        /// <param name="codeIris">Code iris</param>
        /// <returns>Score</returns>
        public static object GetScoreByCodeIris(string codeIris)
        {
            using var db = new DesignDbContext();
            Historique histo = new Historique
            {
                CodeIris = codeIris,
                DateAjout = DateTime.Now
            };
            db.Historiques.Add(histo);
            db.SaveChanges();

            var scores = db.Scores.Where(p => p.CodeIris == codeIris).ToList();
            scores.ForEach(p => p.Commune = null);

            return scores;
        }

        /// <summary>
        /// Récupère les scores d'un quartier par son code Iris
        /// </summary>
        /// <param name="codeIris">Code iris</param>
        /// <returns>Score</returns>
        public static Score GetScoreByCodeIrisWithCommune(string codeIris, bool bInsertHistorique = true)
        {
            using var db = new DesignDbContext();
            if (bInsertHistorique)
            {
                Historique histo = new Historique
                {
                    CodeIris = codeIris,
                    DateAjout = DateTime.Now
                };
                db.Historiques.Add(histo);
                db.SaveChanges();
            }

            Score score = db.Scores.Where(p => p.CodeIris == codeIris).Include("Commune").FirstOrDefault();
            return score;
        }

        /// <summary>
        /// Récupère les scores d'une code par son code Insee
        /// </summary>
        /// <param name="codeInsee">Code Insee</param>
        /// <returns>Score</returns>
        public static List<Score> GetScoresByCodeInsee(string codeInsee)
        {
            using var db = new DesignDbContext();
            Historique histo = new Historique
            {
                CodeInsee = codeInsee,
                DateAjout = DateTime.Now
            };
            db.Historiques.Add(histo);
            db.SaveChanges();

            var scores = db.Scores.Where(p => p.CodeCommune == codeInsee).ToList();
            scores.ForEach(p => p.Commune = null);

            return scores;
        }

        /// <summary>
        /// Récupère les scores par rapport à un code Epci
        /// </summary>
        /// <param name="intercommId">Code Epci</param>
        /// <returns>Score</returns>
        public static List<Score> GetIntercommScores(string intercommId)
        {
            using var db = new DesignDbContext();

            var scores = db.Scores.Where(p => p.CodeEpci == intercommId).ToList();
            scores.ForEach(p => p.Commune = null);

            return scores;
        }

        public static string GetLibelle(string code, bool estCommune)
        {
            using var db = new DesignDbContext();
            if (estCommune)
            {
                return db.Communes.First(o => o.CodeInsee == code).NomCommune;
            }
            else
            {
                return db.Scores.First(o => o.CodeIris == code).NomIris;
            }
        }

        /// <summary>
        /// Obtient la liste des régions
        /// </summary>
        /// <returns>Liste des régions</returns>
        public static List<RegionDto> GetRegions()
        {
            using var db = new DesignDbContext();
            return db.Scores.Where(o => o.CodeRegion != 0).Select(o => new RegionDto
            {
                RegionId = o.CodeRegion,
                Libelle = o.LibelleRegion
            }).Distinct().OrderBy(o => o.Libelle).ToList();
        }

        /// <summary>
        /// Obtient la liste des départements
        /// </summary>
        /// <returns>Liste des départements</returns>
        public static List<DepartementDto> GetDepartements()
        {
            using var db = new DesignDbContext();
            return db.Scores.Where(o => o.CodeRegion != 0).Select(o => new DepartementDto
            {
                DepartementId = o.CodeDepartement,
                Libelle = o.LibelleDepartement,
                RegionId = o.CodeRegion,
            }).Distinct().OrderBy(o => o.Libelle).ToList();
        }

        /// <summary>
        /// Renvoie les 15 premières EPCI contenant le nom envoyé
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="regionId"></param>
        /// <param name="departementId"></param>
        /// <returns>Liste des EPCI</returns>
        public static List<EpciDto> GetEpciDtosByNom(string nom, int regionId, string departementId)
        {
            using var db = new DesignDbContext();

            string req = "SELECT DISTINCT LibelleEpci, CodeDepartement, CodeEpci, CodeRegion FROM Scores WHERE LibelleEpci LIKE '%" + nom.ToUpper() + "%'";
            if (regionId != -1)
                req += " AND CodeRegion = " + regionId.ToString();
            if(!string.IsNullOrEmpty(departementId))
                req += " AND CodeDepartement = '" + departementId + "'";
            req += " group by LibelleEpci, CodeDepartement, CodeEpci, CodeRegion order by LibelleEpci LIMIT 50";

            return db.Scores.FromSqlRaw(req).Select(o => new EpciDto
            {
                EpciId = o.CodeEpci,
                Libelle = o.LibelleEpci,
                DepartementId = o.CodeDepartement
            }).Distinct().ToList();
        }
    }
}

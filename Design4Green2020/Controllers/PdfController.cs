using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using iText.Html2pdf;
using BO;
using DAL;
using iText.Layout.Font;
using System.Drawing;
using iText.IO.Font;

namespace Design4Green2020.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfController : Controller
    {
        private readonly IWebHostEnvironment env;
        public PdfController(IWebHostEnvironment env)
        {
            this.env = env;
        }
        [HttpGet("Presentation")]
        public IActionResult GetPdf(string codeIris)
        {
            try
            {
                Score oScore = DAL_Commune.GetScoreByCodeIrisWithCommune(codeIris, false);
                if (oScore != null)
                {
                    MemoryStream oStream = GeneratePDF(oScore);
                    string filename = "";
                    if (oScore.Commune != null)
                        filename = oScore.Commune.NomCommune;
                    else
                        filename = oScore.NomIris;
                    return File(oStream.ToArray(), "application/pdf", "indice national de fragilité numérique - " + filename + ".pdf");
                }
                else
                    return BadRequest("Le score n'a pas été trouvé");
                }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        private MemoryStream GeneratePDF(Score oScore)
        {
            string html = System.IO.File.ReadAllText("./Templates/presentationPDF.html");
            string LogoINRBase64String = getBase64StringFromFile(env.WebRootFileProvider.GetFileInfo("logo-inr-bandeau.jpg")?.PhysicalPath);
            string LogoAnsaBase64String = getBase64StringFromFile(env.WebRootFileProvider.GetFileInfo("Logo-ANSA-Header.jpg")?.PhysicalPath);
            string LogoMednumBase64String = getBase64StringFromFile(env.WebRootFileProvider.GetFileInfo("logo-MEDNUM.jpg")?.PhysicalPath);
            string LogoPrefRegOccBase64String = getBase64StringFromFile(env.WebRootFileProvider.GetFileInfo("Prefecture-de-region-occitanie.jpg")?.PhysicalPath);
            string LogoAccesInfoBase64String = getBase64StringFromFile("./Templates/svg/acces-info.jpg");
            string LogoAdministrativeBase64String = getBase64StringFromFile("./Templates/svg/administrative.jpg");
            string LogoInterfaceBase64String = getBase64StringFromFile("./Templates/svg/interfaces.jpg");
            string LogoUsageBase64String = getBase64StringFromFile("./Templates/svg/usage.jpg");

            Dictionary<string, string> replacements = new Dictionary<string, string>(){
                {"{srcImgLogoInr}", LogoINRBase64String},
                {"{srcImgLogoAnsa}", LogoAnsaBase64String},
                {"{srcImgLogoMednum}", LogoMednumBase64String},
                {"{srcImgLogoPrefRegOcc}", LogoPrefRegOccBase64String},
                {"{srcImgAccesInfo}", LogoAccesInfoBase64String},
                {"{srcImgCompetencesAdm}", LogoAdministrativeBase64String},
                {"{srcImgAccesInterfNum}", LogoInterfaceBase64String},
                {"{srcImgUsageInterfNum}", LogoUsageBase64String},
                {"{commune}", (oScore.Commune != null) ? oScore.Commune.NomCommune : ""},
                {"{quartier}", oScore.NomIris},
                {"{hab}", Math.Floor(oScore.Population).ToString()},
                {"{nameRegion}", oScore.LibelleRegion},
                {"{scoreGlobalRegion}", Math.Floor(oScore.ScoreGlobalReg).ToString()},
                {"{colorGlobReg}", (oScore.ScoreGlobalReg < 100) ? "" : "valeurHaute"},
                {"{scoreRegionAccesInformation}", Math.Floor(oScore.ScoreAccesInfoReg).ToString()},
                {"{scoreRegionCompetencesAdm}", Math.Floor(oScore.ScoreCompAdminReg).ToString()},
                {"{scoreRegionAccesInterfNum}", Math.Floor(oScore.ScoreAccesInterReg).ToString()},
                {"{scoreRegionUsageInterfNum}", Math.Floor(oScore.ScoreCompNumReg).ToString()},
                {"{nameDepartement}", oScore.LibelleDepartement },
                {"{scoreGlobalDepartement}", Math.Floor(oScore.ScoreGlobalDep).ToString()},
                {"{colorGlobDepartement}", (oScore.ScoreGlobalReg < 100) ? "" : "valeurHaute"},
                {"{scoreDepartementAccesInformation}", Math.Floor(oScore.ScoreAccesInfoDep).ToString()},
                {"{scoreDepartementCompetencesAdm}", Math.Floor(oScore.ScoreCompAdminDep).ToString()},
                {"{scoreDepartementAccesInterfNum}", Math.Floor(oScore.ScoreAccesInterDep).ToString()},
                {"{scoreDepartementUsageInterfNum}", Math.Floor(oScore.ScoreCompNumDep).ToString()},
                {"{nameInterCommune}", oScore.LibelleEpci },
                {"{scoreGlobalInterCommune}", Math.Floor(oScore.ScoreGlobalEpci).ToString()},
                {"{colorGlobInterCommune}", (oScore.ScoreGlobalEpci < 100) ? "" : "valeurHaute"},
                {"{scoreInterCommuneAccesInformation}", Math.Floor(oScore.ScoreAccesInfoEpci).ToString()},
                {"{scoreInterCommuneCompetencesAdm}", Math.Floor(oScore.ScoreCompAdminEpci).ToString()},
                {"{scoreInterCommuneAccesInterfNum}", Math.Floor(oScore.ScoreAccesInterEpci).ToString()},
                {"{scoreInterCommuneUsageInterfNum}", Math.Floor(oScore.ScoreCompNumEpci).ToString()},
                {"{conclusionRegion}", (oScore.ScoreGlobalReg < 100) ? "faible" : "forte" },
                {"{conclusionDepartement}", (oScore.ScoreGlobalDep < 100) ? "faible" : "forte" },
                {"{conclusionIntercom}", (oScore.ScoreGlobalEpci < 100) ? "faible" : "forte" },
            };

            foreach (string key in replacements.Keys)
            {
                html = html.Replace(key, replacements[key]);
            }
            MemoryStream oStream = new MemoryStream();
            HtmlConverter.ConvertToPdf(html, oStream);

            return oStream;
        }

        private string getBase64StringFromFile(string filename)
        {
            try
            {
                string logo = "";
                using (System.Drawing.Image image = System.Drawing.Image.FromFile(filename))
                {
                    using (MemoryStream m = new MemoryStream())
                    {
                        image.Save(m, image.RawFormat);
                        byte[] imageBytes = m.ToArray();
                        logo = Convert.ToBase64String(imageBytes);
                    }
                }
                return logo;
            }
            catch
            {
                return "";
            }
        }
    }
}

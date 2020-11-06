using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Design4Green2020.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommunesController : Controller
    {
        [HttpGet("{codeInsee}/Getscore")]
        public IActionResult Getscore(string codeInsee)
        {
            return Ok(DAL_Commune.GetScoresByCodeInsee(codeInsee));
        }

        [HttpGet("{intercommId}/GetIntercommScore")]
        public IActionResult GetIntercommScore(string intercommId)
        {
            return Ok(DAL_Commune.GetIntercommScores(intercommId));
        }

        [HttpGet("Quartiers/{codeIris}/GetScore")]
        public IActionResult GetScoreQuartier(string codeIris)
        {
            return Ok(DAL_Commune.GetScoreByCodeIris(codeIris));
        }

        [HttpGet("Regions")]
        public IActionResult GetRegions()
        {
            return Ok(DAL_Commune.GetRegions());
        }

        [HttpGet("Departements")]
        public IActionResult GetDepartements()
        {
            return Ok(DAL_Commune.GetDepartements());
        }

        [HttpGet("Epcis")]
        public IActionResult GetEpciByNom([FromQuery] string nom, [FromQuery] int regionId, [FromQuery] string departementId = "")
        {
            return Ok(DAL_Commune.GetEpciDtosByNom(nom, regionId, departementId));
        }

        [HttpGet("Recherche")]
        public IActionResult GetCommunesByNomOrCodePostal([FromQuery] string recherche, [FromQuery] int regionId, [FromQuery] string departementId = "", [FromQuery] string epciId = "")
        {
            return Ok(DAL_Commune.GetCommunesByNomOrCodePostal(recherche, regionId, departementId, epciId));
        }
    }
}

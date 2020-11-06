using BO;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public static class DAL_Historique
    {
        public static List<Historique> GetHistoriques()
        {
            using var db = new DesignDbContext();
            return db.Historiques.ToList();
        }
    }
}

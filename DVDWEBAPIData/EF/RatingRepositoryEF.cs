using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDWebAPIModels;
using DVDWebAPIModels.Interfaces;
using DVDWEBAPIData.ADO;
using System.Data;
using System.Data.SqlClient;

namespace DVDWEBAPIData.EF
{
    public class RatingRepositoryEF:IRatingRepository
    {
        public List<Rating> GetRatingList()
        {
            using (var ctx = new DvdContext())
            {
                return ctx.Rating.ToList();
            }
        }

        public Rating GetRatingbyName(string Description)
        {
            return GetRatingList().FirstOrDefault(r => r.Description == Description);
        }

        public Rating GetRatingbyId(int rateId)
        {
            return GetRatingList().FirstOrDefault(r => r.RatingId == rateId);
        }
    }
}

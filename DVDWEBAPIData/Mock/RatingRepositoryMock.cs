using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDWebAPIModels;
using DVDWebAPIModels.Interfaces;

namespace DVDWEBAPIData.Mock
{
    public class RatingRepositoryMock:IRatingRepository
    {
        public static List<Rating> rateList = new List<Rating>(){
                new Rating{RatingId = 1, Description = "Mock-G" },
                new Rating{RatingId = 2, Description = "Mock-PG" },
                new Rating{RatingId = 3, Description = "Mock-PG-13" },
            };

        public List<Rating> GetRatingList()
        {
            return rateList;
        }

        public Rating GetRatingbyName(string Description)
        {
            return rateList.FirstOrDefault(r => r.Description == Description);
        }

        public Rating GetRatingbyId(int ratingId)
        {
            return rateList.FirstOrDefault(r => r.RatingId == ratingId);
        }
        
    }
}

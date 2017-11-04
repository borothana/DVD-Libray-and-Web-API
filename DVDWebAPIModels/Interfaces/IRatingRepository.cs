using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDWebAPIModels.Interfaces
{
    public interface IRatingRepository
    {
        List<Rating> GetRatingList();
        Rating GetRatingbyName(string Description);
        Rating GetRatingbyId(int RatingId);        
    }
}

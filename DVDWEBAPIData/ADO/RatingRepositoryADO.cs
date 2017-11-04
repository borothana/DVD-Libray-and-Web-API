using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDWebAPIModels;
using DVDWebAPIModels.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace DVDWEBAPIData.ADO
{
    public class RatingRepositoryADO:IRatingRepository
    {
        public List<Rating> GetRatingList()
        {
            List<Rating> result = new List<Rating>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(ADOConnection.CnnString))
                {
                    DataSet dataSet = new DataSet();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Ratings ORDER BY RatingId", cnn);
                    if (cnn.State != ConnectionState.Open)
                    {
                        cnn.Open();
                    }
                    adapter.Fill(dataSet);

                    if (dataSet.Tables.Count > 0)
                    {
                        for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                        {
                            DataRow r = dataSet.Tables[0].Rows[i];
                            result.Add(new Rating
                            {
                                RatingId = (int)r["RatingId"],
                                Description = r["Description"].ToString()
                            });
                        }
                    }
                }
                return result;
            }
            catch (Exception e)
            {
                //alert error
            }
            return result;
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

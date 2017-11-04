using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDWebAPIModels;
using DVDWebAPIModels.Interfaces;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DVDWEBAPIData.ADO
{
    public class DvdRepositoryADO : IDvdRepository
    {
        public bool DeleteDvd(int dvd)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(ADOConnection.CnnString))
                {
                    SqlCommand cmd = new SqlCommand("DvdDelete", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@DvdId", SqlDbType.Int).Value = dvd;
                    if (cnn.State != ConnectionState.Open)
                    {
                        cnn.Open();
                    }
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Dvd GetDvd(int dvdId)
        {
            return GetDvdList().FirstOrDefault(d => d.DvdId == dvdId);
        }

        public List<Dvd> GetDvdList()
        {
            List<Dvd> result = new List<Dvd>();
            try
            {
                using(SqlConnection cnn = new SqlConnection(ADOConnection.CnnString))
                {
                    DataSet dataSet = new DataSet();
                    SqlDataAdapter adapter = new SqlDataAdapter("DvdSelect", cnn);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
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
                            Rating rate = RatingFactory.Create().GetRatingbyId((int)r["RatingId"]);
                            Director director = DirectorFactory.Create().GetDirectorbyId((int)r["DirectorId"]);
                            result.Add(new Dvd
                            {
                                DvdId = (int)r["DvdId"],
                                Title = r["Title"].ToString(),
                                ReleaseYear = (int)r["ReleaseYear"],
                                DirectorId = (int)r["DirectorId"],
                                RatingId = (int)r["RatingId"],
                                Note = r["Note"].ToString(),
                                Rating = rate,
                                Director = director
                            });
                        }
                    }
                }

                return result;
            }catch(Exception e)
            {
                return null;
            }
        }

        public int InsertDvd(Dvd dvd)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(ADOConnection.CnnString))
                {
                    dvd.Director = DirectorFactory.Create().GetDirectorbyId(dvd.DirectorId);
                    dvd.Rating = RatingFactory.Create().GetRatingbyId(dvd.RatingId);

                    SqlCommand cmd = new SqlCommand("DvdInsert", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter dvdIDParam = new SqlParameter("@DvdId", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    cmd.Parameters.Add(dvdIDParam);
                    cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = dvd.Title;
                    cmd.Parameters.Add("@ReleaseYear", SqlDbType.Int).Value = dvd.ReleaseYear;
                    cmd.Parameters.Add("@DirectorId", SqlDbType.Int).Value = dvd.DirectorId;
                    cmd.Parameters.Add("@RatingId", SqlDbType.Int).Value = dvd.RatingId;
                    cmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = dvd.Note;

                    if (cnn.State != ConnectionState.Open)
                    {
                        cnn.Open();
                    }
                    cmd.ExecuteNonQuery();
                    dvd.DvdId = (int)dvdIDParam.Value;
                    return dvd.DvdId;
                }
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public bool UpdateDvd(Dvd dvd)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(ADOConnection.CnnString))
                {
                    dvd.Director = DirectorFactory.Create().GetDirectorbyId(dvd.DirectorId);
                    dvd.Rating = RatingFactory.Create().GetRatingbyId(dvd.RatingId);

                    SqlCommand cmd = new SqlCommand("DvdUpdate", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@DvdId", SqlDbType.Int).Value = dvd.DvdId;
                    cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = dvd.Title;
                    cmd.Parameters.Add("@ReleaseYear", SqlDbType.Int).Value = dvd.ReleaseYear;
                    cmd.Parameters.Add("@DirectorId", SqlDbType.Int).Value = dvd.DirectorId;
                    cmd.Parameters.Add("@RatingId", SqlDbType.Int).Value = dvd.RatingId;
                    cmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = dvd.Note;

                    if (cnn.State != ConnectionState.Open)
                    {
                        cnn.Open();
                    }
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

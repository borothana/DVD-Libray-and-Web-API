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
    public class DirectorRepositoryADO:IDirectorRepository
    {
        public List<Director> GetDirectorList()
        {
            List<Director> result = new List<Director>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(ADOConnection.CnnString))
                {
                    DataSet dataSet = new DataSet();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Directors ORDER BY DirectorId", cnn);
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
                            result.Add(new Director
                            {
                                DirectorId = (int)r["DirectorId"],
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

        public Director GetDirectorbyName(string Description)
        {
            return GetDirectorList().FirstOrDefault(d => d.Description == Description);
        }

        public Director GetDirectorbyId(int directorId)
        {
            return GetDirectorList().FirstOrDefault(d => d.DirectorId == directorId);
        }

    }
}

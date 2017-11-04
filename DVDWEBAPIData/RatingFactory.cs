using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDWebAPIModels.Interfaces;
using System.Configuration;
using DVDWEBAPIData.ADO;
using DVDWEBAPIData.EF;
using DVDWEBAPIData.Mock;

namespace DVDWEBAPIData
{
    public class RatingFactory
    {
        public static IRatingRepository Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
            switch (mode)
            {
                case "SampleData":
                    return new RatingRepositoryMock();
                case "EntityFramework":
                    return new RatingRepositoryEF();
                default:
                    return new RatingRepositoryADO();
            }
        }
    }
}
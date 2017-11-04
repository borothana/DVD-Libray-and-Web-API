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
    public class DirectorFactory
    {
        public static IDirectorRepository Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
            switch (mode)
            {
                case "SampleData":
                    return new DirectorRepositoryMock();
                case "EntityFramework":
                    return new DirectorRepositoryEF();
                default:
                    return new DirectorRepositoryADO();
            }
        }
    }
}
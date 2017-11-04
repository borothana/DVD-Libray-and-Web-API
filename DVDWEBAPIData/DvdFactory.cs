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
    public class DvdFactory
    {
        public static IDvdRepository Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
            switch (mode)
            {
                case "SampleData":
                    return new DvdRepositoryMock();
                case "EntityFramework":
                    return new DvdRepositoryEF();
                default:
                    return new DvdRepositoryADO();
            }
        }
    }
}
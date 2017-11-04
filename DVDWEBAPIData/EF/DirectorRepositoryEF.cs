using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDWebAPIModels;
using DVDWebAPIModels.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace DVDWEBAPIData.EF
{
    public class DirectorRepositoryEF:IDirectorRepository
    {
        public List<Director> GetDirectorList()
        {
            using (var ctx = new DvdContext())
            {
                return ctx.Director.ToList();
            }
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDWebAPIModels;
using DVDWebAPIModels.Interfaces;

namespace DVDWEBAPIData.Mock
{
    public class DirectorRepositoryMock:IDirectorRepository
    {
        public static List<Director> dirList = new List<Director>(){
                new Director{DirectorId = 1, Description = "Mock-Steven Spielberg" },
                new Director{DirectorId = 2, Description = "Mock-Martin Scorsese" },
                new Director{DirectorId = 3, Description = "Mock-Quentin Tarantino" },
            };

        public List<Director> GetDirectorList()
        {
            return dirList;
        }

        public Director GetDirectorbyName(string Description)
        {
            return dirList.FirstOrDefault(d => d.Description == Description);
        }

        public Director GetDirectorbyId(int directorId)
        {
            return dirList.FirstOrDefault(d => d.DirectorId == directorId);
        }
    }
}

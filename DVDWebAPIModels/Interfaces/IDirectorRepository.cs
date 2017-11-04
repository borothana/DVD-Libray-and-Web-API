using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDWebAPIModels.Interfaces
{
    public interface IDirectorRepository
    {
        List<Director> GetDirectorList();
        Director GetDirectorbyName(string Description);
        Director GetDirectorbyId(int DirectorId);        
    }
}

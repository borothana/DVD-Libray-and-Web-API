using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDWebAPIModels.Interfaces
{
    public interface IDvdRepository
    {
        bool DeleteDvd(int dvdId);
        bool UpdateDvd(Dvd dvd);
        int InsertDvd(Dvd dvd);
        List<Dvd> GetDvdList();
        Dvd GetDvd(int dvdId);        
    }
}

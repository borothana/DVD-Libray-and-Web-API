using DVDWebAPIModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDWebAPIModels;

namespace DVDWEBAPIData.Mock
{
    class DvdRepositoryMock : IDvdRepository
    {

        public static List<Dvd> dvdList = new List<Dvd> {
            new Dvd { DvdId = 1, Title= "Saving Private Ryan", ReleaseYear = 2017, Rating = RatingRepositoryMock.rateList[0], Director = DirectorRepositoryMock.dirList[0], Note = "Mock" },
            new Dvd { DvdId = 2, Title= "The Wolf of Wall Street", ReleaseYear = 2016, Rating = RatingRepositoryMock.rateList[1], Director = DirectorRepositoryMock.dirList[1], Note = "Mock" },
            new Dvd { DvdId = 3, Title= "Pulp Fiction", ReleaseYear = 2015, Rating = RatingRepositoryMock.rateList[2], Director = DirectorRepositoryMock.dirList[2], Note = "Mock" },
            new Dvd { DvdId = 4, Title= "The Dark Knight", ReleaseYear = 2014, Rating = RatingRepositoryMock.rateList[2], Director = DirectorRepositoryMock.dirList[2], Note = "Mock" },
            new Dvd { DvdId = 5, Title= "Fight Club", ReleaseYear = 2013, Rating = RatingRepositoryMock.rateList[1], Director = DirectorRepositoryMock.dirList[1], Note = "Mock" }
        };

        public bool DeleteDvd(int dvdId)
        {
            dvdList.RemoveAll(d => d.DvdId == dvdId);
            return true;
        }

        public Dvd GetDvd(int dvdId)
        {
            return dvdList.FirstOrDefault(d => d.DvdId == dvdId);
        }

        public List<Dvd> GetDvdList()
        {
            return dvdList;
        }

        public int InsertDvd(Dvd dvd)
        {
            dvd.DvdId = dvdList.Count + 1;
            dvd.Director = DirectorFactory.Create().GetDirectorbyId(dvd.DirectorId);
            dvd.Rating = RatingFactory.Create().GetRatingbyId(dvd.RatingId);
            dvdList.Add(dvd);
            return dvd.DvdId;
        }

        public bool UpdateDvd(Dvd dvd)
        {
            dvdList.RemoveAll(d => d.DvdId == dvd.DvdId);
            dvd.Director = DirectorFactory.Create().GetDirectorbyId(dvd.DirectorId);
            dvd.Rating = RatingFactory.Create().GetRatingbyId(dvd.RatingId);
            dvdList.Add(dvd);
            return true;
        }
    }
}

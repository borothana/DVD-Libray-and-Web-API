using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DVDWEBAPIData.ADO;
using DVDWebAPIModels;

namespace DVDWEBAPITests
{
    [TestFixture]
    public class ADORepostitoryTest
    {
        [TestCase(true)]
        public void ADOCanListDvds(bool expected)
        {
            DvdRepositoryADO repo = new DvdRepositoryADO();
            List<Dvd> list = repo.GetDvdList();
            bool result = list.Count > 0;

            Assert.AreEqual(result, expected);
        }

        [TestCase(1, true)]
        [TestCase(2, true)]
        [TestCase(3, true)]
        [TestCase(100, false)]
        public void ADOCanListDvdsById(int dvdId, bool expected)
        {
            DvdRepositoryADO repo = new DvdRepositoryADO();
            Dvd dvd = repo.GetDvd(dvdId);
            bool result = !(dvd is null);

            Assert.AreEqual(result, expected);
        }
        
        [TestCase("The Departed", 2006, 1, 2, "", true)]
        [TestCase("The Dark Knight", 2008, 2, 3, "", true)]
        [TestCase("Gladiator", 2000, 3, 3, "", true)]
        [TestCase("Casablanca", 2007, 100, 1, "", false)]
        public void ADOCanInsertDvd(string title, int releaseYear, int directorId, int ratingId, string note, bool expected)
        {
            DvdRepositoryADO repo = new DvdRepositoryADO();
            Dvd dvd = new Dvd { Title = title, ReleaseYear = releaseYear, DirectorId = directorId, RatingId = ratingId, Note = note };

            bool result = repo.InsertDvd(dvd) > 0;

            Assert.AreEqual(result, expected);
        }


        [TestCase(1,"The Departed", 2006, 1, 1, "", true)]
        [TestCase(2, "The Dark Knight", 2008, 2, 2, "", true)]
        [TestCase(3, "Gladiator", 2010, 3, 3, "", true)]
        [TestCase(4, "Gladiator", 2010, 3, 30, "", false)]
        public void ADOCanModifyDvd(int dvdId, string title, int releaseYear, int directorId, int ratingId, string note, bool expected)
        {
            DvdRepositoryADO repo = new DvdRepositoryADO();
            Dvd dvd = new Dvd { DvdId = dvdId, Title = title, ReleaseYear = releaseYear, DirectorId = directorId, RatingId = ratingId, Note = note };

            bool result = repo.UpdateDvd(dvd);

            Assert.AreEqual(result, expected);
        }


        [TestCase(1, true)]
        [TestCase(2, true)]
        [TestCase(3, true)]
        public void ADOCanRemoveDvd(int dvdId, bool expected)
        {
            DvdRepositoryADO repo = new DvdRepositoryADO();
            bool result = repo.DeleteDvd(dvdId);

            Assert.AreEqual(result, expected);
        }
    }
}

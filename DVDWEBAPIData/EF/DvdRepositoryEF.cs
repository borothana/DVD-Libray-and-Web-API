using DVDWebAPIModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDWebAPIModels;


namespace DVDWEBAPIData.EF
{
    public class DvdRepositoryEF : IDvdRepository
    {
        public int InsertDvd(Dvd dvd)
        {
            try
            {
                using (var ctx = new DvdContext())
                {
                    //dvd.Director = DirectorRepositoryEF.GetDirectorbyId(dvd.DirectorId);
                    //dvd.Rating = RateRepositoryEF.GetRatebyId(dvd.RatingId);
                    ctx.Dvd.Add(dvd);
                    ctx.SaveChanges();
                    //dvd.Director = DirectorRepositoryEF.GetDirectorbyId(dvd.DirectorId);
                    //dvd.Rating = RateRepositoryEF.GetRatebyId(dvd.RatingId);
                    dvd.Director = DirectorFactory.Create().GetDirectorbyId(dvd.DirectorId);
                    dvd.Rating = RatingFactory.Create().GetRatingbyId(dvd.RatingId);
                    return ctx.Dvd.Max(d => d.DvdId);
                }
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public Dvd GetDvd(int dvdId)
        {
            return GetDvdList().FirstOrDefault(d => d.DvdId == dvdId);
        }

        public List<Dvd> GetDvdList()
        {
            using (var ctx = new DvdContext())
            {
                List<Dvd> dvdList = ctx.Dvd.Include("Director").Include("Rating").ToList();
                return dvdList;
            }
        }

        public bool UpdateDvd(Dvd dvd)
        {
            try
            {
                using (var ctx = new DvdContext())
                {
                    //dvd.Director = DirectorRepositoryEF.GetDirectorbyId(dvd.DirectorId);
                    //dvd.Rating = RateRepositoryEF.GetRatebyId(dvd.RatingId);
                    ctx.Entry(dvd).State = System.Data.Entity.EntityState.Modified;
                    ctx.SaveChanges();
                     dvd.Director = DirectorFactory.Create().GetDirectorbyId(dvd.DirectorId);
                    dvd.Rating = RatingFactory.Create().GetRatingbyId(dvd.RatingId);
                    return true;
                }
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool DeleteDvd(int dvdId)
        {
            try
            {
                Dvd dvd = GetDvd(dvdId);
                using (var ctx = new DvdContext())
                {
                    ctx.Entry(dvd).State = System.Data.Entity.EntityState.Deleted;
                    ctx.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

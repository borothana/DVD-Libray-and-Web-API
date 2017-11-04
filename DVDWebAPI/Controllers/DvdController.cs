using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DVDWEBAPIData;
using DVDWebAPIModels;
using DVDWebAPIModels.Interfaces;
using System.Web.Http.Cors;

namespace DVDWebAPI.Controllers
{
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class DvdController : ApiController
    {
        static IDvdRepository _dvdRepo = DvdFactory.Create();

        [Route("dvds")]
        [AcceptVerbs("GET")]
        public IHttpActionResult All()
        {
            return Ok(_dvdRepo.GetDvdList());
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetOne(int id)
        {
            return Ok(_dvdRepo.GetDvd(id));
        }

        [Route("dvds/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByTitle(string title)
        {
            List<Dvd> dvdList = _dvdRepo.GetDvdList();
            if (dvdList.Any(d=>d.Title == title)){
                return Ok(dvdList.Where(d => d.Title == title));
            }
            else
            {
                return NotFound();
            }
        }


        [Route("dvds/year/{releaseYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByYear(int releaseYear)
        {
            List<Dvd> dvdList = _dvdRepo.GetDvdList();
            if (dvdList.Any(d => d.ReleaseYear == releaseYear))
            {
                return Ok(dvdList.Where(d => d.ReleaseYear == releaseYear));
            }
            else
            {
                return NotFound();
            }
        }


        [Route("dvds/director/{directorName}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByDirectorName(string directorName)
        {
            List<Dvd> dvdList = _dvdRepo.GetDvdList();
            if (dvdList.Any(d => d.Director.Description == directorName))
            {
                return Ok(dvdList.Where(d => d.Director.Description == directorName));
            }
            else
            {
                return NotFound();
            }
        }

        [Route("dvds/rating/{rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByRate(string rating)
        {
            List<Dvd> dvdList = _dvdRepo.GetDvdList();
            if (dvdList.Any(d => d.Rating.Description == rating))
            {
                return Ok(dvdList.Where(d => d.Rating.Description == rating));
            }
            else
            {
                return NotFound();
            }
        }

        [Route("dvd")]
        [AcceptVerbs("POST")]
        public IHttpActionResult InsertDvd(Dvd dvd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _dvdRepo.InsertDvd(dvd);
            return Created($"/dvd/{dvd.DvdId}", dvd);
        }

        //public IHttpActionResult UpdateDvd(int id, [FromUri]Dvd dvd)
        [Route("dvd/{id}")]
        [AcceptVerbs("PUT")]
        public IHttpActionResult UpdateDvd(int id, Dvd dvd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            dvd.DvdId = id;
            if(!_dvdRepo.GetDvdList().Any(d=>d.DvdId == dvd.DvdId))
            {
                return NotFound();
            }

            _dvdRepo.UpdateDvd(dvd);
            return Ok(dvd);
        }


        [Route("dvd/{id}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult DeleteDvd(int Id)
        {
            if (!_dvdRepo.GetDvdList().Any(d => d.DvdId == Id))
            {
                return NotFound();
            }

            _dvdRepo.DeleteDvd(Id);
            return Ok();
        }
    }
}
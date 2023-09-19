using Curewell.DAL;
using Curewell.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Curewell.Backend.Controllers
{
    [RoutePrefix("api/home")]
    public class HomeController : ApiController
    {
        private readonly IDoctor _doctor = null;
        private readonly ISpecialization _specialization = null;
        private readonly ISurgery _surgery = null;
        public HomeController(IDoctor doctor,ISpecialization specialization, ISurgery surgery)
        {
            _doctor = doctor;
            _specialization = specialization;
            _surgery = surgery;
        }
        [HttpGet]
        [Route("getalldoctors")]
        public IHttpActionResult GetDoctors()
        {
            var dt = _doctor.GetAllDoctors();
            if (dt == null)
            {
                return NotFound();
            }
            return Ok(dt);
        }
        [HttpGet]
        [Route("getspecializations")]
        public IHttpActionResult GetSpecializations()
        {
            var dt = _specialization.GetAllSpecializations();
            if (dt == null)
            {
                return NotFound();
            }
            return Ok(dt);
        }
        [HttpGet]
        [Route("surgerytypefortoday")]
        public IHttpActionResult GetAllSurgeryTypeForToday()
        {
            var dt = _surgery.GetAllSurgeryTypeForToday();
            if (dt == null)
            {
                return NotFound();
            }
            return Ok(dt);
        }

        [HttpPost]
        [Route("adddoctor")]
        public IHttpActionResult AddDoctor(Doctor doctor)
        {
            var dt = _doctor.AddDoctor(doctor);
            if (dt == false)
            {
                return NotFound();
            }
            return Ok(dt);
        }

        [HttpPut]
        [Route("updatedoctor")]
        public IHttpActionResult UpdateDoctorDetails(Doctor doctor)
        {
            var dt = _doctor.UpdateDoctorDetails(doctor);
            if (dt == false)
            {
                return NotFound();
            }
            return Ok(dt);
        }
    }
}

using Curewell.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curewell.DAL
{
    public interface ISpecialization
    {
        List<Specialization> GetAllSpecializations();
        List<DoctorSpecialization> GetDoctorsBySpecialization(string specializationCode);
    }
}

using Curewell.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curewell.DAL
{
    public interface IDoctor
    {
        bool AddDoctor(Doctor dObj);
        List<Doctor> GetAllDoctors();
        bool UpdateDoctorDetails(Doctor dObj);
        List<DoctorSpecialization> GetDoctorsBySpecialization(string specializationCode);

    }
}

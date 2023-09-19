using Curewell.DAL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Curewell.DAL
{
    public class CureWellRepository : IDoctor,ISpecialization,ISurgery
    {
        private SqlConnection _connection = null;
        private SqlCommand _command = null;
        private SqlDataReader _reader = null;
        public CureWellRepository() { }

        public bool AddDoctor(Doctor dObj)
        {
            int res;
            using (_connection = new SqlConnection(SqlConnectionString.GetConnectionString()))
            {
                using (_command = new SqlCommand("usp_addDoctor", _connection))
                {
                    if (_connection.State != ConnectionState.Open)
                    {
                        _connection.Open();
                    }
                    _command.CommandType = CommandType.StoredProcedure;
                    _command.Parameters.AddWithValue("@doctorName", dObj.DoctorName);
                    res = _command.ExecuteNonQuery();
                    return res > 0;
                }
            }
        }

        public List<Doctor> GetAllDoctors()
        {
            List<Doctor> doctors = new List<Doctor>();
            using (_connection = new SqlConnection(SqlConnectionString.GetConnectionString()))
            {
                using (_command = new SqlCommand("Select * from Doctor", _connection))
                {
                    if (_connection.State != System.Data.ConnectionState.Open)
                    {
                        _connection.Open();
                    }

                    using (_reader = _command.ExecuteReader())
                    {
                        if (_reader.HasRows)
                        {
                            while (_reader.Read())
                            {
                                doctors.Add(new Doctor
                                {
                                    DoctorId = Convert.ToInt32(_reader.IsDBNull(0) ? 0 : _reader.GetValue(0)),
                                    DoctorName = _reader.IsDBNull(1) ? string.Empty : _reader.GetValue(1).ToString()
                                });
                            }
                        }
                    }
                }
            }
            return doctors;
        }

        public List<Specialization> GetAllSpecializations()
        {
            List<Specialization> specializations = new List<Specialization>();
            using (_connection = new SqlConnection(SqlConnectionString.GetConnectionString()))
            {
                using (_command = new SqlCommand("Select * from Specialization", _connection))
                {
                    if (_connection.State != System.Data.ConnectionState.Open)
                    {
                        _connection.Open();
                    }

                    using (_reader = _command.ExecuteReader())
                    {
                        if (_reader.HasRows)
                        {
                            while (_reader.Read())
                            {
                                specializations.Add(new Specialization
                                {
                                    SpecializationCode = _reader.IsDBNull(0) ? string.Empty : _reader.GetValue(0).ToString(),
                                    SpecializationName = _reader.IsDBNull(1) ? string.Empty : _reader.GetValue(1).ToString()
                                });
                            }
                        }
                    }
                }
            }
            return specializations;
        }

        public List<Surgery> GetAllSurgeryTypeForToday()
        {
            List<Surgery> surgeryForToday = new List<Surgery>();
            using (_connection = new SqlConnection(SqlConnectionString.GetConnectionString()))
            {
                using (_command = new SqlCommand("Select * from Surgery WHERE SurgeryDate = CAST(GETDATE() AS DATE)", _connection))
                {
                    if (_connection.State != System.Data.ConnectionState.Open)
                    {
                        _connection.Open();
                    }

                    using (_reader = _command.ExecuteReader())
                    {
                        if (_reader.HasRows)
                        {
                            while (_reader.Read())
                            {
                                surgeryForToday.Add(new Surgery
                                {
                                    SurgeryCategory = _reader.IsDBNull(5) ? string.Empty : _reader.GetValue(5).ToString(),
                                    DoctorId = Convert.ToInt32(_reader.IsDBNull(1) ? 0 : _reader.GetValue(1)),
                                    SurgeryId = Convert.ToInt32(_reader.IsDBNull(0) ? 0 : _reader.GetValue(0)),
                                    SurgeryDate = Convert.ToDateTime(_reader.GetValue(2)),
                                    EndTime = Convert.ToDecimal(_reader.GetValue(4)),
                                    StartTime = Convert.ToDecimal(_reader.GetValue(3))
                                });
                            }
                        }
                    }
                }
            }
            return surgeryForToday;
        }

        public List<DoctorSpecialization> GetDoctorsBySpecialization(string specializationCode)
        {
            throw new NotImplementedException();
        }

        public bool UpdateDoctorDetails(Doctor dObj)
        {
            int res;
            using (_connection = new SqlConnection(SqlConnectionString.GetConnectionString()))
            {
                using (_command = new SqlCommand("usp_updateDoctor", _connection))
                {
                    if (_connection.State != ConnectionState.Open)
                    {
                        _connection.Open();
                    }
                    _command.CommandType = CommandType.StoredProcedure;
                    _command.Parameters.AddWithValue("@doctorId", dObj.DoctorId);
                    _command.Parameters.AddWithValue("@doctorName", dObj.DoctorName);
                    res = _command.ExecuteNonQuery();
                    return res > 0;
                }
            }
        }

        public bool UpdateSurgery(Surgery SObj)
        {
            throw new NotImplementedException();
        }
    }
}

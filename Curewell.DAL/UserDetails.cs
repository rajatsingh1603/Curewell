using Curewell.DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curewell.DAL
{
    public class UserDetails : IAccount
    {
        public Task<User> ValidateUserAsync(string username, string password)
        {
            return Task.Run(() =>
            {
                using (SqlConnection connection = new SqlConnection(SqlConnectionString.GetConnectionString()))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter("Select * from [User]", connection))
                    {
                        using (DataSet ds = new DataSet())
                        {
                            adapter.Fill(ds, "Users");
                            return ds.Tables[0].AsEnumerable()
                                .Select(u => new User
                                {
                                    Email = u.Field<string>("email"),
                                    Password = u.Field<string>("Password"),
                                    Type = u.Field<string>("type"),
                                    Name = u.Field<string>("Name"),
                                })
                                .FirstOrDefault(x => x.Email == username && x.Password == password);
                        }
                    }
                }
            });
        }
    }
}

using Curewell.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curewell.DAL
{
    public interface IAccount
    {
        Task<User> ValidateUserAsync(string username, string password);
    }
}

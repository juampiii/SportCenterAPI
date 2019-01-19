using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportCenterAPI.Models.Manager
{
    /// <summary>
    /// Describes basic operation of a manager used to perform diferent operations over the collection of <see cref="User"/> in the Sport Center
    /// </summary>
    public interface IUserManager : IManager<User>
    {
    }
}

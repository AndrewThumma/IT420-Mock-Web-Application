using IT420.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT420.Data.UserData
{
    interface IUserData
    {
        UserProfile GetUserById(int id);
        void Add(UserProfile newUser);
        void Delete(UserProfile user);
        void Update(UserProfile updatedUser);
        Task<bool> Commit();
    }
}

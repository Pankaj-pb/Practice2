using HRMTS.Common.Repository;
using System.Collections.Generic;

namespace HRMTS.Common.Services.User
{
    public static class UserServices
    {
        private static UserRepository userDAL = new UserRepository();

        public static List<HRMTS.Common.Model.User> GetUsers()
        {
            return userDAL.GetUsers();
        }
    }
}

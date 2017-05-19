using HRMTS.Chi.Extensions;
using HRMTS.Chi.Utilities;
using HRMTS.Common.Model;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace HRMTS.Common.Repository
{
    public class UserRepository
    {
        public List<User> GetUsers()
        {
            string query = "Select Id,UserName,FirstName,LastName from Core_Users";
            var parameters = new List<SqlParameter>();
            var userList = new List<User>();
            using (var chiDataReader = SqlUtils.GetDataReader(ConfigurationManager.ConnectionStrings["HRMTS"].ConnectionString, query, parameters))
            {
                while (chiDataReader.Read())
                {
                    userList.Add(SqlDataReaderToUser(chiDataReader.Reader));
                }
            }
            return userList;
        }

        private User SqlDataReaderToUser(DbDataReader chiDataReader)
        {
            User user = new User();
            user.FirstName = chiDataReader.ReadColumnAsString("FirstName");
            return user;
        }
    }
}

using SunTest.Orm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunTest.Security
{
    public class ApiSecurity
    {

        public static bool Login(string username, string password)
        {
            using (SunExpressEntities context = new SunExpressEntities())
            {

                return context.ApiUsers.
                    Any(user => user.UserName.Equals(username,StringComparison.OrdinalIgnoreCase) 
                              & user.Password == password);

            }

        }

            

    }
}

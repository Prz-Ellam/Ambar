using Cassandra.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambar.Model.DTO;

namespace Ambar.Model.DAO
{
    class AdministratorDAO : CassandraConnection
    {

        public AdministratorLoginDTO Login(string username, string password)
        {
            string query = @"SELECT USER_NAME, PASSWORD FROM ADMINISTRATORS_LOGIN WHERE USER_NAME = '{0}'
                            AND PASSWORD = '{1}';";
            query = string.Format(query, username, password);

            AdministratorLoginDTO user;
            try
            {
                user = mapper.Single<AdministratorLoginDTO>(query);
            }
            catch (Exception e)
            {
                user = null;
            }

            return user;
        }

    }
}

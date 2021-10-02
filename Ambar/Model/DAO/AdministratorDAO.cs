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

        public AdministratorDTO Login(string username, string password)
        {
            string query = string.Format("SELECT USER_NAME, PASSWORD FROM ADMINISTRATORS_LOGIN WHERE USER_NAME = " +
                "'{0}';", username);

            IMapper mapper = new Mapper(session);
            AdministratorDTO user;

            try
            {
                user = mapper.Single<AdministratorDTO>(query);

                if (user.Password != password)
                {
                    user = null;
                }

            }
            catch (System.InvalidOperationException e)
            {
                user = null;
            }

            return user;
        }


    }
}

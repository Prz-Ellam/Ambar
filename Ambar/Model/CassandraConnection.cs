using Cassandra;
using Cassandra.Mapping;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.Model
{
    public class CassandraConnection
    {
        protected static string dbServer { get; set;} 
        protected static string dbKeyspace { get; set; }
        protected static Cluster cluster { get; set; }
        protected static ISession session { get; set; }
        protected static IMapper mapper { get; set; }

        public CassandraConnection()
        {
            if (dbServer == null || dbKeyspace == null)
            {
                Connect();
            }
        }

        protected static void Connect()
        {
            dbServer = ConfigurationManager.AppSettings["cassandra_home"].ToString();
            dbKeyspace = ConfigurationManager.AppSettings["keyspace"].ToString();
            cluster = Cluster.Builder().AddContactPoint(dbServer).Build();
            session = cluster.Connect(dbKeyspace);
            mapper = new Mapper(session);
        }

        public static void Disconnect()
        {
            cluster.Dispose();
        }

    }
}

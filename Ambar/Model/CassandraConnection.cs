using Cassandra;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambar.Model
{
    public abstract class CassandraConnection
    {
        protected static string dbServer { get; set;} 
        protected static string dbKeyspace { get; set; }
        protected static Cluster cluster { get; set; }
        protected static ISession session { get; set; }
        protected static void Connect()
        {
            if (dbServer == null)
            {
                dbServer = ConfigurationManager.AppSettings["cassandra_home"].ToString();
            }
            if (dbKeyspace == null)
            {
                dbKeyspace = ConfigurationManager.AppSettings["keyspace"].ToString();
            }

            cluster = Cluster.Builder().AddContactPoint(dbServer).Build();
            session = cluster.Connect(dbKeyspace);
        }

        protected static void Disconnect()
        {
            cluster.Dispose();
        }

        // Metodos CRUD
        /*
            Insert
            string.Format();
            session.Execute(query);

            rs = session.Execute(query);
            Find
            foreach(var row in rs) {
                row.GetValue<int>(campo);
            }    
         
        */


    }
}

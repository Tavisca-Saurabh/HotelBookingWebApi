using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelBookingApplication.DataAccess
{
    public class LoggerOperation
    {
        public void AddToCassendra(string message)
        {
            try
            {
                //--------------------------Cassandra----------------------------

                // Connect to the hotelservices keyspace on our cluster running at 127.0.0.1
                Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
                ISession session = cluster.Connect("hotelservices");

                //Prepare a statement once
                var ps = session.Prepare("INSERT INTO Log (ID, Message, Date) VALUES (?,?,?)");

                //...bind different parameters every time you need to execute
                var statement = ps.Bind(Guid.NewGuid(), message, DateTime.Now.ToString());
                //Execute the bound statement with the provided parameters
                session.Execute(statement);
            }
            catch (Exception exc)
            {
            }
        }
    }
}
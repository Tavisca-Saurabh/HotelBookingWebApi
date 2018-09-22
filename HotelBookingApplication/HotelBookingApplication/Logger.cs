using Cassandra;
using HotelBookingApplication.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace HotelBookingApplication
{
    sealed class Logger
    {
        /*
         * Private property initilized with null
         * ensures that only one instance of the object is created
         * based on the null condition
         */
        private static Logger instance = null;

        /*
         * public property is used to return only one instance of the class
         * leveraging on the private property
         */
        public static Logger GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new Logger();
                return instance;
            }
        }
        /*
         * Private constructor ensures that object is not
         * instantiated other than with in the class itself
         */
        private Logger()
        {

        }
        /*
         * Public method which can be invoked through the singleton instance
         */
        public void SaveInToLogFile(string message)
        {
            LoggerOperation Log = new LoggerOperation();
            Log.AddToCassendra(message);
        }
    }
}
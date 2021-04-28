using System;

namespace DesignPatterns.CreationalPatterns.Singleton
{
    /*
     *  Singleton is a creational design pattern that lets you ensure
     *  that a class has only one instance, while providing a global
     *  access point to this instance.
     *  
     *  PROS:
     *  - Ensure that a class has only a single instance.
     *  - Get a global access point to that instance.
     *  - The singleton is initialized only once, when requested for the first time.
     *  CONS:
     *  - May mask bad design (the components of the program know too much about each other.
     *  - Special treatment in a multithreaded environment.
     *  - Difficult to unit test (test frameworks rely on inheritance for mocking objects).
     */

    // Singleton class.
    class Database
    {
        private static Database Db; // The unique instance shared through the program.

        // For thread safety, will lock on the following _dbLock object.
        private static readonly object DbLock = new object();

        private Database()
        {
            // Some initialization, constructor must be private.
            // It will be used once, when creating the singleton instance of Database.
        }

        public static Database GetInstance()
        {
            lock (DbLock)
            {
                if (Db == null)
                {
                    Db = new Database();
                }
            }

            return Db;
        }

        public void Query(string s)
        {
            Console.WriteLine(s);
        }
    }

    static class Sample
    {
        public static void Do()
        {
            Database db1 = Database.GetInstance();
            db1.Query("SELECT ...");

            Database db2 = Database.GetInstance();
            db2.Query("SELECT ...");
        }
    }
}

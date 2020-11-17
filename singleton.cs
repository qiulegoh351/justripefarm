using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI___Multi_From_and_Panel
{
    class singleton
    {
        private static singleton instance;

        private singleton()
        {
            //initialise the objects
            Console.WriteLine("Singleton constructor is called");
        }

        public static singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    Console.WriteLine("The unique Singleton object will be created");
                    instance = new singleton();
                    Console.WriteLine("The Singleton object was created");
                }

                return instance;
            }
        }

        public void print()
        {
            Console.WriteLine("I'm a method from Singleton");
        }
    }
}

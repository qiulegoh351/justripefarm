using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI___Multi_From_and_Panel
{
    class singleton
    {
        private static singleton instance;

        private singleton()
        {
            //initialise the objects
            MessageBox.Show("Singleton constructor is called");
        }

        public static singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    MessageBox.Show("The unique Singleton object will be created");
                    instance = new singleton();
                    MessageBox.Show("The Singleton object was created");
                }

                return instance;
            }
        }

        public void print()
        {
            MessageBox.Show("I'm a method from Singleton");
        }
    }
}

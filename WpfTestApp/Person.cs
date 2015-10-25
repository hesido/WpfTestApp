using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTestApp
{
    class Person
    {

        public Person(string Name = "New Person", string Occupation = "Job Name")
        {
            this.Name = Name;
            this.Occupation = Occupation;
        }

        public string Name
        {
            get; set;
        }

        public string Occupation
        {
            get; set;
        }
    }
}

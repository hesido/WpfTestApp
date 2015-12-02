using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTestApp
{
    class Person : SelectableItem
    {

        public Person(string setName = "New Person", string setOccupation = "Job Name")
        {
            Name = setName;
            Occupation = setOccupation;
            Hobbard = new Hobby();
            Hobbard.Expense = "sompre";
            Hobbard.HobbyType = "shulteck";
        }

        public Hobby Hobbard
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public string Occupation
        {
            get; set;
        }

        public class Hobby
        {
            public string HobbyType
            {
                get; set;
            }

            public string Expense
            {
                get; set;
            }

        }

        //public override string ToString()
        //{
        //    return Name;
        //}
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTestApp
{

    static class Rules {
        //static public Dictionary<int, Delegate[]> MarkPerson = new Dictionary<int, Delegate[]>() {
        //    { 2, new Delegate[] {new test(2), new testDel(2) } }
        //};

        //static public Dictionary<int, string[]> MarkPerson2 = new Dictionary<int, string[]>() {
        //    { 2, new string[] { "A", "B" } }
        //};

        //static public Dictionary<int, string[]> MarkPerson3 = new Dictionary<int, string[]>() {
        //    [2] = new string[] {"a", "b"},

        //};

        //public delegate bool testDel(Person P);

        //static public testDel funk = new testDel(test);

        //static bool test(Person p)
        //{
        //    return p.Comfort>5;
        //}

        //static bool best(Person p)
        //{
        //    return p.Age<20;
        //}

    }



    public class Person : SelectableItem
    {

        public Person(string setName = "New Person", string setOccupation = "Job Name")
        {
            Name = setName;
            Occupation = setOccupation;
        }

        public string Name
        {
            get; set;
        }

        public string Occupation
        {
            get; set;
        }

        public int Age
        {
            get; set;
        }

        public int Comfort
        {
            get; set;
        }

        public int Type
        {
            get; set;
        }

        public bool IsSelected
        {
            get; set;
        }

        //public bool IsSelected
        //{
        //    get; set;
        //}

        //public override string ToString()
        //{
        //    return Name;
        //}
    }

}

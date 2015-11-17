using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTestApp
{
    class People : ObservableCollection<Person>
    {
        private static int countIndex = 0;

        public People()
        {
            //nothing to see here.
        }

        public People(List<Person> personList) : base(personList)
        {
            //Accomodate base constructor to create an observable collection out of a list
        }


        public Person addPerson() {
            Person newPerson = new Person() { Name = String.Format("{0}abe {1}", (char)('A' + new Random().Next(0, 26)), new Random().Next(1000,5000).ToString() ), Occupation = "Job " + (++countIndex) };
            this.Add(newPerson);
            return newPerson;
            }
        public void removePerson(Person toRemove) {
            if(this.Contains(toRemove)) this.Remove(toRemove);
        }

    }
}

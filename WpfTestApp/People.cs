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

        public People()
        {
            //nothing to see here.
        }

        public Person addPerson() {
            Person newPerson = new Person() { Name = "Abe" + new Random().Next().ToString() };
            this.Add(newPerson);
            return newPerson;
            }
        public void removePerson(Person toRemove) {
            if(this.Contains(toRemove)) this.Remove(toRemove);
        }

    }
}

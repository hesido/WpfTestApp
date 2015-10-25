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

        }

        public Person addPerson() {
            Person newPerson = new Person();
            this.Add(newPerson);
            return newPerson;
            }
        public void removePerson(Person toRemove) {
            Console.WriteLine(toRemove);
            if(this.Contains(toRemove)) this.Remove(toRemove);
        }

    }
}

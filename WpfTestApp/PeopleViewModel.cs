using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace WpfTestApp
{
    class PeopleViewModel : PeopleViewModelEntity
    {

        private WPFCommand _removeSelectedPersonCommand;
        private WPFCommand _removePersonCommand;

        public WPFCommand RemoveSelectedPersonCommand
        {
            get { return _removeSelectedPersonCommand; }
        }
        public WPFCommand RemovePersonCommand
        {
            get { return _removePersonCommand; }
        }

        public PeopleViewModel()
        {
            _removeSelectedPersonCommand = new WPFCommand(new Action(removeSelectedPersonAction));
            _removePersonCommand = new WPFCommand(new Action<object>(removePersonAction), x => PeopleList.Count > 0);
        }


        protected People _peopleList = new People();

        public People PeopleList
        {
            get { return _peopleList; }
            set { _peopleList = value; }
        }

        protected Person _selectedPerson = null;

        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set {
                if (_selectedPerson != value)
                {
                    _selectedPerson = value;
                    Console.WriteLine("Selected Person {0}", SelectedPerson.Occupation);
                }
            }

        }

        //public Action addPersonAction = PeopleViewModel.addPerson();

        public void addPerson()
        {
            //Person newPerson = new Person() { Name = "New Person", Occupation = "Job" };
            //PeopleList.Add(newPerson);
            //SelectedPerson = newPerson;
            SelectedPerson = PeopleList.addPerson();
        }


        public void removeSelectedPersonAction()
        {
            PeopleList.removePerson(SelectedPerson);
            if (PeopleList.Count > 0)
                SelectedPerson = PeopleList[0];
            else
                SelectedPerson = null;
        }

        public void removePersonAction(object toRemove)
        {
            Console.WriteLine("Removing '{1}' {0}", PeopleList.Count, toRemove);
            PeopleList.removePerson((Person)toRemove); //unfortunately, casting is needed.
           // PeopleList.removePerson(SelectedPerson); //unfortunately, casting is needed.
            if (PeopleList.Count > 0)
                SelectedPerson = PeopleList[0];
            else
                SelectedPerson = null;
            Console.WriteLine("Removing {0}", PeopleList.Count);
            RemovePersonCommand.RaiseCanExecuteChanged();

        }

    }
}

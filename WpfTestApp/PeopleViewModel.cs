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

        private WPFCommand _removePersonCommand;

        public PeopleViewModel()
        {
            _removePersonCommand = new WPFCommand(new Action<object>(removeSelectedPersonAction));
        }

        public WPFCommand RemovePersonCommand
        {
            get { return _removePersonCommand; }
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
                    NotifyPropertyChanged("SelectedPerson");
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

       public void removeSelectedPerson()
        {
            return;
            //if (_selectedPerson != null)
            //{
                PeopleList.removePerson(SelectedPerson);
                if (PeopleList.Count > 0)
                    SelectedPerson = PeopleList[0];
                else
                    SelectedPerson = null;
            //}
        }

        public void removeSelectedPersonAction(object dummy = null)
        {
            //if (_selectedPerson != null)
            //{
            PeopleList.removePerson(SelectedPerson);
            if (PeopleList.Count > 0)
                SelectedPerson = PeopleList[0];
            else
                SelectedPerson = null;
            //}
        }
    }
}

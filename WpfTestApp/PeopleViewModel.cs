﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Data;
using System.ComponentModel;

namespace WpfTestApp
{
    class PeopleViewModel : PeopleViewModelEntity
    {

        private WPFCommand _removePersonCommand;
        private WPFCommand _addPersonCommand;
        private WPFCommand _filterPeopleCommand;

        public PeopleViewModel()
        {
            _removePersonCommand = new WPFCommand(new Action<object> (removePersonAction), x => PeopleList.Count > 0);
            _addPersonCommand = new WPFCommand(() => { SelectedPerson = PeopleList.addPerson(); Console.WriteLine(CheckSelectedPeople.Count); }, null, false);
            _filterPeopleCommand = new WPFCommand(new Action(filterSelectedAction), null, false);
            //_peopleList.CollectionChanged += delegate(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) { _removePersonCommand.RaiseCanExecuteChanged(); };
        }

        public WPFCommand RemovePersonCommand
        {
            get { return _removePersonCommand; }
        }

        public WPFCommand AddPersonCommand
        {
            get { return _addPersonCommand; }
        }

        public WPFCommand FilterPeopleCommand
        {
            get { return _filterPeopleCommand; }
        }

        protected People _peopleList = new People();

        public People PeopleList
        {
            get { return _peopleList; }
           // set { _peopleList = value; }
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

        public void removeSelectedPersonAction()
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

        public void removePersonAction(object toRemove)
        {
            //if (_selectedPerson != null)
            //{

            Console.WriteLine((toRemove as Person).Name);
            var forRemoval = (toRemove as Person);
            int pos = Math.Max(PeopleList.IndexOf(forRemoval), 1);
            PeopleList.removePerson(forRemoval);
            SelectedPerson = (PeopleList.Count > pos - 1) ? PeopleList[pos - 1] : null;

        //    RemovePersonCommand.RaiseCanExecuteChanged();
            //}
        }

        private People _selectedPeople = new People();

        public People SelectedPeople
        {
            get { return _selectedPeople; }
            set { _selectedPeople = value; }
        }

        private People _checkSelectedPeople = new People();

        public People CheckSelectedPeople
        {
            get { return _checkSelectedPeople; }
            set { _checkSelectedPeople = value; }
        }


        public void filterSelectedAction()
        {
            _checkSelectedPeople = new People(PeopleList.Where((p) => p.IsSelected).ToList());
            NotifyPropertyChanged("CheckSelectedPeople");
        }
    }
}

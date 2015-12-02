using System;
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

        public WPFCommand RemovePersonCommand { get; set; }
        public WPFCommand AddPersonCommand { get; set; }
        public WPFCommand FilterPeopleCommand { get; set; }
        public WPFCommand TextFilterPeopleCommand { get; set; }
        public People CheckSelectedPeople { get; set; }

        public People PeopleList { get; set; }
        public People SelectedPeople { get; set; }
        public ListCollectionView filteredPeopleView { get; set; }
        public ListCollectionView TextFilteredPeopleView { get; set; }

        protected string _filterText = "";

        public string FilterText
        {
            get { return _filterText; }
            set
            {
                if (_filterText != value)
                {
                    _filterText = value;
                    Console.WriteLine("testeeee");
                    NotifyPropertyChanged("FilterText");
                    TextFilteredPeopleView.Refresh();
                }
            }
        }

        protected Person _selectedPerson = null;
        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                if (_selectedPerson != value)
                {
                    _selectedPerson = value;
                    NotifyPropertyChanged("SelectedPerson");
                }
            }
        }

        public PeopleViewModel()
        {
            PeopleList = new People();
            SelectedPeople = new People();
            CheckSelectedPeople = new People();
            RemovePersonCommand = new WPFCommand(new Action<object> (removePersonAction), x => PeopleList.Count > 0);
            AddPersonCommand = new WPFCommand(() => { SelectedPerson = PeopleList.addPerson(); Console.WriteLine(CheckSelectedPeople.Count); }, null, false);
            FilterPeopleCommand = new WPFCommand(new Action(filterSelectedAction), null, false);
            TextFilterPeopleCommand = new WPFCommand(new Action(() => TextFilteredPeopleView.Refresh()), null, false);

            filteredPeopleView = new ListCollectionView(PeopleList);
            filteredPeopleView.Filter = (p) => !((Person)p).IsSelected;

            filteredPeopleView.LiveFilteringProperties.Add("IsSelected");
            filteredPeopleView.IsLiveFiltering = true;

            TextFilteredPeopleView = new ListCollectionView(PeopleList);
            TextFilteredPeopleView.Filter = (p) => ((Person)p).Name.ToUpper().Contains(FilterText.ToUpper());

            //TextFilteredPeopleView.LiveFilteringProperties.Add("Name");
            //TextFilteredPeopleView.IsLiveFiltering = true;

            //_peopleList.CollectionChanged += delegate(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) { _removePersonCommand.RaiseCanExecuteChanged(); };
        }



        //public Action addPersonAction = PeopleViewModel.addPerson();

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
 //           Console.WriteLine((toRemove as Person).Name);
            var forRemoval = (toRemove as Person);
            int pos = Math.Max(PeopleList.IndexOf(forRemoval), 1);
            PeopleList.removePerson(forRemoval);
            SelectedPerson = (PeopleList.Count > pos - 1) ? PeopleList[pos - 1] : null;
        //    RemovePersonCommand.RaiseCanExecuteChanged();
            //}
        }

        public void filterSelectedAction()
        {
            CheckSelectedPeople = new People(PeopleList.Where((p) => p.IsSelected).ToList());
            NotifyPropertyChanged("CheckSelectedPeople");
            //filteredPeopleView.Refresh();//force refresh for view for when livefiltering is not on
            Console.WriteLine(PeopleList.Count);
        }
    }
}
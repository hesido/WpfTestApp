using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Data;
using System.ComponentModel;
using WpfTestApp;

namespace WpfTestApp
{
    class PeopleViewModel : PeopleViewModelEntity
    {

        private WPFCommand _removePersonCommand;
        private WPFCommand _addPersonCommand;
        private WPFCommand _filterPeopleCommand;


        public delegate bool testDel(Person P);
        //public delegate Func<T> multiDel(Person P, int lim);


        public delegate Tunc<T> Tunc<T>(T obj);


        public delegate bool EvaluatePerson<Person>(Person P);


        public Dictionary<string, Func<int, Predicate<Person>>> evalRules = new Dictionary<string, Func<int, Predicate<Person>>>()
        {
            ["AgeGreaterThan"] = new Func<int, Predicate<Person>>((int Limit)=> (Person P) => P.Age > Limit),
            ["AgeLessThan"] = new Func<int, Predicate<Person>>((int Limit) => (Person P) => P.Age < Limit),
        };

        static Predicate<Person> doom(int limit)
        {
            return ((Person P) => P.Age > limit);
        }

        static Predicate<Person> goom(int limit)
        {
            return ((Person P) => P.Comfort > limit);
        }

        Tunc<T> MyFunc<T>(T obj)
        {
            Console.WriteLine(obj);
            return MyFunc;
        }

        static bool test(Person p)
        {
            Console.Write("atest ");
            return p.Comfort > 3;
        }

        static bool best(Person p)
        {
            Console.Write("besta ");
            return p.Age < 45;
        }

        public PeopleViewModel()
        {
            
            _removePersonCommand = new WPFCommand(new Action<object> (removePersonAction), x => PeopleList.Count > 0);
            _addPersonCommand = new WPFCommand(() => {
                SelectedPerson = PeopleList.addPerson();
            }, null, false);
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
                    //var pd = PredicateBuilder.True<Person>();

                    //pd = pd.And((Person p) => p.Comfort > 4);
                    //pd = pd.And((Person p) => p.Age < 20);
                    //var meine = new testDel(test);
                    //var deine = new testDel(best);


                    //Console.WriteLine(meine(SelectedPerson) && deine(SelectedPerson));

                    //MyFunc(3)(4)(2);
                    //var preComb = new EvaluatePerson<Person>(doom(20));
                    //var treComb = new EvaluatePerson<Person>(goom(5));


                    //Console.WriteLine(preComb(SelectedPerson) && treComb(SelectedPerson));

                    var moCap = evalRules["AgeGreaterThan"](15);
                    var toCap = evalRules["AgeLessThan"](20);

                    Console.WriteLine($"{moCap(SelectedPerson)} aw {toCap(SelectedPerson)}");

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

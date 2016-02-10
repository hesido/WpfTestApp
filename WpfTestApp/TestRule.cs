using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WpfTestApp
{
    public class TestRule
    {
        private int? AgeBiggerOrEqual;
        private int? AgeSmaller;
        private int? ComfortBiggerOrEqual;
        private int? ComfortLessThan;

        public TestRule(int? _AgeBiggerOrEqual = null, int? _AgeSmaller = null, int? _ComfortBiggerOrEqual = null, int? _ComfortLessThan = null)
        {
            _AgeBiggerOrEqual = AgeBiggerOrEqual;
            _AgeSmaller = AgeSmaller;
            _ComfortBiggerOrEqual = ComfortBiggerOrEqual;
            _ComfortLessThan = ComfortLessThan;
        }
    }

    public static class PanicRules
    {
        public static Dictionary<string, Func<int, Expression<Func<Person, bool>>>> PredicateLibrary = new Dictionary<string, Func<int, Expression<Func<Person, bool>>>>()
        {
            ["AgeGTO"] = new Func<int, Expression<Func<Person, bool>>>((int vaL)=> (Person P) => P.Age >= vaL),
            ["AgeLT"] = new Func<int, Expression<Func<Person, bool>>>((int vaL) => (Person P) => P.Age < vaL),
            ["ComfortGTO"] = new Func<int, Expression<Func<Person, bool>>>((int vaL) => (Person P) => P.Comfort >= vaL),
            ["ComfortLT"] = new Func<int, Expression<Func<Person, bool>>>((int vaL) => (Person P) => P.Comfort < vaL),
        };

        public static Dictionary<int, Dictionary<string, int>[]> RuleList = new Dictionary<int, Dictionary<string, int>[]>()
        {
            [1] = new Dictionary<string, int>[]
            {
                new Dictionary<string, int>() {["AgeGTO"] = 20,["ComfortLT"] = 5 }
            },
            [2] = new Dictionary<string, int>[]
            {
                new Dictionary<string, int>() {["ComfortGTO"] = 3 }
            },
            [3] = new Dictionary<string, int>[]
            {
                new Dictionary<string, int>() {["AgeLT"] = 30},
                new Dictionary<string, int>() {["ComfortGTO"]= 5}
            }
        };

        public static Dictionary<int, Func<Person, bool>> CompiledRules = new Dictionary<int, Func<Person, bool>>();

        public static void CompileRules()
        {

            foreach(KeyValuePair<int, Dictionary<string, int>[]> Rule in RuleList)
            {
                var Predicate = PredicateBuilder.False<Person>();

                foreach(Dictionary<string, int> RuleItem in Rule.Value)
                {
                    var PredicateSub = PredicateBuilder.True<Person>();

                    foreach(KeyValuePair<string, int> RuleItemCriteria in RuleItem)
                    {

                        //var s = PredicateLibrary[RuleItemCriteria.Key](RuleItemCriteria.Value);
                        //PredicateSub = PredicateSub.And((Person p)=> 5 > 4);
                        PredicateSub = PredicateSub.And(PredicateLibrary[RuleItemCriteria.Key](RuleItemCriteria.Value));
                    }

                    Predicate = Predicate.Or(PredicateSub);
                }

                CompiledRules.Add(Rule.Key, Predicate.Compile());

            }
        }

    }

}

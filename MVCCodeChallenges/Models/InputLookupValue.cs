using System.Data.Entity;

namespace MVCCodeChallenges.Models
{
    // represents a group of static lookup values associated with a UI form input, e.g. dropdown values. 
    public class InputLookupValue : DbContext
    {
        // PK
        public int InputLookupValueId { get; set; }
        
        // FK to the parent table -- all matches for this ID in the parent table become the values for that input
        public int GroupId { get; set; }

        // the InputName provides another way to match the values to a particular input, i.e. the InputNameAttr of the ChallengeInput table
        public string InputName { get; set; }
        
        public int Sequence { get; set; }
        public string Value { get; set; }
        public string Display { get; set; }
    }
}
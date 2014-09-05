using System.Data.Entity;

namespace MVCCodeChallenges.Models
{
    // CURRENTLY NOT USED - here for future reference only (input validation is currently handled by each IChallenge concrete class)
    // represents custom validation that can be attached any dynamically-generated Input obj, including which server-side function to run
    public class Validation : DbContext
    {
        // PK
        public int ValidationId { get; set; }

        public string ValidationFunctionName { get; set; }
    }
}

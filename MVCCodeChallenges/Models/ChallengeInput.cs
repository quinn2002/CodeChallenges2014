using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace MVCCodeChallenges.Models
{
    // represents a dynamically-generated UI input field for a CodeChallenege
    public class ChallengeInput : DbContext
    {
        // PK
        public int ChallengeInputId { get; set; }

        public string InputElement { get; set; }
        public string InputNameAttr { get; set; }
        public string InputTypeAttr { get; set; }

        // FKs listed here to make updates simpler/more efficient - marked virtual for lazy loading efficiencies
        public int ChallengeId { get; set; }
        public virtual Challenge Challenge { get; set; }

        // FK NOTE: These validation-related props are NOT CURRENTLY USED - here for future reference only (input validation is currently handled by each IChallenge concrete class)
        public int? ValidationId { get; set; }
        public virtual Validation Validation { get; set; }
        public string ValidationErrorMsg { get; set; }

        public int Sequence { get; set; }
        public string InstructionText { get; set; }

        // input lookup values
        [ForeignKey("GroupId")]
        public ICollection<InputLookupValue> InputLookupValues { get; set; }
    }
}

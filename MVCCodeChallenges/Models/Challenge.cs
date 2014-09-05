using System.Collections.Generic;
using System.Data.Entity;

namespace MVCCodeChallenges.Models
{
    // represents a CodeChallenge obj
    public class Challenge : DbContext
    {
        // PK
        public int ChallengeId { get; set; }

        // ClassPath is needed for dynamic class instantiation (e.g. CodeChallengesBL.ConcreteClasses.CodeChallenge01_NumStringAdder,CodeChallengesBL) - MUST BE fully qualified path, including dll
        public string ClassPath { get; set; }
        public int Sequence { get; set; }
        public string Name { get; set; }
        public string UriTitle { get; set; }
        public string Description { get; set; }
        public string ImageFilenameNoExtension { get; set; }

        // dynamically-generated user input fields
        public ICollection<ChallengeInput> ChallengeInputs { get; set; }
    }
}
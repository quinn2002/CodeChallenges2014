using System.Collections.Generic;
using System.Collections.Specialized;

namespace CodeChallengesBL.Interfaces
{
    public interface ICodeChallenge
    {
        string OutputResult(OrderedDictionary inputValues);
    }
}

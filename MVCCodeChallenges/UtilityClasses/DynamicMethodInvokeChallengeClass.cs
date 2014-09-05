using CodeChallengesBL.Interfaces;
using System;
using System.Collections.Specialized;

namespace MVCCodeChallenges.UtilityClasses
{
    public static class DynamicMethodInvokeChallengeClass
    {
        public static string GetResults(string challengeClassPath, OrderedDictionary userVals)
        {
            Type type = Type.GetType(challengeClassPath, false);
            if (type != null)
            {
                ICodeChallenge challenge = Activator.CreateInstance(type) as ICodeChallenge;
                string output = challenge.OutputResult(userVals).ConvertNewLinesToHtmlLineBreaksPreserveSpace();
                return output;
            }
            else
            {
                return null;
            }
        }
    }
}
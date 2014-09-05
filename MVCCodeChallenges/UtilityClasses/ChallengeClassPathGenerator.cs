using MVCCodeChallenges.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCodeChallenges.UtilityClasses
{
    public static class ChallengeClassPathGenerator
    {
        public static string GetChallengeClassPath(int challengeId, List<Challenge> challenges)
        {
            var challengeObj = challenges.FirstOrDefault(c => c.ChallengeId == challengeId);
            string challengeClassPath = challengeObj == null ? "" : challengeObj.ClassPath;
            return challengeClassPath;
        }
    }
}
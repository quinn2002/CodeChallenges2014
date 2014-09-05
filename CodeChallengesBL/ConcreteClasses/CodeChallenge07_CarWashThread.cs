using CodeChallengesBL.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
Code Challenge #7
We haven’t done any thread programming questions yet so we’ll try one out this week.  If you haven’t ever worked with threads before, you should take the time and try this challenge this week.
 
Create a car wash with a single washing bay.  Your threads will be cars.  If the car wash bay is full, your car/thread needs to wait for it to become open.  If the car wash bay is empty your car can get washed.  You can assume that it takes 2 seconds to wash your car once you are in the washing bay.
 
Extra credit it you can create a solution that lines the cars/threads up in order so all cars get washed in order of appearance.
 
Please send solutions and/or questions to dan.bunker@stgutah.com and brett.child@stgutah.com this week.  Thanks and happy coding!
 
Dan
 
NOTE to code reviewer:  Unlike previous code challenges, I did look at the Java solution on this one beforehand just to kind of see what they were looking for, but I still tried to come up with my own solution.  Thanks!
 */


namespace CodeChallengesBL.ConcreteClasses
{
    public class CodeChallenge07_CarWashThread : ICodeChallenge
    {
        public string OutputResult(OrderedDictionary inputValues)
        {
            string userInput = inputValues[0].ToString();
            string[] userVals = userInput.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            
            List<string> cars = new List<string>(userVals);
            var outputString = new StringBuilder();
            //WashCars(cars, outputString); // couldn't get this working using tasks

            // Parallel equivalent
            Parallel.ForEach(cars, car => WashCar(car, cars, outputString));
            return outputString.ToString();
        }

        public static void WashCars(List<string> cars, StringBuilder outputString)
        {
            Action<object> action = (object car) =>
            {
                WashCar(car, cars, outputString);
            };

            foreach (string car in cars)
            {
                Task task = Task.Factory.StartNew(action, car);
            }
        }

        public static void WashCar(object car, List<string> cars, StringBuilder outputString)
        {
            var watch = new Stopwatch();
            watch.Start();
            while (cars.Count > 0 && cars[0] != car.ToString())
            {
                //sb.AppendLine(String.Format("Car {0} is waiting...", car));
            }

            if (cars.Count > 0 && cars[0] == car.ToString())
            {
                TimeSpan ts = watch.Elapsed;
                outputString.AppendLine(String.Format("NOW WASHING car {0} on thread {1} (task {2})", car, Thread.CurrentThread.ManagedThreadId, Task.CurrentId));

                Thread.Sleep(2000); // takes 2 seconds to wash the car
                ts = watch.Elapsed;
                outputString.AppendLine(String.Format("\nElapsed time: {1:#.##} seconds\nFINISHED WASHING car {0}.", car, ts.TotalSeconds));
                cars.RemoveAt(0);
            }
        }
    }
}

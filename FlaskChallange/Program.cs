using System;
using System.Linq;

namespace FlaskChallange
{
    class Program
    {
        static void Main(string[] args)
        {            
            var allIterations = BreadthFirstSearch.CalculateAllIterations(new FlaskProblemGraph(5,3));

            allIterations.Select(res =>
            {
                Console.WriteLine($"{res.Key} moves={res.Value}");
                return res;
            }).ToList();

            var goalVolume = 1;
            var noIterationsFor1l=allIterations
                .Where(n => n.Key.X == goalVolume || n.Key.Y == goalVolume)
                .OrderBy(n => n.Value).First().Value; ;

            goalVolume = 4;
            var noIterationsFor4l = allIterations
                .Where(n => n.Key.X == goalVolume || n.Key.Y == goalVolume)
                .OrderBy(n => n.Value).First().Value; ;

            Console.WriteLine($"The quickest way to get to 1 litre is {noIterationsFor1l} iterations");
            Console.WriteLine($"The quickest way to get to 4 litre is {noIterationsFor4l} iterations");
        }


    }
}

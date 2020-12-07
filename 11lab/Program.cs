using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11lab
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] monthes = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            string[] summerPlusWinter = {"December", "January","February", "June", "July", "August" };
            Console.WriteLine("Enter length of the string");
            int n = Convert.ToInt32(Console.ReadLine());

            var query1 = monthes.Where(p => p.Length == n);
            Console.WriteLine("Your monthes:");
            foreach(string str in query1)
            {
                Console.WriteLine(str);
            }

            Console.WriteLine("Summer and Winter monthes:");
            var query2 = monthes.Intersect<string>(summerPlusWinter);
            foreach (string str in query2)
            {
                Console.WriteLine(str);
            }

            var query3 = from alphabetOrder in monthes
                         orderby alphabetOrder
                         select alphabetOrder;
            Console.WriteLine("Your monthes:");
            foreach (string str in query3)
            {
                Console.WriteLine(str);
            }

            var query4 = from p in monthes
                         where p.Length >= 4 && p.Contains("u")
                         select p;
            Console.WriteLine("Your monthes which has length 4 and more and contains letter 'u':");
            foreach (string str in query4)
            {
                Console.WriteLine(str);
            }

            List<Train> trains = new List<Train>();
            Train firstTrain = new Train();
            Train secondTrain = new Train("Минск", 704, "06:33", 400);
            Train thirdTrain = new Train("Жодино", 606, "09:33", 200);
            Train forthTrain = new Train("Пацевичи", 705, "15:10", 400);
            Train fifthTrain = new Train("Солигорск", 601, "17:30", 220);
            Train sixthTrain = new Train("Брест", 708, "12:22", 420);
            Train seventhTrain = new Train("Гродно", 705, "15:10", 400);
            Train eighthTrain = new Train("Гомель", 602, "14:25", 270);

            trains.Add(firstTrain);
            trains.Add(secondTrain);
            trains.Add(thirdTrain);
            trains.Add(forthTrain);
            trains.Add(fifthTrain);
            trains.Add(sixthTrain);
            trains.Add(seventhTrain);
            trains.Add(eighthTrain);

            //Searching by destination
            Console.WriteLine("Enter destination you would like to find");
            string yourDestination = Console.ReadLine();

            var tr1 = from train in trains
                      where train.Destination.Contains(yourDestination)
                      select train;
            foreach (Train t in tr1)
            {
                t.Output();
            }

            //Search by destination and date
            Console.WriteLine("Enter destination you would like to find");
            yourDestination = Console.ReadLine();
            Console.WriteLine("Enter hours");
            int hour = Convert.ToInt32(Console.ReadLine());
            var tr2 = from train in trains
                      where train.Destination.Contains(yourDestination) & (train.hours <= hour)
                      select train;
            foreach (Train t in tr2)
            {
                t.Output();
            }
            var tr3 = trains.Where(p => p.Places >= 0);
            Train tt = tr3.Max();
            tt.Output();

            var tr4 = trains.OrderBy(p => p.Destination);
            foreach (Train t in tr4)
            {
                t.Output();
            }
            Console.WriteLine("5 trains by time");

            var tr5 = trains.OrderBy(p => p.Time);
            Train[] tArr = tr5.ToArray();
            tArr = tArr.Reverse().ToArray();
            var tr6 = tArr.Take(5);
            foreach (Train t in tr6)
            {
                t.Output();
            }
            Console.WriteLine("5 methods");

            var tr7 = from trs in trains
                      where (trs.Places >= 400)
                      orderby trs.Destination
                      select trs;
            Train MaxPlaces = tr7.Max();
            Console.WriteLine("Max Elem");

            MaxPlaces.Output();
            if (tr7.Contains(sixthTrain))
            {
                Console.WriteLine("tr7 contains train with destination to Brest");

            }
            foreach (Train t in tr7)
            {
                t.Output();
            }

            string[] Destinations = { "Брест", "Витебск", "Жодино", "Минск", "Пацевичи", "Солигорск" };
            int[] key = {5, 7};
            var sometype = Destinations.Join(key, w => w.Length, q => q, (w, q) => new
            {
                id = w,
                name = string.Format("{0} ", q)
            });
            foreach (var item in sometype)
                Console.WriteLine(item);
        }

    }
}

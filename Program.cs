using System;
using System.Collections.Generic;
using System.Linq;

namespace Gigs
{
    class Program
    {
        static void Main(string[] args)
        {


            var events = new List<Event>{
                 new Event{ Name = "Phantom of the Opera", City = "New York"},
                 new Event{ Name = "Metallica", City = "Los Angeles"},
                 new Event{ Name = "Metallica", City = "New York"},
                 new Event{ Name = "Metallica", City = "Boston"},
                 new Event{ Name = "LadyGaGa", City = "New York"},
                 new Event{ Name = "LadyGaGa", City = "Boston"},
                 new Event{ Name = "LadyGaGa", City = "Chicago"},
                 new Event{ Name = "LadyGaGa", City = "San Francisco"},
                 new Event{ Name = "LadyGaGa", City = "Washington"}
            };


            var customer = new Customer { Name = "Mr. Fake", City = "New York", MaxGigs=5 };

            var eve = new Event();
            var allAvailableGigs = eve.GetGigs(customer, events);

            foreach (var item in allAvailableGigs)
            {
                eve.AddToEmail(customer, item);
            }

        }
    }

}

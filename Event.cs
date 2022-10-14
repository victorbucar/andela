using System;
using System.Collections.Generic;
using System.Linq;

namespace Gigs
{
    public class Event
    {
    public string Name { get; set; }
    public string City { get; set; }


        public void AddToEmail(Customer c, Event e, int? price = null)
        {
            //var distance = GetDistance(c.City, e.City);
            Console.WriteLine($"{c.Name}: new concert {e.Name} in {e.City}"
            + (price.HasValue ? $" for ${price}" : ""));


        }
        public int GetDistance(string fromCity, string toCity)
        {
            return AlphebiticalDistance(fromCity, toCity);
        }
        public int AlphebiticalDistance(string s, string t)
        {
            var result = 0;
            var i = 0;
            for (i = 0; i < Math.Min(s.Length, t.Length); i++)
            {

                result += Math.Abs(s[i] - t[i]);
            }
            for (; i < Math.Max(s.Length, t.Length); i++)
            {

                result += s.Length > t.Length ? s[i] : t[i];
            }
            return result;
        }


        public List<Event> GetGigs(Customer customer, List<Event> events)
        {
            Dictionary<Event, int> distances =
            new Dictionary<Event, int>();

            var gigsForCustomer = events.Where(e => e.City.Equals(customer.City)).ToList();

            var leftGigs = customer.MaxGigs - gigsForCustomer.Count();



            if (gigsForCustomer.Count() < customer.MaxGigs)
            {
                // get maximum gigs

                for (var i = 0; i < events.Count(); i++)
                {
                    if (customer.City.Equals(events[i].City))
                        continue;
                    else
                    {
                        try
                        {

                            distances.Add(events[i], GetDistance(customer.City, events[i].City));


                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Failed to add city to dictionary");
                        }

                    }

                }

                var newGigs = distances.OrderBy(d => d.Value).Take(leftGigs); // take the closest x left cities
                foreach (var item in newGigs)
                {
                    Event eve = new Event { City = item.Key.City, Name = item.Key.Name };
                    gigsForCustomer.Add(eve);
                }

            }

            return gigsForCustomer.ToList();
        }
    }
}

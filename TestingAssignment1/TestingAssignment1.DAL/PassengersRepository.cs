using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingAssignment1.DAL.Interface;
using TestingAssignment1.Models;

namespace TestingAssignment1.DAL
{
    public class PassengersRepository : IPassengersRepository
    {

        List<Passengers> passengers = new List<Passengers>()
        {
            new Passengers(){Id=1,FirstName="ABC",LastName="XYZ",PhoneNumber="15541654"},
            new Passengers(){Id=2,FirstName="PQR",LastName="XYZ",PhoneNumber="543535434"}
        };

        public string AddPassenger(Passengers data)
        {
            passengers.Add(data);
            return "Passenger Added";
        }

        public string DeletePassenger(int id)
        {
            var itemToRemove = passengers.Single(r => r.Id == id);
            passengers.Remove(itemToRemove);
            return "Passenger Deleted";
        }

        public string EditPassenger(int id, Passengers data)
        {
            passengers.Find(x => x.Id == id).FirstName=data.FirstName;
            passengers.Find(x => x.Id == id).LastName = data.LastName;
            passengers.Find(x => x.Id == id).PhoneNumber = data.PhoneNumber;
            return "Passenger Edited";
        }

        public Passengers GetPassenger(int id)
        {
            return passengers.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Passengers> GetPassengers()
        {
            return passengers;
        }
    }
}

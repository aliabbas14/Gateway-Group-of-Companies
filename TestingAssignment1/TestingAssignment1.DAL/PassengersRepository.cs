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


        /*
            This method is called when user wnats to add a new passenger. It accepts passengers data as input and adds the new passenger.
             */
        public string AddPassenger(Passengers data)
        {
            passengers.Add(data);
            return "Passenger Added";
        }


        /*
            This method is called when user wnats to delete a passenger. It accepts passenger's unique id as input and deletes the passenger. 
             */
        public string DeletePassenger(int id)
        {
            var itemToRemove = passengers.Single(r => r.Id == id);
            passengers.Remove(itemToRemove);
            return "Passenger Deleted";
        }

        /*
            This method is called when user wnats to edit a passenger. It accepts passenger's unique id and passenger's data as input and edits the 
            passenger. 
             */
        public string EditPassenger(int id, Passengers data)
        {
            passengers.Find(x => x.Id == id).FirstName=data.FirstName;
            passengers.Find(x => x.Id == id).LastName = data.LastName;
            passengers.Find(x => x.Id == id).PhoneNumber = data.PhoneNumber;
            return "Passenger Edited";
        }


        /*
            This method is called when user wnats to get a passenger from its unique id. It accepts passenger's unique id as input and returns the 
            passenger details. 
             */
        public Passengers GetPassenger(int id)
        {
            return passengers.Where(x => x.Id == id).FirstOrDefault();
        }


        /*
            This method is called when user wnats to get all the passengers. It returns the details of all the passengers.
             */
        public IEnumerable<Passengers> GetPassengers()
        {
            return passengers;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingAssignment1.Models;

namespace TestingAssignment1.DAL.Interface
{
    public interface IPassengersRepository
    {
        IEnumerable<Passengers> GetPassengers();

        Passengers GetPassenger(int id);

        string AddPassenger(Passengers data);

        string EditPassenger(int id, Passengers data);

        string DeletePassenger(int id);
    }
}

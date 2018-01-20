using System;
using System.Collections.Generic;
using System.Text;

namespace CCALearn.TruckLib
{
    public class TruckRepository
    {
        // the static keyword says that this list is shared (see video @59m)
        private static List<Truck> _trucks = new List<Truck>();
        private static int nextId = 0;

        public List<Truck> ListAll()
        {
            return _trucks;
        }
        public Truck GetById(int id)
        {
            return _trucks.Find(t => t.Id == id);  //@min 55:29, for each 't' in the list, we have passed
                                                   // a function which is t.id == id; this test returns false
                                                   // if t.id does not equal id; when it does, it returns true.
                                                   // when the lamda operator function returns true, the find method
                                                   // the returns the specific object out of the function
        }
        public void Add(Truck newTruck)  // ZZZ --- return to 58:20
        {
            newTruck.Id = nextId++;
            _trucks.Add(newTruck);
        }
        public void Edit(Truck editTruck)
        {
            // Question for Jeff @ 1:45:26 -- how does this method know to operate on the static list?
               // no, it's calling GetById in this repository.
            // Question for Jeff @ 1:45:20 -- is the method below operating on the static list above?
            var origTruck = GetById(editTruck.Id);

            origTruck.Year = editTruck.Year;
            origTruck.Manuf = editTruck.Manuf;
            origTruck.Capacity = editTruck.Capacity;
            // A few notes:  only updating in-memory list.  could also create a new object and delete the old object; not done here.
            // If a database was involved, we would need to write to the database here. 
        }
        public void Delete(Truck deleteTruck)
        {
            // _trucks is the name of the shared list and Remove is a method on _trucks.
            // we all remove and I believe we are done.
            _trucks.Remove(deleteTruck);
        }
    }
}

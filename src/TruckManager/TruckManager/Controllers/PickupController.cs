using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CCALearn.TruckLib;

namespace TruckManager.Controllers
{
    public class PickupController : Controller
    {
        // ZZZ -- pickup at 1:44 to restart the Edit Route
        // @1:13:07 Jeff says that static could be left off.  therefore removed.
        private TruckRepository _truckRepo = new TruckRepository();

        // GET: Pickup
        public ActionResult Index()
        {
            return View(_truckRepo.ListAll());
        }

        // GET: Pickup/Details/5
        public ActionResult Details(int id)
        {
            
            return View(_truckRepo.GetById(id));
        }

        // GET: Pickup/Create
        public ActionResult Create()
        {


            return View();
        }

        // POST: Pickup/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Truck newTruck, IFormCollection collection)
        {
            // @1:35, model-binder, takes in the form data and matches it to the new truck object
            // populating the newTruck object; does this cleanly without handwritten code from us.
            // we don't hav ean obvious 'model-binder' declaration, rather it 'occurs' above by 
            // virtue of the fact that we combine the 'collection' coming in with Truck newTruck
            // in the argument list above.
            try
            {
                // TODO: Add insert logic here

                _truckRepo.Add(newTruck);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Pickup/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_truckRepo.GetById(id));  // @ 1:50, Jeff puts in vehicleRepo.GetByID in the argument list for View ... I'm not needing to ... Hmmm.
        }

        // POST: Pickup/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Truck editTruck, int id, IFormCollection collection)
        {
            try
            {
                 _truckRepo.Edit(editTruck);  // calling this updates the static shared memory list.
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Pickup/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_truckRepo.GetById(id));
        }

        // POST: Pickup/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Truck deleteTruck, int id, IFormCollection collection)
        {  // by virute of "model-binder" function, the incoming IFormCollection should bind and create an object deleteTruck
            try
            {
                // Note: we do have an object here
                _truckRepo.Delete(deleteTruck);  // does the remove method accept an object or only a
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
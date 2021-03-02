using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VaccineDonationCamp.Data;
using VaccineDonationCamp.Models;
using VaccineDonationCamp.ViewModel;

namespace VaccineDonationCamp.Controllers
{
    [Authorize]
    public class PatientController : Controller
    {

        private PatientDbContext context;
        public PatientController(PatientDbContext dbContext)
        {
            context = dbContext;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {

            List<Patient> patients = context.Patients.ToList();
            return View(patients);
        }


        [HttpGet]
        public IActionResult Add()
        {
            AddPatientViewModel addPatientViewModel = new AddPatientViewModel();
            return View(addPatientViewModel);
        }


        [HttpPost]

        public IActionResult Add(AddPatientViewModel addPatientViewModel)
        {
            if(ModelState.IsValid)
            {
                Patient newPatient = new Patient
                {
                    FirstName = addPatientViewModel.FirstName,
                    LastName = addPatientViewModel.LastName,
                    Dob = addPatientViewModel.Dob,
                    ContactNo = addPatientViewModel.ContactNo,
                    Email = addPatientViewModel.Email,
                    Address = addPatientViewModel.Address,
                    City = addPatientViewModel.City,
                    State =addPatientViewModel.State,
                    Zip = addPatientViewModel.Zip
                };

                context.Patients.Add(newPatient);
                context.SaveChanges();
                return Redirect("/Patient");
            }

            return View(addPatientViewModel);
        }



        public IActionResult Delete()

        {

           
            ViewBag.events = context.Patients.ToList(); 
            return View();

        }
        [HttpPost]
        public IActionResult Delete(int[] patientIds) // create method in the same name of above to post the delete.
        {
            foreach (var patientId in patientIds)
            {
                //EventData.Remove(eventId); //gonna do same as Removel() whisch was in Data/EventData.cs now deleted
                Patient thePatient = context.Patients.Find(patientId);
                context.Patients.Remove(thePatient);
            }

            context.SaveChanges(); //gonna save everything 
            return Redirect("/Patient");
        }



        [Route("/Patient/Edit/{patientId}")] // this rout will take us to  the selected id no 
        public IActionResult Edit(int patientId)
        {

            /*ViewBag.eventsDictionaryObj = EventData.GetById(eventId);*/// picking the value which is a class type List, corresponding to the Id.


            ViewBag.patientObj = context.Patients.Find(patientId);
            ViewBag.title = "You are editing " + ViewBag.patientObj.FirstName + " (id= #" + ViewBag.patientObj.Id + ")";



            // controller code will go here
            return View();
        }


        [HttpPost]
        [Route("/patient/edit")]
        public IActionResult SubmitEditEventForm(int patientId, string firstName, string lastName, string dob, string email, int contactNo, string address, string city, string state, int zip)
        {

            /*Event updated = EventData.GetById(eventId);*/  // Event is class type list and a Value od Events dictionary. 
                                                             //so to get that Event List value which is acctualy a class type ,we need to create an object of Event Class.
            Patient updated = context.Patients.Find(patientId);

            //updating the fields
            updated.FirstName = firstName;
            updated.LastName= lastName;
            updated.Email = email;
            updated.Dob = dob;
            updated.Address = address;
            updated.City = city;
            updated.State = state;
            updated.Zip = zip;
            // controller code will go here

            context.SaveChanges();
            return Redirect("/Patient");
        }


    }
}

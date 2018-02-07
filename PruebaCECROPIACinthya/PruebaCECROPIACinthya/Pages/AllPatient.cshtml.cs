using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PruebaCECROPIACinthya.Models;
using System.Collections.Generic;
using System.Linq;

namespace PruebaCECROPIACinthya.Pages
{
    public class AllPatientModel : PageModel
    {
        DatabaseContext _Context;
        public AllPatientModel(DatabaseContext databasecontext)
        {
            _Context = databasecontext;
        }

        public List<Patient> PatientList { get; set; }

        public void OnGet()
        {
            var data = (from patientlist in _Context.PatientTB
                        select patientlist).ToList();

            PatientList = data;
        }




        public ActionResult OnGetDelete(int? id)
        {
            if (id != null)
            {
                var data = (from patient in _Context.PatientTB
                            where patient.ID.Equals(id)
                            select patient).SingleOrDefault();

                _Context.Remove(data);
                _Context.SaveChanges();
            }
            return RedirectToPage("AllPatient");
        }

    }
}
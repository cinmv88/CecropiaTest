using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PruebaCECROPIACinthya.Models;
using System.Linq;

namespace PruebaCECROPIACinthya.Pages
{
    public class EditPatientModel : PageModel
    {
        DatabaseContext _Context;
        public EditPatientModel(DatabaseContext databasecontext)
        {
            _Context = databasecontext;
        }


        [BindProperty]
        public Patient Patient { get; set; }

        public void OnGet(int? id)
        {
            if (id != null)
            {
                var data = (from patient in _Context.PatientTB
                            where patient.ID.Equals(id)
                            select patient).SingleOrDefault();

                Patient = data;
            }
        }


        public ActionResult OnPost()
        {
            var patient = Patient;
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _Context.Entry(patient).Property(x => x.ID).IsModified = true;
         /*   _Context.Entry(patient).Property(x => x.Phoneno).IsModified = true;
            _Context.Entry(patient).Property(x => x.Address).IsModified = true;
            _Context.Entry(patient).Property(x => x.City).IsModified = true;
            _Context.Entry(patient).Property(x => x.Country).IsModified = true;*/
            _Context.SaveChanges();
            return RedirectToPage("AllPatient");
        }
    }
}
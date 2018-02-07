using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PruebaCECROPIACinthya.Models;

namespace PruebaCECROPIACinthya.Pages
{
    public class PatientModel : PageModel
    {
        DatabaseContext _Context;
        public PatientModel(DatabaseContext databasecontext)
        {
            _Context = databasecontext;
        }

        [BindProperty]
        public Patient Patient { get; set; }

        public void OnGet()
        {

        }

        public ActionResult OnPost()
        {
            var patient = Patient;
            if (!ModelState.IsValid)
            {
                return Page(); // return page
            }

            patient.ID = "123";
            var result = _Context.Add(patient);
            _Context.SaveChanges(); // Saving Data in database

            return RedirectToPage("AllPatient");
        }
    }
}
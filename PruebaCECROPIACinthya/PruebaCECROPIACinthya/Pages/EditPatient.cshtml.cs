using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PruebaCECROPIACinthya.Models;
using System.Linq;

namespace PruebaCECROPIACinthya.Pages
{
    public class EditPatientModel : PageModel
    {

        [BindProperty]
        public Patient Patient { get; set; }

        public void OnGet(int? id)
        {
            if (id != null)
            {
				PatientClient pc = new PatientClient();
				Patient = pc.findID(id);

            }
        }


        public ActionResult OnPost()
        {
            var patient = Patient;
            if (!ModelState.IsValid)
            {
                return Page();
            }

			PatientClient pc = new PatientClient();
			pc.Edit(patient);

            /*_Context.Entry(patient).Property(x => x.ID).IsModified = true;     
            _Context.SaveChanges();*/

            return RedirectToPage("AllPatient");
        }
    }
}
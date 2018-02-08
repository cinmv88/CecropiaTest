using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PruebaCECROPIACinthya.Models;

namespace PruebaCECROPIACinthya.Pages
{
    public class PatientModel : PageModel
    {
		//DatabaseContext _Context;
		/*public PatientModel(DatabaseContext databasecontext)
        {
            _Context = databasecontext;
        }*/

		public PatientModel()
		{
		}

        [BindProperty]
        public Patient Patient { get; set; }

        public void OnGet()
        {

        }

		[HttpPost]
		public ActionResult OnPost()
        {
			var patient = Patient;

			if (!ModelState.IsValid) //validate the dataanotations defined for the model
			{
				return Page(); // return page
			}
	
			PatientClient pc = new PatientClient();
			pc.Create(patient);
			//  var result = _Context.Add(patient);
			//_Context.SaveChanges(); // Saving Data in database

			return RedirectToPage("AllPatient");
		}
    }
}
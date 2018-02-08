using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PruebaCECROPIACinthya.Models;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Diagnostics;

namespace PruebaCECROPIACinthya.Pages
{
    public class AllPatientModel : PageModel
    {

        public List<Patient> PatientList { get; set; }

        public void OnGet()
        {
            /*var data = (from patientlist in x
                        select patientlist).ToList();*/

			PatientClient pc = new PatientClient();
			try
			{
				foreach (var x in pc.findAll())
				{
					PatientList.Add(x);
				}
			}
			catch (System.Exception e) {
				/*EventLog.WriteEntry(ConfigurationManager.AppSettings["EventLogName"].ToString()
				, e.Message);*/
			}
			

        }


        public ActionResult OnGetDelete(int? id)
        {
            if (id != null)
            {
                /*var data = (from patient in x
                            where patient.ID.Equals(id)
                            select patient).SingleOrDefault();*/

				PatientClient pc = new PatientClient();
				pc.Delete(id);
				 
            }
            return RedirectToPage("AllPatient");
        }

    }
}
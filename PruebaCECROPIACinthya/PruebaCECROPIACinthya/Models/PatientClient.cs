using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http.Formatting;
using System.Net.Http;

namespace PruebaCECROPIACinthya.Models
{
    public class PatientClient
    {
		private string BASE_URL = System.Configuration.ConfigurationManager.AppSettings["BASEURLWebAPI"].ToString();

		public IEnumerable<Patient> findAll()
		{
			try
			{
				HttpClient client = new HttpClient();
				client.BaseAddress = new Uri(BASE_URL);
				client.DefaultRequestHeaders.Accept.Add(
					new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
				HttpResponseMessage response = client.GetAsync("Patients").Result;
				if (response.IsSuccessStatusCode)
				{
					return response.Content.ReadAsAsync<IEnumerable<Patient>>().Result;
				}
				else { return null; }
			}
			catch (AggregateException e)
			{
				string m = e.GetBaseException().ToString();
				return null;
			}

		}


		public Patient findID(int? id)
		{
			try
			{
				HttpClient client = new HttpClient();
				client.BaseAddress = new Uri(BASE_URL);
				client.DefaultRequestHeaders.Accept.Add(
					new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
				HttpResponseMessage response = client.GetAsync("Patients/" + id).Result;
				if (response.IsSuccessStatusCode)
				{
					return response.Content.ReadAsAsync<Patient>().Result;
				}
				else { return null; }
			}
			catch (AggregateException e)
			{
				string m = e.GetBaseException().ToString();
				return null;
			}

		}


		public bool Create(Patient p)
		{
			try
			{
				HttpClient client = new HttpClient();
				client.BaseAddress = new Uri(BASE_URL);
				client.DefaultRequestHeaders.Accept.Add(
					new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
				HttpResponseMessage response = client.PutAsJsonAsync("Patients", p).Result; 
				return response.IsSuccessStatusCode;
			}
			catch
			{
				return false;
			}

		}


		public bool Edit(Patient p)
		{
			try
			{
				HttpClient client = new HttpClient();
				client.BaseAddress = new Uri(BASE_URL);
				client.DefaultRequestHeaders.Accept.Add(
					new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
				HttpResponseMessage response = client.PutAsJsonAsync("Patients/" + p.ID, p).Result; 
				return response.IsSuccessStatusCode;
			}
			catch
			{
				return false;
			}

		}


		public bool Delete(int? id)
		{
			try
			{
				HttpClient client = new HttpClient();
				client.BaseAddress = new Uri(BASE_URL);
				client.DefaultRequestHeaders.Accept.Add(
					new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
				HttpResponseMessage response = client.DeleteAsync("Patients/" + id).Result; 
				return response.IsSuccessStatusCode;
			}
			catch
			{
				return false;
			}

		}
	}
}

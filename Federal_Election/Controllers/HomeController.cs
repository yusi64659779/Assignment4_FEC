using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Federal_Election.Models;
using Newtonsoft.Json;
using Federal_Election.DataAccess;
using System.Net.Http;
using System.Reflection;

namespace Federal_Election.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext dbContext;
        // Obtaining the API key is easy. The same key should be usable across the entire
        // data.gov developer network, i.e. all data sources on data.gov.
        // https://www.nps.gov/subjects/developer/get-started.htm

        static string BASE_URL = "https://api.open.fec.gov/v1/";
        static string API_KEY = "ZHumKXEODcwdnm0yb7aQ1TOrvDtTfGvLDdmJmytM"; //Add your API key here inside ""

        HttpClient httpClient;

        /// <summary>
        ///  Constructor to initialize the connection to the data source
        /// </summary>
        public HomeController(ApplicationDbContext context)
        {
            dbContext = context;
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Add("X-Api-Key", API_KEY);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        }

        /// <summary>
        /// Method to receive data from API end point as a collection of objects
        /// 
        /// JsonConvert parses the JSON string into classes
        /// </summary>
        /// <returns></returns>
        public Candidates GetCandidates()
        {
            string CANDIDATE_API_PATH = BASE_URL + "candidates";
            string candidatesData = "";

            Candidates candidates = null;

            httpClient.BaseAddress = new Uri(CANDIDATE_API_PATH);

            // It can take a few requests to get back a prompt response, if the API has not received
            //  calls in the recent past and the server has put the service on hibernation
            try
            {
                HttpResponseMessage response = httpClient.GetAsync(CANDIDATE_API_PATH).GetAwaiter().GetResult();
                Debug.WriteLine(response.IsSuccessStatusCode);
                if (response.IsSuccessStatusCode)
                {
                    candidatesData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    Debug.WriteLine(candidatesData);
                }

                if (!candidatesData.Equals(""))
                {
                    // JsonConvert is part of the NewtonSoft.Json Nuget package
                    candidates = JsonConvert.DeserializeObject<Candidates>(candidatesData);
                }
            }
            catch (Exception e)
            {
                // This is a useful place to insert a breakpoint and observe the error message
                Console.WriteLine(e.Message);
            }

            return candidates;
        }

        public IActionResult PopulateCandidates()
        {
            // Retrieve the companies that were saved in the symbols method
            // List<Candidates> candidate = JsonConvert.DeserializeObject<Candidates>(TempData["Candidates"].ToString());
            HomeController webHandler = new HomeController(dbContext);
            Candidates candidate = webHandler.GetCandidates();
            //Candidates candidate = JsonConvert.DeserializeObject<Candidates>(TempData["Candidates"].ToString());
            List<Candidate> cd = candidate.results;
            foreach (Candidate cd1 in cd)
            {
                if (dbContext.Candidate.Where(c => c.candidate_id.Equals(cd1.candidate_id)).Count() == 0)
                {
                    dbContext.Candidate.Add(cd1);
                }

            }


            dbContext.SaveChanges();
            ViewBag.dbSuccessComp = 1;
            return View("Candidates", candidate);
        }
        public IActionResult PopulateCommittees()
        {
            // Retrieve the companies that were saved in the symbols method
            // List<Candidates> candidate = JsonConvert.DeserializeObject<Candidates>(TempData["Candidates"].ToString());
            HomeController webHandler = new HomeController(dbContext);
            Committees committee = webHandler.GetCommittees();
            List<Committee> cm = committee.results;
            foreach (Committee cm1 in cm)
            {
                if (dbContext.Committee.Where(c => c.committee_id.Equals(cm1.committee_id)).Count() == 0)
                {
                    dbContext.Committee.Add(cm1);
                }
            }


            dbContext.SaveChanges();
            ViewBag.dbSuccessComp = 1;
            return View("Committees", committee);
        }
        public IActionResult PopulateFilings()
        {
            // Retrieve the companies that were saved in the symbols method
            // List<Candidates> candidate = JsonConvert.DeserializeObject<Candidates>(TempData["Candidates"].ToString());
            HomeController webHandler = new HomeController(dbContext);
            Filings filing = webHandler.GetFilings();
            List<Filing> fl = filing.results;
            foreach (Filing fl1 in fl)
            {
                if (dbContext.Filing.Where(c => c.sub_id.Equals(fl1.sub_id)).Count() == 0)
                {
                    dbContext.Filing.Add(fl1);
                }
            }


            dbContext.SaveChanges();
            ViewBag.dbSuccessComp = 1;
            return View("Filings", filing);
        }



        public Committees GetCommittees()
        {
            string COMMITTEE_API_PATH = BASE_URL + "committees";
            string committeesData = "";

            Committees committees = null;

            httpClient.BaseAddress = new Uri(COMMITTEE_API_PATH);

            // It can take a few requests to get back a prompt response, if the API has not received
            //  calls in the recent past and the server has put the service on hibernation
            try
            {
                HttpResponseMessage response = httpClient.GetAsync(COMMITTEE_API_PATH).GetAwaiter().GetResult();
                Debug.WriteLine(response.IsSuccessStatusCode);
                if (response.IsSuccessStatusCode)
                {
                    committeesData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    Debug.WriteLine(committeesData);
                }

                if (!committeesData.Equals(""))
                {
                    // JsonConvert is part of the NewtonSoft.Json Nuget package
                    committees = JsonConvert.DeserializeObject<Committees>(committeesData);
                }
            }
            catch (Exception e)
            {
                // This is a useful place to insert a breakpoint and observe the error message
                Console.WriteLine(e.Message);
            }

            return committees;
        }
        public Filings GetFilings()
        {
            string FILING_API_PATH = BASE_URL + "filings";
            string filingsData = "";

            Filings filings = null;

            httpClient.BaseAddress = new Uri(FILING_API_PATH);

            // It can take a few requests to get back a prompt response, if the API has not received
            //  calls in the recent past and the server has put the service on hibernation
            try
            {
                HttpResponseMessage response = httpClient.GetAsync(FILING_API_PATH).GetAwaiter().GetResult();
                Debug.WriteLine(response.IsSuccessStatusCode);
                if (response.IsSuccessStatusCode)
                {
                    filingsData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    Debug.WriteLine(filingsData);
                }

                if (!filingsData.Equals(""))
                {
                    // JsonConvert is part of the NewtonSoft.Json Nuget package
                    filings = JsonConvert.DeserializeObject<Filings>(filingsData);
                }
            }
            catch (Exception e)
            {
                // This is a useful place to insert a breakpoint and observe the error message
                Console.WriteLine(e.Message);
            }

            return filings;
        }




        /// <summary>
        ///  Constructor to initialize the connection to the data source
        /// </summary>

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Candidates()
        {
            HomeController webHandler = new HomeController(dbContext);
            Candidates candidate = webHandler.GetCandidates();

            TempData["Candidates"] = JsonConvert.SerializeObject(candidate);

            return View(candidate);
        }
        public IActionResult Committees()
        {

            HomeController webHandler = new HomeController(dbContext);
            Committees committee = webHandler.GetCommittees();

            return View(committee);
        }
        public IActionResult Filings()
        {

            HomeController webHandler = new HomeController(dbContext);
            Filings filing = webHandler.GetFilings();

            return View(filing);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
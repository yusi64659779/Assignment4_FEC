using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Federal_Election.Models
{
    public class Candidate
    {
        public int active_through { get; set; }
        [Key]
        public string candidate_id { get; set; }
        public string incumbent_challenge_full { get; set; }
        public string first_file_date { get; set; }
        public int district_number { get; set; }
        public bool candidate_inactive { get; set; }
        public string name { get; set; }
        public bool has_raised_funds { get; set; }
        public string office { get; set; }
        public string incumbent_challenge { get; set; }
        public string district { get; set; }
        public string party { get; set; }
        public bool federal_funds_flag { get; set; }
        public string party_full { get; set; }
        public string candidate_status { get; set; }
        public string office_full { get; set; }
        //public List<election> election { get; set; }
        public string last_f2_date { get; set; }
        public string last_file_date { get; set; }
        public string flags { get; set; }
        public string state { get; set; }
        public DateTime load_date { get; set; }
    }
    public class Candidates
    {

        [Key]
        public string candidate_id { get; set; }
        public string api_version { get; set; }
        public List<Candidate> results { get; set; }
    }
}

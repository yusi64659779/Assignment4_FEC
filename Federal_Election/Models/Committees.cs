using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Federal_Election.Models
{
    public class Committee
    {
        [Key]
        public string committee_id { get; set; }
        public string first_file_date { get; set; }
        public string name { get; set; }
        public string committee_type { get; set; }
        public string filing_frequency { get; set; }
       // public List<candidateId> candidateid { get; set; }
        public string organization_type_full { get; set; }
        public string party { get; set; }
        //public List<election>election { get; set; }
        public string party_full { get; set; }
        public string organization_type { get; set; }
        public string designation_full { get; set; }
        public string committee_type_full { get; set; }
        public string last_file_date { get; set; }
        public string designation { get; set; }
        public string state { get; set; }
        public string last_f1_date { get; set; }
        public string affiliated_committee_name { get; set; }
        public string treasurer_name { get; set; }
    }
    public class Committees
    {
        [Key]
        public string committee_id { get; set; }
        public string api_version { get; set; }
        public List<Committee> results { get; set; }
    }
}

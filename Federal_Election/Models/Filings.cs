using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Federal_Election.Models
{
    public class Filing
    {
        public double? debts_owed_by_committee { get; set; }
        public string means_filed { get; set; }
        public bool? is_amended { get; set; }
        public int? amendment_version { get; set; }
        public double? cash_on_hand_end_period { get; set; }
        public string form_type { get; set; }
        public string net_donations { get; set; }
        public string office { get; set; }
        public string senate_personal_funds { get; set; }
        
        public int? file_number { get; set; }
        public string document_type { get; set; }
        public DateTime coverage_end_date { get; set; }
        public string beginning_image_number { get; set; }
        public string request_type { get; set; }
        public string primary_general_indicator { get; set; }
        public string fec_file_id { get; set; }
        public string treasurer_name { get; set; }
        public double? total_disbursements { get; set; }
        public int? most_recent_file_number { get; set; }
        public string receipt_date { get; set; }
        public string amendment_indicator { get; set; }
        public string report_type { get; set; }
        public int report_year { get; set; }
        public bool most_recent { get; set; }
        public int? pages { get; set; }
        public string total_independent_expenditures { get; set; }
        public string ending_image_number { get; set; }
        public string candidate_id { get; set; }
        public string party { get; set; }
        public DateTime? coverage_start_date { get; set; }
        public string candidate_name { get; set; }
        public double? debts_owed_to_committee { get; set; }
        public string committee_name { get; set; }
        public string committee_id { get; set; }
        public string committee_type { get; set; }
        public string csv_url { get; set; }
        public string opposition_personal_funds { get; set; }
        public string document_type_full { get; set; }
        public string report_type_full { get; set; }
        public double? total_receipts { get; set; }
        public string form_category { get; set; }
        public int cycle { get; set; }
        public double? total_communication_cost { get; set; }
        [Key]
        public string sub_id { get; set; }
        public string house_personal_funds { get; set; }
        public int? previous_file_number { get; set; }
        public string election_year { get; set; }
        public double? cash_on_hand_beginning_period { get; set; }
        public string document_description { get; set; }
        public string html_url { get; set; }
        public string state { get; set; }
        public DateTime update_date { get; set; }
        public string total_individual_contributions { get; set; }
        public string pdf_url { get; set; }
        public string fec_url { get; set; }
        //public List<AmendmentChain> amendment_chain { get; set; }
    }
    public class Filings
    {
        [Key]
        public string sub_id { get; set; }
        public string api_version { get; set; }
        public List<Filing> results { get; set; }
    }
}

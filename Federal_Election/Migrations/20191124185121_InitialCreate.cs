using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Federal_Election.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    candidate_id = table.Column<string>(nullable: false),
                    api_version = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.candidate_id);
                });

            migrationBuilder.CreateTable(
                name: "Committees",
                columns: table => new
                {
                    committee_id = table.Column<string>(nullable: false),
                    api_version = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Committees", x => x.committee_id);
                });

            migrationBuilder.CreateTable(
                name: "Filings",
                columns: table => new
                {
                    sub_id = table.Column<string>(nullable: false),
                    api_version = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filings", x => x.sub_id);
                });

            migrationBuilder.CreateTable(
                name: "Candidate",
                columns: table => new
                {
                    active_through = table.Column<int>(nullable: false),
                    candidate_id = table.Column<string>(nullable: false),
                    incumbent_challenge_full = table.Column<string>(nullable: true),
                    first_file_date = table.Column<string>(nullable: true),
                    district_number = table.Column<int>(nullable: false),
                    candidate_inactive = table.Column<bool>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    has_raised_funds = table.Column<bool>(nullable: false),
                    office = table.Column<string>(nullable: true),
                    incumbent_challenge = table.Column<string>(nullable: true),
                    district = table.Column<string>(nullable: true),
                    party = table.Column<string>(nullable: true),
                    federal_funds_flag = table.Column<bool>(nullable: false),
                    party_full = table.Column<string>(nullable: true),
                    candidate_status = table.Column<string>(nullable: true),
                    office_full = table.Column<string>(nullable: true),
                    last_f2_date = table.Column<string>(nullable: true),
                    last_file_date = table.Column<string>(nullable: true),
                    flags = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    load_date = table.Column<DateTime>(nullable: false),
                    Candidatescandidate_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidate", x => x.candidate_id);
                    table.ForeignKey(
                        name: "FK_Candidate_Candidates_Candidatescandidate_id",
                        column: x => x.Candidatescandidate_id,
                        principalTable: "Candidates",
                        principalColumn: "candidate_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Committee",
                columns: table => new
                {
                    committee_id = table.Column<string>(nullable: false),
                    first_file_date = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    committee_type = table.Column<string>(nullable: true),
                    filing_frequency = table.Column<string>(nullable: true),
                    organization_type_full = table.Column<string>(nullable: true),
                    party = table.Column<string>(nullable: true),
                    party_full = table.Column<string>(nullable: true),
                    organization_type = table.Column<string>(nullable: true),
                    designation_full = table.Column<string>(nullable: true),
                    committee_type_full = table.Column<string>(nullable: true),
                    last_file_date = table.Column<string>(nullable: true),
                    designation = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    last_f1_date = table.Column<string>(nullable: true),
                    affiliated_committee_name = table.Column<string>(nullable: true),
                    treasurer_name = table.Column<string>(nullable: true),
                    Committeescommittee_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Committee", x => x.committee_id);
                    table.ForeignKey(
                        name: "FK_Committee_Committees_Committeescommittee_id",
                        column: x => x.Committeescommittee_id,
                        principalTable: "Committees",
                        principalColumn: "committee_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Filing",
                columns: table => new
                {
                    debts_owed_by_committee = table.Column<double>(nullable: true),
                    means_filed = table.Column<string>(nullable: true),
                    is_amended = table.Column<bool>(nullable: true),
                    amendment_version = table.Column<int>(nullable: true),
                    cash_on_hand_end_period = table.Column<double>(nullable: true),
                    form_type = table.Column<string>(nullable: true),
                    net_donations = table.Column<string>(nullable: true),
                    office = table.Column<string>(nullable: true),
                    senate_personal_funds = table.Column<string>(nullable: true),
                    file_number = table.Column<int>(nullable: true),
                    document_type = table.Column<string>(nullable: true),
                    coverage_end_date = table.Column<DateTime>(nullable: false),
                    beginning_image_number = table.Column<string>(nullable: true),
                    request_type = table.Column<string>(nullable: true),
                    primary_general_indicator = table.Column<string>(nullable: true),
                    fec_file_id = table.Column<string>(nullable: true),
                    treasurer_name = table.Column<string>(nullable: true),
                    total_disbursements = table.Column<double>(nullable: true),
                    most_recent_file_number = table.Column<int>(nullable: true),
                    receipt_date = table.Column<string>(nullable: true),
                    amendment_indicator = table.Column<string>(nullable: true),
                    report_type = table.Column<string>(nullable: true),
                    report_year = table.Column<int>(nullable: false),
                    most_recent = table.Column<bool>(nullable: false),
                    pages = table.Column<int>(nullable: true),
                    total_independent_expenditures = table.Column<string>(nullable: true),
                    ending_image_number = table.Column<string>(nullable: true),
                    candidate_id = table.Column<string>(nullable: true),
                    party = table.Column<string>(nullable: true),
                    coverage_start_date = table.Column<DateTime>(nullable: true),
                    candidate_name = table.Column<string>(nullable: true),
                    debts_owed_to_committee = table.Column<double>(nullable: true),
                    committee_name = table.Column<string>(nullable: true),
                    committee_id = table.Column<string>(nullable: true),
                    committee_type = table.Column<string>(nullable: true),
                    csv_url = table.Column<string>(nullable: true),
                    opposition_personal_funds = table.Column<string>(nullable: true),
                    document_type_full = table.Column<string>(nullable: true),
                    report_type_full = table.Column<string>(nullable: true),
                    total_receipts = table.Column<double>(nullable: true),
                    form_category = table.Column<string>(nullable: true),
                    cycle = table.Column<int>(nullable: false),
                    total_communication_cost = table.Column<double>(nullable: true),
                    sub_id = table.Column<string>(nullable: false),
                    house_personal_funds = table.Column<string>(nullable: true),
                    previous_file_number = table.Column<int>(nullable: true),
                    election_year = table.Column<string>(nullable: true),
                    cash_on_hand_beginning_period = table.Column<double>(nullable: true),
                    document_description = table.Column<string>(nullable: true),
                    html_url = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    update_date = table.Column<DateTime>(nullable: false),
                    total_individual_contributions = table.Column<string>(nullable: true),
                    pdf_url = table.Column<string>(nullable: true),
                    fec_url = table.Column<string>(nullable: true),
                    Filingssub_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filing", x => x.sub_id);
                    table.ForeignKey(
                        name: "FK_Filing_Filings_Filingssub_id",
                        column: x => x.Filingssub_id,
                        principalTable: "Filings",
                        principalColumn: "sub_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_Candidatescandidate_id",
                table: "Candidate",
                column: "Candidatescandidate_id");

            migrationBuilder.CreateIndex(
                name: "IX_Committee_Committeescommittee_id",
                table: "Committee",
                column: "Committeescommittee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Filing_Filingssub_id",
                table: "Filing",
                column: "Filingssub_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidate");

            migrationBuilder.DropTable(
                name: "Committee");

            migrationBuilder.DropTable(
                name: "Filing");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "Committees");

            migrationBuilder.DropTable(
                name: "Filings");
        }
    }
}

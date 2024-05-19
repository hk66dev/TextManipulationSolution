using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdmissionLibrary
{
    public class StudentAdmissionItems
    {
        public string PersonNumber { get; set; } = string.Empty;
        public DateOnly AdmissionDate { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FormerSchool { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string MailAddress { get; set; } = string.Empty;
        public int ChoiceRank { get; set; } = 0;
        public string AestheticChoice { get; set; } = string.Empty;
        public string Language11 { get; set; } = string.Empty;
        public string Language12 { get; set; } = string.Empty;
        public string Language22 { get; set; } = string.Empty;
        public string IndividualChoice1 { get; set; } = string.Empty;
        public string MotherTongue { get; set; } = string.Empty;
        public string SwedishAsSecondLanguage { get; set; } = string.Empty;
        public double Grades { get; set; } = 0.0;
        public double TestScore { get; set; } = 0.0;
        public string ProgramOrientation { get; set; } = string.Empty;
        public string AbsentRollCall { get; set; } = string.Empty;
        public string RollCallComment { get; set; } = string.Empty;

        /// <summary>
        /// Full constructor
        /// </summary>
        /// <param name="personNumber"></param>
        /// <param name="admissionDate"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="formerSchool"></param>
        /// <param name="address"></param>
        /// <param name="postalCode"></param>
        /// <param name="city"></param>
        /// <param name="phone"></param>
        /// <param name="mailAddress"></param>
        /// <param name="choiceRank"></param>
        /// <param name="aestheticChoice"></param>
        /// <param name="language11"></param>
        /// <param name="language12"></param>
        /// <param name="language22"></param>
        /// <param name="individualChoice1"></param>
        /// <param name="motherTongue"></param>
        /// <param name="swedishAsSecondLanguage"></param>
        /// <param name="grades"></param>
        /// <param name="testScore"></param>
        /// <param name="programOrientation"></param>
        /// <param name="absentRollCall"></param>
        /// <param name="rollCallComment"></param>
        public StudentAdmissionItems(string personNumber, DateOnly admissionDate,
            string firstName, string lastName, string formerSchool, string address,
            string postalCode, string city, string phone, string mailAddress,
            int choiceRank, string aestheticChoice, string language11, string language12,
            string language22, string individualChoice1, string motherTongue,
            string swedishAsSecondLanguage, double grades, double testScore,
            string programOrientation, string absentRollCall, string rollCallComment)
        {
            PersonNumber = personNumber;
            AdmissionDate = admissionDate;
            FirstName = firstName;
            LastName = lastName;
            FormerSchool = formerSchool;
            Address = address;
            PostalCode = postalCode;
            City = city;
            Phone = phone;
            MailAddress = mailAddress;
            ChoiceRank = choiceRank;
            AestheticChoice = aestheticChoice;
            Language11 = language11;
            Language12 = language12;
            Language22 = language22;
            IndividualChoice1 = individualChoice1;
            MotherTongue = motherTongue;
            SwedishAsSecondLanguage = swedishAsSecondLanguage;
            Grades = grades;
            TestScore = testScore;
            ProgramOrientation = programOrientation;
            AbsentRollCall = absentRollCall;
            RollCallComment = rollCallComment;
        }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public StudentAdmissionItems()
        {
            PersonNumber = String.Empty;
            //AdmissionDate = new(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            AdmissionDate = new(); // sets the date to minimal value
            FirstName = String.Empty;
            LastName = String.Empty;
            FormerSchool = String.Empty;
            Address = String.Empty;
            PostalCode = String.Empty;
            City = String.Empty;
            Phone = String.Empty;
            MailAddress = String.Empty;
            ChoiceRank = 0;
            AestheticChoice = String.Empty;
            Language11 = String.Empty;
            Language12 = String.Empty;
            Language22 = String.Empty;
            IndividualChoice1 = String.Empty;
            MotherTongue = String.Empty;
            SwedishAsSecondLanguage = String.Empty;
            Grades = 0.0;
            TestScore = 0.0;
            ProgramOrientation = String.Empty;
            AbsentRollCall = String.Empty;
            RollCallComment = String.Empty;
        }
    }
}

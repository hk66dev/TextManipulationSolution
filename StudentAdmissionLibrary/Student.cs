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
    public class Student
    {
        public string PersonNumber { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FormerSchool { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public int ChoiceRank { get; set; } = 0;
        public string ProgramOrientation { get; set; } = string.Empty;


        /// <summary>
        /// Constructor, all properties
        /// </summary>
        /// <param name="personNumber"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="formerSchool"></param>
        /// <param name="city"></param>
        /// <param name="choiceRank"></param>
        /// <param name="programOrientation"></param>
        public Student(string personNumber, string firstName, string lastName,
            string formerSchool, string city, int choiceRank, string programOrientation)
        {
            PersonNumber = personNumber;
            FirstName = firstName;
            LastName = lastName;
            FormerSchool = formerSchool;
            City = city;
            ChoiceRank = choiceRank;
            ProgramOrientation = programOrientation;
        }

        /// <summary>
        /// Constuctor, all properties from selected properties in StudentAdmissionItems
        /// </summary>
        /// <param name="studentAdmissionItems"></param>
        public Student(StudentAdmissionItems studentAdmissionItems)
        {
            PersonNumber = studentAdmissionItems.PersonNumber;
            FirstName = studentAdmissionItems.FirstName;
            LastName = studentAdmissionItems.LastName;
            FormerSchool = studentAdmissionItems.FormerSchool;
            City = studentAdmissionItems.City;
            ChoiceRank = studentAdmissionItems.ChoiceRank;
            ProgramOrientation = studentAdmissionItems.ProgramOrientation;
        }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public Student()
        {
            PersonNumber = String.Empty;
            FirstName = String.Empty;
            LastName = String.Empty;
            FormerSchool = String.Empty;
            City = String.Empty;
            ChoiceRank = 0;
            ProgramOrientation = String.Empty;
        }
    }
}

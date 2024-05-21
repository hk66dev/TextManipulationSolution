using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdmissionLibrary
{
    public class CourseChoice
    {
        public string PersonNumber { get; set; } = string.Empty;
        public string CourseType { get; set; } = string.Empty; 
        public string Course { get; set; } = string.Empty;

        /// <summary>
        ///  Empty constructor
        /// </summary>
        public CourseChoice()
        {
            PersonNumber = string.Empty;
            CourseType = string.Empty;
            Course = string.Empty;
        }

        /// <summary>
        /// Constructor, all properties
        /// </summary>
        /// <param name="personNumber"></param>
        /// <param name="courseType"></param>
        /// <param name="course"></param>
        public CourseChoice(string personNumber, string courseType, string course)
        {
            PersonNumber = personNumber;
            CourseType = courseType;
            Course = course;
        }
    }
}

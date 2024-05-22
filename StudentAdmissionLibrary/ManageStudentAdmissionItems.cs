using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Globalization;
using System.Net.Mail;
using System.Net;
using System.Numerics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace StudentAdmissionLibrary
{
    public class ManageStudentAdmissionItems
    {
        public string InputText { get; }
        public string? StudentAdmissionItemsToString { get; private set; }
        public string? StudentsToString { get; set; }
        public string? GradesToString { get; private set; }
        public string? CourseChoicesToString { get; private set; }
        public List<StudentAdmissionItems>? StudentAdmissionItemsList { get; set; }
        public List<Student>? Students { get; set; }
        public List<Grade>? Grades { get; set; }
        public List<CourseChoice>? CourseChoices { get; set; }



        // constructor
        public ManageStudentAdmissionItems(string inputText)
        {
            InputText = inputText;
            StudentAdmissionItemsList = GetStudentAdmissionItemsList();
            StudentAdmissionItemsToString = GetStudentAdmissionItemsToString();
            (Students, Grades, CourseChoices) = GetStudentLists();
            StudentsToString = GetStudentsToString().ToString();
            GradesToString = GetGradesToString().ToString();
            CourseChoicesToString = GetCourseChoicesToString();
        }

        private string? GetCourseChoicesToString()
        {
            // check if list is null or empty
            if (CourseChoices == null || CourseChoices.Count == 0) return string.Empty;

            // put together the output string,
            // header and rows from the list
            StringBuilder output = new();

            string header = "PersonNumber\tCourseType\tCourse";
            output.AppendLine(header);

            //foreach (var item in GetStudentAdmissionItemsList())
            foreach (var item in CourseChoices)
            {
                string s = $"{item.PersonNumber}\t{item.CourseType}\t{item.Course}";

                output.AppendLine(s);
            }

            return output.ToString();
        }

        private string GetGradesToString()
        {
            // check if list is null or empty
            if (Grades == null || Grades.Count == 0) return string.Empty;

            // put together the output string,
            // header and rows from the list
            StringBuilder output = new();

            string header = "PersonNumber\tGrade";
            output.AppendLine(header);

            //foreach (var item in GetStudentAdmissionItemsList())
            foreach (var item in Grades)
            {
                string s = $"{item.PersonNumber}\t{item.Grades}";

                output.AppendLine(s);
            }

            return output.ToString();
        }

        private string GetStudentsToString()
        {
            // check if list is null or empty
            if (Students == null || Students.Count == 0) return string.Empty;

            // put together the output string,
            // header and rows from the list
            StringBuilder output = new();

            string header = "PersonNumber\tFirstName\tLastName\tFormerSchool\tCity\tChoiceRank\tProgramOrientation";
            output.AppendLine(header);

            // TODO: test if this works
            //foreach (var item in GetStudentAdmissionItemsList())
            foreach (var item in Students)
            {
                string s =
                    $"{item.PersonNumber}\t{item.FirstName}\t{item.LastName}\t" +
                    $"{item.FormerSchool}\t{item.City}\t{item.ChoiceRank}\t{item.ProgramOrientation}\t";

                output.AppendLine(s);
            }

            return output.ToString();
        }

        private (List<Student>? Students, List<Grade>? Grades, List<CourseChoice>? CourseChoices)
            GetStudentLists()
        //List<StudentAdmissionItems> studentAdmissionItemsList
        {
            if (StudentAdmissionItemsList == null) return (null, null, null);

            List<Student> students = new();
            List<Grade> grades = new();
            List<CourseChoice> courseChoices = new();

            foreach (var studentAdmissionItems in StudentAdmissionItemsList)
            {
                if (studentAdmissionItems == null) continue;

                // Student
                Student student = new()
                {
                    PersonNumber = studentAdmissionItems.PersonNumber,
                    FirstName = studentAdmissionItems.FirstName,
                    LastName = studentAdmissionItems.LastName,
                    FormerSchool = studentAdmissionItems.FormerSchool,
                    City = studentAdmissionItems.City,
                    ChoiceRank = studentAdmissionItems.ChoiceRank,
                    ProgramOrientation = studentAdmissionItems.ProgramOrientation
                };

                // Add student to list
                students.Add(student);

                // Grade
                Grade grade = new()
                {
                    PersonNumber = studentAdmissionItems.PersonNumber,
                    Grades = studentAdmissionItems.Grades,
                };
                // Add grade to list
                grades.Add(grade);

                //------------------- START ----------------------------
                #region CourseChoice: split choices and build list
                // AestheticChoice
                CourseChoice courseChoice = new()
                {
                    PersonNumber = studentAdmissionItems.PersonNumber,
                    CourseType = "AestheticChoice",
                    Course = studentAdmissionItems.AestheticChoice.Length > 0 ? studentAdmissionItems.AestheticChoice : "Saknas"
                };
                // Add AestheticChoice to list
                courseChoices.Add(courseChoice);

                // Language11                
                courseChoice = new()
                {
                    PersonNumber = studentAdmissionItems.PersonNumber,
                    CourseType = "Language11",
                    Course = studentAdmissionItems.Language11.Length > 0 ? studentAdmissionItems.Language11 : "Saknas"
                };
                // Add Language11 to list
                courseChoices.Add(courseChoice);

                // Language12               
                courseChoice = new()
                {
                    PersonNumber = studentAdmissionItems.PersonNumber,
                    CourseType = "Language12",
                    Course = studentAdmissionItems.Language12.Length > 0 ? studentAdmissionItems.Language12 : "Saknas"
                };
                // Add Language12 to list
                courseChoices.Add(courseChoice);

                // Language22               
                courseChoice = new()
                {
                    PersonNumber = studentAdmissionItems.PersonNumber,
                    CourseType = "Language22",
                    Course = studentAdmissionItems.Language22.Length > 0 ? studentAdmissionItems.Language22 : "Saknas"
                };
                // Add Language22 to list
                courseChoices.Add(courseChoice);

                // IndividualChoice1               
                courseChoice = new()
                {
                    PersonNumber = studentAdmissionItems.PersonNumber,
                    CourseType = "IndividualChoice1",
                    Course = studentAdmissionItems.IndividualChoice1.Length > 0 ? studentAdmissionItems.IndividualChoice1 : "Saknas"
                };
                // Add IndividualChoice1 to list
                courseChoices.Add(courseChoice);

                // MotherTongue               
                courseChoice = new()
                {
                    PersonNumber = studentAdmissionItems.PersonNumber,
                    CourseType = "MotherTongue",
                    Course = studentAdmissionItems.MotherTongue.Length > 0 ? studentAdmissionItems.MotherTongue : "Saknas"
                };
                // Add MotherTongue to list
                courseChoices.Add(courseChoice);

                // SwedishAsSecondLanguage               
                courseChoice = new()
                {
                    PersonNumber = studentAdmissionItems.PersonNumber,
                    CourseType = "SwedishAsSecondLanguage",
                    Course = studentAdmissionItems.SwedishAsSecondLanguage.Length > 0 ? studentAdmissionItems.SwedishAsSecondLanguage : "Saknas"
                };
                // Add SwedishAsSecondLanguage to list
                courseChoices.Add(courseChoice);

                #endregion
                //------------------- END ------------------------------
            }

            // return lists
            return (students, grades, courseChoices);
        }

        public List<StudentAdmissionItems> GetStudentAdmissionItemsList()
        {
            // build regex pattern used to split input 
            string patternSSN = @"(\d{6}-\w{2}\d{2})";
            string patternP1 = @"([\w, -]+program[\w, -]+)";
            string patternP2 = @"(Anpassad gymnasieskola[\w, -]+)";
            string patternP3 = @"([\w, -]+alternativ)";
            string patternP4 = @"([\w, -]+introduktion[\w, -]*)";
            string patternP5 = @"([\w, -]+Personnummer[\w, -]+)";
            string patternP6 = @"([\w, -]+högrehandsval[\w, /-]+)";
            string pattern = $"{patternSSN}|{patternP1}|{patternP2}|{patternP3}|{patternP4}|{patternP5}|{patternP6}";
            //string pattern = $"{patternSSN}";
            Regex rx = new(pattern, RegexOptions.None);

            //Split at swedish social security number
            String[] ssSSN = rx.Split(InputText);

            // studentAdmissionItems list with their choice
            List<StudentAdmissionItems> studentAdmissionItems = new();

            Regex rxSSN = new(patternSSN, RegexOptions.IgnorePatternWhitespace);

            // the lamda expression is used to get an index
            // the index is used to join two rows when a swedish social security number 
            // is found on one row
            foreach (var (item, index) in ssSSN.Select((value, i) => (value, i)))
            {
                // when swedish social security number is found
                if (rxSSN.IsMatch(item))
                {
                    string s = $"{item.Trim()}{ssSSN[index + 1].Trim()}";
                    var delimiters = new string[] { "\",\"", "" }; // delimiters "," and ""
                    var sSplit = s.Split(delimiters, StringSplitOptions.None); // split to get substrings

                    StudentAdmissionItems studentAdmissionItem = new();

                    for (int i = 0; i < sSplit.Length; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                studentAdmissionItem.PersonNumber = sSplit[i].Trim();
                                break;
                            case 1:
                                Regex rxDate = new(@"(\d{4}-\d{2}-\d{2})");

                                if (rxDate.IsMatch(sSplit[i].Trim()))
                                {
                                    int year = 0;
                                    int month = 0;
                                    int day = 0;

                                    var dateParts = sSplit[i].Split('-');

                                    for (int j = 0; j < dateParts.Length; j++)
                                    {
                                        switch (j)
                                        {
                                            case 0:
                                                bool isYearParsable = Int32.TryParse(dateParts[j], out year);
                                                if (!isYearParsable)
                                                {
                                                    year = 1;
                                                }
                                                break;
                                            case 1:
                                                bool isMonthParsable = Int32.TryParse(dateParts[j], out month);
                                                if (!isMonthParsable)
                                                {
                                                    month = 1;
                                                }
                                                break;
                                            case 2:
                                                bool isDayParsable = Int32.TryParse(dateParts[j], out day);
                                                if (!isDayParsable)
                                                {
                                                    day = 1;
                                                }
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                    studentAdmissionItem.AdmissionDate = new DateOnly(year, month, day);
                                }
                                else
                                {

                                }
                                break;
                            case 2:
                                string fName = string.Empty;
                                string lName = string.Empty;

                                var names = sSplit[i].Split(' ');

                                for (int j = 0; j < names.Length; j++)
                                {
                                    if (j == 0)
                                    {
                                        fName = names[j];
                                    }
                                    else
                                    {
                                        lName += names[j] + " ";
                                    }
                                }

                                studentAdmissionItem.FirstName = fName.Trim();
                                studentAdmissionItem.LastName = lName.Trim();
                                break;
                            case 3:
                                // check if string starts with a 0 or the string only contains digits
                                // if it's the case append "xx" at the end of string
                                bool isFormerSchoolOnlyDigits = sSplit[i].Trim().All(char.IsDigit);
                                if (sSplit[i].StartsWith('0') || isFormerSchoolOnlyDigits)
                                {
                                    studentAdmissionItem.FormerSchool = $"{sSplit[i].Trim()}xx";
                                }
                                else
                                {
                                    studentAdmissionItem.FormerSchool = sSplit[i].Trim();
                                }
                                break;
                            case 4:
                                studentAdmissionItem.Address = sSplit[i].Trim();
                                break;
                            case 5:
                                studentAdmissionItem.PostalCode = sSplit[i].Trim();
                                break;
                            case 6:
                                studentAdmissionItem.City = sSplit[i].Trim();
                                break;
                            case 7:
                                string phone = sSplit[i].Trim();

                                // check and adjust phone number
                                if (phone.Length > 0)
                                {
                                    // temporary phone string while configuring phone number
                                    string tmpPhone = string.Empty;

                                    if (phone.StartsWith('0') | phone.StartsWith('+'))
                                    {
                                        tmpPhone = phone.Trim();
                                    }
                                    else
                                    {
                                        tmpPhone = $"0{phone.Trim()}";
                                    }

                                    // check for '-'
                                    if (tmpPhone.Contains('-'))
                                    {
                                        studentAdmissionItem.Phone = tmpPhone.Trim();
                                    }
                                    else
                                    {
                                        // remove all whitespace characters from string
                                        string tmpTrimmedPhone = String.Concat(tmpPhone.Where(c => !Char.IsWhiteSpace(c)));

                                        // check if phone number only contains digits
                                        // insert "-" as character three if so
                                        bool isPhoneOnlyDigits = tmpTrimmedPhone.All(char.IsDigit);
                                        if (isPhoneOnlyDigits)
                                        {
                                            if (tmpTrimmedPhone.Length == 9)
                                            {
                                                studentAdmissionItem.Phone = string.Format("{0:000-## ## ##}", Convert.ToInt64(tmpTrimmedPhone));
                                            }
                                            else if (tmpTrimmedPhone.Length == 10)
                                            {
                                                studentAdmissionItem.Phone = string.Format("{0:000-### ## ##}", Convert.ToInt64(tmpTrimmedPhone));
                                            }
                                            else if (tmpTrimmedPhone.Length == 11)
                                            {
                                                studentAdmissionItem.Phone = string.Format("{0:000-### ### ##}", Convert.ToInt64(tmpTrimmedPhone));
                                            }

                                        }
                                        else
                                        {
                                            studentAdmissionItem.Phone = tmpPhone.Trim();
                                        }
                                    }
                                }
                                break;
                            case 8:
                                studentAdmissionItem.MailAddress = sSplit[i].Trim();
                                break;
                            case 9:
                                bool isChoisRankParsable = Int32.TryParse(sSplit[i], out int rank);

                                if (isChoisRankParsable)
                                {
                                    studentAdmissionItem.ChoiceRank = rank;
                                }
                                else
                                {
                                    studentAdmissionItem.ChoiceRank = 0;
                                }
                                break;
                            case 10:
                                studentAdmissionItem.AestheticChoice = sSplit[i].Trim();
                                break;
                            case 11:
                                studentAdmissionItem.Language11 = sSplit[i].Trim();
                                break;
                            case 12:
                                studentAdmissionItem.Language12 = sSplit[i].Trim();
                                break;
                            case 13:
                                studentAdmissionItem.Language22 = sSplit[i].Trim();
                                break;
                            case 14:
                                studentAdmissionItem.IndividualChoice1 = sSplit[i].Trim();
                                break;
                            case 15:
                                studentAdmissionItem.MotherTongue = sSplit[i].Trim();
                                break;
                            case 16:
                                studentAdmissionItem.SwedishAsSecondLanguage = sSplit[i].Trim();
                                break;
                            case 17:
                                bool isGradesParsable = double.TryParse(sSplit[i], NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out double grades);
                                if (isGradesParsable)
                                {
                                    studentAdmissionItem.Grades = grades;
                                }
                                else
                                {
                                    studentAdmissionItem.Grades = 0.0;
                                }
                                break;
                            case 18:
                                bool isTestScoreParsable = double.TryParse(sSplit[i], NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out double testScore);
                                if (isTestScoreParsable)
                                {
                                    studentAdmissionItem.TestScore = testScore;
                                }
                                else
                                {
                                    studentAdmissionItem.TestScore = 0.0;
                                }
                                break;
                            case 19:
                                studentAdmissionItem.ProgramOrientation = sSplit[i].Trim();
                                break;
                            case 20:
                                studentAdmissionItem.AbsentRollCall = sSplit[i].Trim();
                                break;
                            case 21:
                                string tmpRCC = sSplit[i].Trim();
                                if (tmpRCC.Contains('\"'))
                                {
                                    tmpRCC = tmpRCC.Replace('\"', ' ');
                                }
                                studentAdmissionItem.RollCallComment = tmpRCC.Trim();
                                break;
                            default:
                                break;


                        }

                    }

                    // don't add studentAdmissionItems admission items if admission date ís minimal value
                    // that indicates that the fild is empty.
                    if (studentAdmissionItem.AdmissionDate != DateOnly.MinValue)
                    {
                        studentAdmissionItems.Add(studentAdmissionItem);
                    }
                }
            }

            return studentAdmissionItems;
        }

        public string GetStudentAdmissionItemsToString()
        {
            // check if list is null or empty
            if (StudentAdmissionItemsList == null || StudentAdmissionItemsList.Count == 0) return string.Empty;

            // put together the output string,
            // header and rows from the list
            StringBuilder output = new();

            string header =
                "PersonNumber\tAdmissionDate\tFirstName\tLastName\tFormerSchool\tAddress\t" +
                "PostalCode\tCity\tPhone\tMailAddress\tChoiceRank\tAestheticChoice\tLanguage11\t" +
                "Language12\tLanguage22\tIndividualChoice1\tMotherTongue\tSwedishAsSecondLanguage\t" +
                "Grades\tTestScore\tProgramOrientation\tAbsentRollCall\tRollCallComment";
            output.AppendLine(header);

            // TODO: test if this works
            //foreach (var item in GetStudentAdmissionItemsList())
            foreach (var item in StudentAdmissionItemsList)
            {
                string s =
                    $"{item.PersonNumber}\t{item.AdmissionDate}\t{item.FirstName}\t{item.LastName}\t" +
                    $"{item.FormerSchool}\t{item.Address}\t{item.PostalCode}\t{item.City}\t{item.Phone}\t" +
                    $"{item.MailAddress}\t{item.ChoiceRank}\t{item.AestheticChoice}\t{item.Language11}\t" +
                    $"{item.Language12}\t{item.Language22}\t{item.IndividualChoice1}\t{item.MotherTongue}\t" +
                    $"{item.SwedishAsSecondLanguage}\t{item.Grades}\t{item.TestScore}\t{item.ProgramOrientation}\t" +
                    $"{item.AbsentRollCall}\t{item.RollCallComment}";

                output.AppendLine(s);
            }

            return output.ToString();
        }

        /// <summary>
        /// Overrides ToString().
        /// </summary>
        /// <returns>String of studentAdmissionItems admission items from list, header and rows.</returns>
        public override string ToString()
        {
            return GetStudentAdmissionItemsToString();
        }

    }
}
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Globalization;
using System.Net.Mail;
using System.Net;
using System.Numerics;

namespace StudentAdmissionLibrary
{
    public class ManageStudentAdmissionItems
    {
        public string InputText { get; }

        public ManageStudentAdmissionItems(string inputText)
        {
            InputText = inputText;

        }

        //private List<StudentAdmissionItems> studentAdmissionItems = new();

        public string GetStudentAdmissionItems()
        {
            //MatchCollection matchedSSNs = rg.Matches(authors);  
            //string patternSSN = @"(\d{6}|\d{8})([-\s]?\d{4} )";
            //string patternSSN = @"\d{6}|\d{8}[-\s]?\d{4} ";
            string patternSSN = @"(\d{6}-\d{4})";
            string patternProgram = @"([A-Öa-ö, -]+program[A-Öa-ö -]+)";
            string pattern = $"{patternSSN}|{patternProgram}";

            //string pattern = @"(\d{6}-\d{4} )|([A-Öa-ö, -]+program[A-Öa-ö -]+)";
            Regex rx = new Regex(pattern, RegexOptions.IgnorePatternWhitespace);
            //Regex rxProgram = new Regex(patternProgram, RegexOptions.IgnoreCase);
            //Regex rxProgramSplit = new Regex(patternProgram, RegexOptions.IgnoreCase);

            //Match
            //MatchCollection matched = rx.Matches(InputText);
            //MatchCollection matchedPrograms = rxProgram.Matches(InputText);
            //String[] subStrings = rxProgramSplit.Split(InputText);
            String[] ssSSN = rx.Split(InputText);

            StringBuilder sb = new StringBuilder();

            //List<string> l = new();

            List<StudentAdmissionItems> saiList = new();

            Regex rxSSN = new Regex(patternSSN, RegexOptions.IgnorePatternWhitespace);

            foreach (var (item, index) in ssSSN.Select((value, i) => (value, i)))
            {
                if (rxSSN.IsMatch(item))
                {
                    string s = $"{item.Trim()}{ssSSN[index + 1].Trim()}";
                    sb.AppendLine(s);
                    var delimiters = new string[] { "\",\"", "" };
                    var sSplit = s.Split(delimiters, StringSplitOptions.TrimEntries);


                    StringBuilder sb2 = new StringBuilder();
                    foreach (var subItem in sSplit)
                    {
                        sb2.Append($"{subItem.Trim()},");
                    }

                    sb.AppendLine(sb2.ToString().Trim());

                    StudentAdmissionItems sai = new();

                    for (int i = 0; i < sSplit.Length; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                sai.PersonNumber = sSplit[i].Trim();
                                break;
                            case 1:
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
                                                year = 1800;
                                            }
                                            break;
                                        case 1:
                                            bool isMonthParsable = Int32.TryParse(dateParts[j],out month);
                                            if (!isMonthParsable)
                                            {
                                                month = 1;
                                            }
                                            break;
                                        case 2:
                                            bool isDayParsable = Int32.TryParse(dateParts[j],out day);
                                            if (!isDayParsable)
                                            {
                                                day = 1;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                }

                                sai.AdmissionDate = new DateOnly(year,month,day);
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

                                sai.FirstName = fName.Trim();
                                sai.LastName = lName.Trim();
                                break;
                            case 3:
                                sai.FormerSchool = sSplit[i].Trim();
                                break;
                            case 4:
                                sai.Address = sSplit[i].Trim();
                                break;
                            case 5:
                                string postalCode = string.Empty;
                                string city = string.Empty;
                                string phone = string.Empty;
                                string mail = string.Empty;

                                var variousItems = sSplit[i].Split(' ');

                                for (int j = 0; j < variousItems.Length; j++)
                                {
                                    switch (j)
                                    {
                                        case 0:
                                            postalCode = variousItems[j];
                                            break;
                                        case 1:
                                            city = variousItems[j];
                                            break;
                                        case 2:
                                            phone = variousItems[j];
                                            break;
                                        case 3:
                                            mail = variousItems[j];
                                            break;
                                        default:
                                            break;
                                    }
                                }

                                sai.PostalCode = postalCode.Trim();
                                sai.City = city.Trim();
                                sai.Phone = phone.Trim();
                                sai.MailAddress = mail.Trim();
                                break;
                            case 6:
                                bool isChoisRankParsable = Int32.TryParse(sSplit[i], out int rank);

                                if (isChoisRankParsable)
                                {
                                    sai.ChoiceRank = rank;
                                }
                                else
                                {
                                    sai.ChoiceRank = 0;
                                }
                                break;
                            case 7:
                                sai.AestheticChoice = sSplit[i].Trim();
                                break;
                            case 8:
                                sai.Language11 = sSplit[i].Trim();
                                break;
                            case 9:
                                sai.Language12 = sSplit[i].Trim();
                                break;
                            case 10:
                                sai.Language22 = sSplit[i].Trim();
                                break;
                            case 11:
                                sai.IndividualChoice1 = sSplit[i].Trim();
                                break;
                            case 12:
                                sai.MotherTongue = sSplit[i].Trim();
                                break;
                            case 13:
                                sai.SwedishAsSecondLanguage = sSplit[i].Trim();
                                break;
                            case 14:
                                bool isGradesParsable = double.TryParse(sSplit[i], NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out double grades);
                                if (isGradesParsable)
                                {
                                    sai.Grades = grades;
                                }
                                else
                                {
                                    sai.Grades = 0.0;
                                }
                                break;
                            case 15:
                                bool isTestScoreParsable = double.TryParse(sSplit[i], NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out double testScore);
                                if (isTestScoreParsable)
                                {
                                    sai.TestScore = testScore;
                                }
                                else
                                {
                                    sai.TestScore = 0.0;
                                }
                                break;
                            case 16:
                                sai.ProgramOrientation = sSplit[i].Trim();
                                break;
                            case 17:
                                sai.AbsentRollCall = sSplit[i].Trim();
                                break;
                            case 18:
                                sai.RollCallComment = sSplit[i].Trim();
                                break;
                            default:
                                break;
                        }

                    }

                    saiList.Add(sai);

                }
            }


            string header =
                "\nPersonNumber\tAdmissionDate\tFirstName\tLastName\tFormerSchool\tAddress\t" +
                "PostalCode\tCity\tPhone\tMailAddress\tChoiceRank\tAestheticChoice\tLanguage11\t" +
                "Language12\tLanguage22\tIndividualChoice1\tMotherTongue\tSwedishAsSecondLanguage\t" +
                "Grades\tTestScore\tProgramOrientation\tAbsentRollCall\tRollCallComment";

            sb.AppendLine(header);
            foreach (var item in saiList)
{
                string s = 
                    $"{item.PersonNumber}\t{item.AdmissionDate}\t{item.FirstName}\t{item.LastName}\t" +
                    $"{item.FormerSchool}\t{item.Address}\t{item.PostalCode}\t{item.City}\t{item.Phone}\t" +
                    $"{item.MailAddress}\t{item.ChoiceRank}\t{item.AestheticChoice}\t{item.Language11}\t" +
                    $"{item.Language12}\t{item.Language22}\t{item.IndividualChoice1}\t{item.MotherTongue}\t" +
                    $"{item.SwedishAsSecondLanguage}\t{item.Grades}\t{item.TestScore}\t{item.ProgramOrientation}\t" +
                    $"{item.AbsentRollCall}\t{item.RollCallComment}";

                sb.AppendLine(s); 

            }

            //foreach (var item in ssSSN)
            //{
            //    if (rxSSN.IsMatch(item))
            //    {
            //        sb.AppendLine(item);
            //    }
            //}

            //foreach (Match program in matchedPrograms)
            //{

            //    string s = string.Empty;
            //    s = program.Value;


            //    l.AddRange(InputText.Split(",",StringSplitOptions.TrimEntries));
            //}

            //foreach (string s in l)
            //{
            //    sb.AppendLine(s);
            //}

            //foreach (string ss in subStrings)
            //{
            //    sb.AppendLine(ss);
            //}

            //for (int count = 0; count < matchedSSNs.Count; count++)
            //{
            //    string s = matchedSSNs[count].Value;
            //    //sb.Append($"{s}{Environment.NewLine}");
            //    sb.AppendLine(s);
            //}

            //foreach (Match ssn in matched)
            //{
            //    string s = ssn.Value;
            //    sb.AppendLine(s);
            //}

            //foreach (Match program in matchedPrograms)
            //{
            //    string s = program.Value;
            //    sb.AppendLine(s);
            //}

            return sb.ToString();

        }




        //DateOnly date;
        //if (DateOnly.TryParse(admissionDate, out date))
        //{
        //    AdmissionDate = date;
        //}
        //else
        //{
        //    AdmissionDate = new DateOnly(DateTime.Now);
        //}

    }
}
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

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


                    StudentAdmissionItems sai = new StudentAdmissionItems();

                    for (int i = 0; i < sSplit.Length; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                sai.PersonNumber = sSplit[i];
                                break;
                            case 1:
                                int year = string.Empty;
                                int month = string.Empty;
                                int day = string.Empty;

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

                                sai.FirstName = fName;
                                sai.LastName = lName;
                                break;
                            case 3:
                                sai.FormerSchool = sSplit[i];
                                break;
                            case 4:
                                sai.Address = sSplit[i];
                                break;
                            case 5:
                                string postalCode = string.Empty;
                                string city = string.Empty;
                                string phone = string.Empty;
                                string mail = string.Empty;

                                var variousItems = sSplit[i].Split(' ');

                                sai.PostalCode = postalCode;
                                sai.City = sSplit[i];
                                sai.Phone = sSplit[i];
                                sai.MailAddress = sSplit[i];
                                break;
                            case 6:
                                sai.PersonNumber = sSplit[i];
                                break;
                            default:
                                break;
                        }

                    }

                }
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
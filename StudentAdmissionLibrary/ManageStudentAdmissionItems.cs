﻿using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Globalization;
using System.Net.Mail;
using System.Net;
using System.Numerics;
using System.Linq;

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
            // build regex pattern used to split input
            string patternSSN = @"(\d{6}-\w{2}\d{2})";
            string patternP1 = @"[\w, -]+program[\w, -]+";
            string patternP2 = @"Gymnas[ie]+särskola-[\w, -]+";
            string patternP3 = @"[\w, -]+alternativ";
            string patternP4 = @"[\w, -]+introduktion[\w, -]*";
            string patternP5 = @"Startar ej[\w, :-]+";
            string patternP6 = @"[\w, -]+högrehandsval[\w, /-]+";
            string pattern = $"{patternSSN}|{patternP1}|{patternP2}|{patternP3}|{patternP4}|{patternP5}|{patternP6}";
            Regex rx = new(pattern, RegexOptions.None);

            //Split at swedish social security number
            String[] ssSSN = rx.Split(InputText);

            // student list with their choice
            List<StudentAdmissionItems> studentAdmissionItems = new();

            Regex rxSSN = new(patternSSN, RegexOptions.IgnorePatternWhitespace);

            // the lamda expression is used to get an index
            // the index is used to join two rows when a swedish social security number 
            // is found on one row
            foreach (var (item, index) in ssSSN.Select((value, i) => (value, i)))
            {
                // when swedish social security number is fond
                if (rxSSN.IsMatch(item))
                {
                    string s = $"{item.Trim()}{ssSSN[index + 1].Trim()}";
                    var delimiters = new string[] { "\",\"", "" }; // delimiters "," and ""
                    //var sSplit = s.Split(delimiters, StringSplitOptions.TrimEntries); // split to get substrings
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

                                    try
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
                                                        year = 1800;
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
                                    catch (Exception)
                                    {
                                        throw;
                                    }
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
                                // switch "  " (double spaces) to "\t" (tabular)
                                // to make regex easier
                                Regex rxSwitchDoubleSpace = new("  ", RegexOptions.None);
                                string strVariousItems = rxSwitchDoubleSpace.Replace(sSplit[i], " \t ");

                                // initiate temporaty strings
                                string postalCode = string.Empty;
                                string city = string.Empty;
                                string phone = string.Empty;
                                string mail = string.Empty;

                                // build regex pattern
                                string patternPostalCode = @"^\d{3} \d{2}";
                                //string patternCity = @" [a-öA-Ö]+[ -][a-öA-Ö]*";
                                //string patternCity = @"[a-öA-Ö]+[ -][a-öA-Ö]* ";
                                //string patternCity = @"[a-öA-Ö]+[ -]*[a-öA-Ö]* "
                                string patternCity = @"[a-öA-Ö]+[ -]*[a-öA-Ö]* ";
                                //string patternPhone = @"[\d -]{9,16}";
                                string patternPhone = @"\d{2}[\d -]{6,10}\d|\+\d{2} ?\d[\d -]{7,10}\d";
                                string patternMail = @"[a-öA-Ö0-9.-]+@[a-zA-Z.-]+\.[a-zA-Z]{2,6}";

                                // hkl: färgkodningen funkar dåligt på de två sista raderna
                                string patternVariousItems = $"{patternPostalCode}|{patternCity}|{patternPhone}|{patternMail}";
                                Regex rxVariousItems = new(patternVariousItems, RegexOptions.None);
                                MatchCollection matchVariousItems = rxVariousItems.Matches(strVariousItems);
                                // hkl:

                                // hkl: Endast för test
                                List<string> aList = new();

                                foreach (var match in matchVariousItems.OfType<Match>())
                                {
                                    aList.Add(match.Value);
                                }
                                string a = string.Empty;

                                // hkl: End Endast för test

                                foreach (var match in matchVariousItems.OfType<Match>())
                                {
                                    Regex rxPostalCode = new(patternPostalCode);
                                    Regex rxCity = new(patternCity);
                                    Regex rxPhone = new(patternPhone);
                                    Regex rxMail = new(patternMail);
                                    if (rxPostalCode.IsMatch(match.Value) && match.Length <= 6)
                                    {
                                        postalCode = match.Value;
                                    }
                                    else if (rxCity.IsMatch(match.Value) && !match.Value.Contains('@')) // match city but not mail
                                    {
                                        city = match.Value;
                                    }
                                    else if (rxPhone.IsMatch(match.Value) && match.Length >= 9)
                                    {
                                        phone = match.Value;
                                    }
                                    else if (rxMail.IsMatch(match.Value))
                                    {
                                        mail = match.Value;
                                    }
                                }


                                //var variousItems = sSplit[i].Split("  ");

                                //for (int j = 0; j < variousItems.Length; j++)
                                //{
                                //    switch (j)
                                //    {
                                //        case 0:
                                //            // Get postalcode and city
                                //            string patternPostalCode = @"\d{3}\s\d{2}\s";
                                //            string patternCity = @"[\w -]+";
                                //            string patternPostalCodeCity = $"{patternPostalCode}|{patternCity}";
                                //            string patternPhone = @"[\d -]{8,16}+";
                                //            string patternMail = @"\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,6}";
                                //            //string patternPostalCodeCity = @"\d{3}\s\d{2}\s|\w";
                                //            Regex rxPostalCodeCity = new(patternPostalCodeCity);
                                //            MatchCollection matchPostalCodeCity = rxPostalCodeCity.Matches(variousItems[j]);

                                //            for (int indexPostalCodeCity = 0; indexPostalCodeCity < matchPostalCodeCity.Count; indexPostalCodeCity++)
                                //            {
                                //                switch (indexPostalCodeCity)
                                //                {
                                //                    case 0:
                                //                        postalCode = matchPostalCodeCity[indexPostalCodeCity].Value;
                                //                        break;
                                //                    case 1:
                                //                        city = matchPostalCodeCity[1].Value;
                                //                        break;
                                //                    default:
                                //                        break;
                                //                }
                                //            }
                                //            break;
                                //        case 1:
                                //            if (variousItems[j].Contains('@'))
                                //            {
                                //                phone = string.Empty;
                                //                mail = variousItems[j];
                                //            }
                                //            else
                                //            {
                                //                phone = variousItems[j];
                                //            }
                                //            break;
                                //        case 2:
                                //            mail = variousItems[j];
                                //            break;
                                //        default:
                                //            break;
                                //    }
                                //}


                                studentAdmissionItem.PostalCode = postalCode.Trim();
                                studentAdmissionItem.City = city.Trim();
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
                                            //String.Format("{0:(###) ###-####}", 8005551212);
                                            if(tmpTrimmedPhone.Length == 9)
                                            {
                                                studentAdmissionItem.Phone = String.Format("{0:000-## ## ##}", Convert.ToInt64(tmpTrimmedPhone));
                                            }
                                            else if (tmpTrimmedPhone.Length == 10)
                                            {
                                                studentAdmissionItem.Phone = String.Format("{0:000-### ## ##}", Convert.ToInt64(tmpTrimmedPhone));
                                            }
                                            else if (tmpTrimmedPhone.Length == 11)
                                            {
                                                studentAdmissionItem.Phone = String.Format("{0:000-### ### ##}", Convert.ToInt64(tmpTrimmedPhone));
                                            }
                                            
                                        }
                                        else
                                        {
                                            studentAdmissionItem.Phone = tmpPhone.Trim();
                                        }
                                    }
                                }
                                studentAdmissionItem.MailAddress = mail.Trim();
                                break;
                            case 6:
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
                            case 7:
                                studentAdmissionItem.AestheticChoice = sSplit[i].Trim();
                                break;
                            case 8:
                                studentAdmissionItem.Language11 = sSplit[i].Trim();
                                break;
                            case 9:
                                studentAdmissionItem.Language12 = sSplit[i].Trim();
                                break;
                            case 10:
                                studentAdmissionItem.Language22 = sSplit[i].Trim();
                                break;
                            case 11:
                                studentAdmissionItem.IndividualChoice1 = sSplit[i].Trim();
                                break;
                            case 12:
                                studentAdmissionItem.MotherTongue = sSplit[i].Trim();
                                break;
                            case 13:
                                studentAdmissionItem.SwedishAsSecondLanguage = sSplit[i].Trim();
                                break;
                            case 14:
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
                            case 15:
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
                            case 16:
                                studentAdmissionItem.ProgramOrientation = sSplit[i].Trim();
                                break;
                            case 17:
                                studentAdmissionItem.AbsentRollCall = sSplit[i].Trim();
                                break;
                            case 18:
                                studentAdmissionItem.RollCallComment = sSplit[i].Trim();
                                break;
                            default:
                                break;
                        }

                    }

                    studentAdmissionItems.Add(studentAdmissionItem);

                }
            }

            // put together the output
            // header and rows from the list
            StringBuilder output = new();

            string header =
                "PersonNumber\tAdmissionDate\tFirstName\tLastName\tFormerSchool\tAddress\t" +
                "PostalCode\tCity\tPhone\tMailAddress\tChoiceRank\tAestheticChoice\tLanguage11\t" +
                "Language12\tLanguage22\tIndividualChoice1\tMotherTongue\tSwedishAsSecondLanguage\t" +
                "Grades\tTestScore\tProgramOrientation\tAbsentRollCall\tRollCallComment";
            output.AppendLine(header);

            foreach (var item in studentAdmissionItems)
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
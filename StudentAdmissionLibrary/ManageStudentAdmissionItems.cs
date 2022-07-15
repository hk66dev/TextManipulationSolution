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
            string patternSSN = @"\d{6}|\d{8}[-\s]?\d{4} ";
            //string patternProgram = @"[A-Öa-ö, -]+program[A-Öa-ö -]+";
            Regex rxSSN = new Regex(patternSSN, RegexOptions.IgnoreCase);
            //Regex rxProgram = new Regex(patternProgram, RegexOptions.IgnoreCase);
            //Regex rxProgramSplit = new Regex(patternProgram, RegexOptions.IgnoreCase);

            //Match
            //MatchCollection matchedSSNs = rxSSN.Matches(InputText);
            //MatchCollection matchedPrograms = rxProgram.Matches(InputText);
            //String[] subStrings = rxProgramSplit.Split(InputText);
            String[] ssSSN= rxSSN.Split(InputText);

            StringBuilder sb = new StringBuilder();

            //List<string> l = new();

            foreach (var item in ssSSN)
            {
                sb.AppendLine(item);
            }

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
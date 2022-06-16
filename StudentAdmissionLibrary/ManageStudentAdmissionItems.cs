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
            int startPositionProgram = 0;
            int endPositionProgram = 0;



            //CharEnumerator ce = InputText.GetEnumerator();     
            //StringBuilder stringBuilder = new();
            //while (ce.MoveNext()) 
            //{
            //    stringBuilder.Append(ce.Current);
            //    string s = stringBuilder.ToString();                
            //}


            //MatchCollection matchedPrograms = rg.Matches(authors);  
            //string pattern = @"\b[M]\w+";  
            string pattern = @"\b[0601]\w+";
            Regex rx = new Regex(pattern, RegexOptions.IgnoreCase);

            //Match
            MatchCollection matchedPrograms = rx.Matches(InputText);
            
            StringBuilder sb = new StringBuilder();

            for (int count = 0; count < matchedPrograms.Count; count++)
            {
                string s = matchedPrograms[count].Value;
                sb.Append($"{s}{Environment.NewLine}");
            }

            //int index = InputText.IndexOf("program");

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
using System.Text;

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


            int index = InputText.IndexOf("programmet");
            return InputText;
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
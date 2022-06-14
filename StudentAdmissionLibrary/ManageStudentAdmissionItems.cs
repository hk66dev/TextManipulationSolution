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

        public string GetStudentAdmisionItems()
        { 
            int startPositionProgram = 0;
            int endPositionProgram = 0;
            CharEnumerator ce = InputText.GetEnumerator();
            while (ce.MoveNext()) 
            { 

            }


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
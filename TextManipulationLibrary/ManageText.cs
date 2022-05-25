using System.Linq;
using System.Text;

namespace TextManipulationLibrary
{
    public class ManageText
    {
        public string InputText { get; }
        public char[] Separators { get; }

        public ManageText(string inputText, char[] separators)
        {
            InputText = inputText;
            Separators = separators;
        }


        private List<TextLine> textLines = new();
        bool isManySeparatorTypeOfInputString = false;

        public string AddRowToList()
        {
            //todo
            foreach (var line in GetNextLine(InputText))
            {
                if (line.Length > 0)
                {
                    // split line in two parts
                    string[] columns = line.Split(Separators, 2, StringSplitOptions.TrimEntries);

                    if (columns[0].Length > 0 || columns[1].Length > 0)
                    {
                        switch (columns.Length)
                        {
                            case 0:
                                break;
                            case 1:
                                //columns.Append(string.Empty);
                                columns.Append("tom");
                                columns.Append("tom2");
                                break;
                            case 2:
                                // splitt second part
                                var s = columns[1].Split(Separators, 2, StringSplitOptions.None);
                                // check if second part has separators
                                if (s.Length > 1)
                                {
                                    // if so set isManySeparatorTypeOfText = true
                                    isManySeparatorTypeOfInputString = true;
                                }
                                break;
                            default:
                                break;
                        }

                        // format new textline
                        TextLine tl;
                        if (columns.Length > 1)
                        {
                            tl = new(columns[0], columns[1]);

                        }
                        else
                        {
                            tl = new(columns[0], String.Empty);
                        }

                        // add textline to list
                        textLines.Add(tl);
                    }
                }
            }


            // initiate output variable
            string output = string.Empty;

            // order the list
            textLines = textLines
                .OrderBy(x => x.Id)
                .ThenBy(x => x.Text)
                .ToList();

            // alter output text depending on number of separators
            switch (isManySeparatorTypeOfInputString)
            {
                case true:
                    output = ChangeToOneSeparatorTypeOfOutputString();
                    break;
                case false:
                    output = ChangeToManySeparatorsTypeOfOutputString();
                    break;
            }

            return output;
        }

        /// <summary>
        /// Change from "One Separator type of string"
        /// into "Many Separators type of string"
        /// </summary>
        /// <returns>string</returns>
        private string ChangeToManySeparatorsTypeOfOutputString()
        {
            //loop thru textLines and build output string
            var report = new StringBuilder();

            // on each id gather multiple text strings 
            string currentId = string.Empty;
            string newText = string.Empty;
            List<string> tempText = new();
            TextLine formatTextline;
            List<TextLine> tempTextLines = new();

            foreach (TextLine line in textLines)
            {
                // alter text and put in temporary list
                if (currentId != line.Id)
                {
                    if (tempText.Count > 0)
                    {
                        formatTextline = new(currentId, String.Join(",", tempText));
                        tempText = new();
                        tempTextLines.Add(formatTextline);
                    }
                    currentId = line.Id;
                    tempText.Add(line.Text.Trim());
                }
                else
                {
                    tempText.Add(line.Text.Trim());
                }
            }

            // put last row in temporary list
            if (tempText.Count > 0)
            {
                formatTextline = new(currentId, String.Join(",", tempText));
                tempTextLines.Add(formatTextline);
            }

            // loop through temporary list and add to report
            foreach (var item in tempTextLines)
            {
                // Add line to report
                report.Append($"{item.Id.Trim()}\t{item.Text.Trim()}{Environment.NewLine}");
            }

            return report.ToString();
        }

        /// <summary>
        /// Change from "Many Separators type of string"
        /// into "One Separator type of string"
        /// </summary>
        /// <returns>string</returns>
        private string ChangeToOneSeparatorTypeOfOutputString()
        {

            //loop through textLines and build output string
            var report = new StringBuilder();

            foreach (TextLine line in textLines)
            {
                // split text part of textline into array
                var stringArray = line.Text.Split(Separators, StringSplitOptions.TrimEntries);

                foreach (var s in stringArray)
                {
                    // Add line to report
                    report.Append($"{line.Id.Trim()}\t{s.Trim()}");
                }
            }

            // return string
            return report.ToString();
        }

        /// <summary>
        /// Read next text line
        /// </summary>
        /// <param name="text"></param>
        /// <returns>string</returns>
        internal static IEnumerable<string> GetNextLine(string text)
        {
            using (var reader = new StringReader(text))
            {
                string s;
                while ((s = reader.ReadLine()) != null)
                {
                    yield return s;
                }
            }
        }
    }
}

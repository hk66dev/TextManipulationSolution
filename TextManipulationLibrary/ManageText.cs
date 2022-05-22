using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                // split line in two parts
                string[] columns = line.Split(Separators, 2, StringSplitOptions.TrimEntries);

                switch (columns.Length)
                {
                    case 0:
                        break;
                    case 1:
                        columns.Append(string.Empty);
                        break;
                    case 2:
                        // splitt second part and check if there is separators
                        var s = columns[1].Split(Separators, 2, StringSplitOptions.None);
                        // check if second part has separators
                        if (s.Length > 0)
                        {
                            // if so set isManySeparatorTypeOfText = true
                            isManySeparatorTypeOfInputString = true;
                        }
                        break;
                    default:
                        break;
                }

                // Add new text line to list
                TextLine tl = new(columns[0], columns[1]);
                textLines.Add(tl);
            }


            // initiate output variable
            string output = string.Empty;

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
            string newString = string.Empty;    

            foreach (TextLine line in textLines)
            {
                // if currentId equal to line.Id add text to string
                if (currentId == line.Id)
                {
                    newString += $"{line.Text.Trim()}/t";
                }
                else
                {
                    // if newString not empty append new line to report
                    if (newString != string.Empty)
                    {
                        // Add line to report
                        report.Append($"{line.Id.Trim()}\t{newString.Trim()}");
                    }

                    // update currentId
                    currentId = line.Id;
                    // update newString
                    newString = $"{line.Text.Trim()}/t";
                }
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

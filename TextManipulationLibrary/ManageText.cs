using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextManipulationLibrary
{
    public class ManageText
    {
        public string Text { get; }

        public ManageText(string text)
        {
            Text = text;
        }

        private List<TextLine> text = new();
        bool isManySeparatorTypeOfText = false;

        public string AddRowToList()
        {
            //todo
            foreach (var line in GetNextLine(Text))
            {
                // split line in two parts
                string[] col = line.Split(new char[] { ',', ';', '\t' }, 2, StringSplitOptions.TrimEntries);

                switch (col.Length)
                {
                    case 0:
                        break;
                    case 1:
                        col.Append(string.Empty);
                        break;
                    case 2:
                        // splitt second part
                        var s = col[1].Split(new char[] { ',', ';', '\t' }, 2, StringSplitOptions.None);
                        // check if second part has separators
                        if (s.Length > 0)
                        {
                            // if so set isManySeparatorTypeOfText = true
                            isManySeparatorTypeOfText = true;
                        }
                        break;
                    default:
                        break;
                }

                // new text line
                TextLine tl = new(col[0], col[1]);
                text.Add(tl);
            }

            //todo
            string output = string.Empty;

            switch (isManySeparatorTypeOfText)
            {   case false:
                    output = GetOneSeparatorTypeOfText();
                    break;
                case true:
                    output = GetManySeparatorTypeOfText();
                    break;
                default:
                    break;
            }



            return Text;
        }

        private string GetOneSeparatorTypeOfText()
        {
            //todo
            throw new NotImplementedException();
        }

        private string GetManySeparatorTypeOfText()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Read next line
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
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

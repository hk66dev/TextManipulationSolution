using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextManipulationLibrary
{
    internal class TextLine
    {
        public string Id { get; }
        public string Text { get; } 

        /// <summary>
        /// Textline
        /// </summary>
        /// <param name="id"></param>
        /// <param name="text"></param>
        public TextLine(string id, string text)
        {
            Id = id;
            Text = text;
        }

    }
}

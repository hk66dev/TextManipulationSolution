// See https://aka.ms/new-console-template for more information
using System.Text;
using TextManipulationLibrary;

// separators
char[] separators = new char[] { ',', ';', '\t' };

//string input = "NA21A/SVESVE02	090909-0909\r\n\r\nNA21A/SVESVE02	 090909-0909 , 080808 0808 \r\nNA21A/SVESVE02\r\nNA21A/SVESVE02 \r\nNA21A/SVESVE02	090909-0909,\r\nNA21A/SVESVE02	090909-0909,080808-0808,070707-0707,060606-0606\r\nNA21B/SVESVE02	100909-0909,080808-0808,070707-0707,060606-0606,050505-0505\r\nNA21B/SVESVE02	110909-0909,080808-0808,070707-0707,060606-0606";
StringBuilder sbInput = new ();

sbInput.Append($"SA21A/ENGENG06\t120909-0909,110909-0909,100909-0909 {Environment.NewLine}");
sbInput.Append($"IND2/ENGENG06\t120909-0909,090909-0909,IND2/ENGENG06,080909-0909,070909-0909,110909-0909,100909-0909,090909-0909,080909-0909,070909-0909 {Environment.NewLine}");
sbInput.Append($"NA21A/ENGENG06\t120909-0909,110909-0909,100909-0909 {Environment.NewLine}");




////Check if character is whitespece
//bool result;
//char ch2 = '-';
//result = Char.IsWhiteSpace(ch2);
//Console.WriteLine(result);

ManageText mt = new(sbInput.ToString(), separators);

Console.WriteLine($"Output:{Environment.NewLine}{mt.AddRowToList()}");
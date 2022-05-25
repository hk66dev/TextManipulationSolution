// See https://aka.ms/new-console-template for more information
using System.Text;
using TextManipulationLibrary;

// separators
char[] separators = new char[] { ',', ';', '\t' };

//string input = "NA21A/SVESVE02	090909-0909\r\n\r\nNA21A/SVESVE02	 090909-0909 , 080808 0808 \r\nNA21A/SVESVE02\r\nNA21A/SVESVE02 \r\nNA21A/SVESVE02	090909-0909,\r\nNA21A/SVESVE02	090909-0909,080808-0808,070707-0707,060606-0606\r\nNA21B/SVESVE02	100909-0909,080808-0808,070707-0707,060606-0606,050505-0505\r\nNA21B/SVESVE02	110909-0909,080808-0808,070707-0707,060606-0606";
StringBuilder sbInput = new ();
//sbInput.Append($"NA21A/SVESVE02	 010909-0909{Environment.NewLine}");
//sbInput.Append($"NA21A/SVESVE02	 {Environment.NewLine}");
//sbInput.Append($"BF21A/ENGENG06	 {Environment.NewLine}");
//sbInput.Append($"NA21A/SVESVE02 {Environment.NewLine}");
//sbInput.Append($"BF21A/ENGENG06{Environment.NewLine}");

//sbInput.Append($"{Environment.NewLine}");
//sbInput.Append($"\t{Environment.NewLine}");
//sbInput.Append($"\td{Environment.NewLine}");

sbInput.Append($"Hej{Environment.NewLine}");
sbInput.Append($"BF21A/ENGENG06 020909-0909{Environment.NewLine}");
sbInput.Append($"NA21A/SVESVE02   030909 0909 {Environment.NewLine}");


//sbInput.Append($"IND2/ENGENG06	 040909-0909  {Environment.NewLine}");
//sbInput.Append($"BF21A/ENGENG06	 050909-0909	 {Environment.NewLine}");
//sbInput.Append($"NA21A/SVESVE02 060909 0909{Environment.NewLine}");
//sbInput.Append($"IND2/ENGENG06	 070909 0909 {Environment.NewLine}");
//sbInput.Append($"NA21A/SVESVE02	 080909 0909 {Environment.NewLine}");
//sbInput.Append($"BF21A/ENGENG06	 090909 0909 {Environment.NewLine}");
//sbInput.Append($"IND2/ENGENG06	 110909 0909 {Environment.NewLine}");
//sbInput.Append($"BF21A/ENGENG06	 100909 0909 {Environment.NewLine}");
//sbInput.Append($"IND2/ENGENG06	 110909 0909 {Environment.NewLine}");
//sbInput.Append($"BF21A/ENGENG06	 110909 0909 {Environment.NewLine}");

////Check if character is whitespece
//bool result;
//char ch2 = '-';
//result = Char.IsWhiteSpace(ch2);
//Console.WriteLine(result);

ManageText mt = new(sbInput.ToString(), separators);

Console.WriteLine($"Output:{Environment.NewLine}{mt.AddRowToList()}");
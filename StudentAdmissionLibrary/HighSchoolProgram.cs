using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdmissionLibrary
{
    public class HighSchoolProgram
    {
        public string ProgramCode { get; set; } = string.Empty;
        public string ProgramName { get; set; } = string.Empty;

        /// <summary>
        /// Empty constructor
        /// </summary>
        public HighSchoolProgram()
        {
            ProgramCode = string.Empty;
            ProgramName = string.Empty;
        }

        public HighSchoolProgram(string programCode, string programName)
        {
            ProgramCode = programCode;
            ProgramName = programName;
        }
    }

    internal class HighSchoolPrograms
    {
        public List<HighSchoolProgram> Programs { get; set; } = [];

        public  HighSchoolPrograms()
        {
            Programs.Add(new HighSchoolProgram() { ProgramCode = "AHADM", ProgramName = "Anpassad gymnasieskola - Administration, handel - och varuhantering" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "BA", ProgramName = "Bygg- och anläggningsprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "BF", ProgramName = "Barn- och fritidsprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "EE", ProgramName = "El- och energiprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "EK", ProgramName = "Ekonomiprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "ESEST", ProgramName = "Estetiska programmet - Estetik och media" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "ESMUS", ProgramName = "Estetiska programet- Musik" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "FGFOR", ProgramName = "Anpassad gymnasieskola - Fordonsvård och godshantering" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "FS", ProgramName = "Försäljnings- och serviceprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "FT", ProgramName = "Fordons- och transportprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "HRHOT", ProgramName = "Anpassad gymnasieskola - Hotell, restaurang och bageri" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "HTHOT0L", ProgramName = "Hotell- och turismprogrammet - lärling" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "HVFRS", ProgramName = "Hantverksprogrammet- Frisör, barberare och hår- och makeupstylist" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IAIND", ProgramName = "Anpassad gymnasieskola - Individuella programmet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMAAUS", ProgramName = "Individuellt alternativ - Förstärkt program" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMA", ProgramName = "Individuellt alternativ" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMS", ProgramName = "Språkintroduktion" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMVBA", ProgramName = "Programinriktat - Bygg och anläggningsprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMVBF", ProgramName = "Programinritkat - Barn och fritidsprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMVEE", ProgramName = "Programinriktat val- El och energiprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMVEK", ProgramName = "Programinriktat val -Ekonomiprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMVESEST", ProgramName = "Programinriktat val - Estetiska programmet mot estetik och media" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMVESMUS", ProgramName = "Programinriktat val- Estetiska programmet - Musik" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMVFS", ProgramName = "Programinriktatval - Försäljnings- och service" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMVFT", ProgramName = "Programinriktat val- Fordons- och transportprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMVHT", ProgramName = "Programinriktat val mot Hotell och turism programmet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMVHVFRS", ProgramName = "Programinriktat val -Hantverksprogrammet- Frisör, barberare och hår- och makeupstylist" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMVNA", ProgramName = "Programinriktat val -Naturvetenskapsprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMVNB", ProgramName = "Programinriktat val- Naturbruksprogrammet - Djurpark" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMVRLKOK", ProgramName = "Programinriktat val - Restaurang och livsmedelsprogrammet - Kök och servering" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMVSA", ProgramName = "Programinriktat val- Samhällsvetenskapsprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMVTE", ProgramName = "Programinriktat val -Teknikprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMVVO", ProgramName = "Programinriktat val - Vård- och omsorgsprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMYBA", ProgramName = "Yrkesintroduktion mot Bygg och anläggningsprogrammet - Fastighetsskötsel" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMYFS", ProgramName = "Yrkesintroduktion mot Försäljning och service" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMYFT", ProgramName = "Yrkesintroduktion mot Fordon -och transport - Personbil" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMYNB", ProgramName = "Yrkesintroduktion mot Naturbruksprogrammet - Trädgård" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMYRLKOK", ProgramName = "Yrkesintroduktion mot Restaurang och livsmedelsprogrammet - Kök och servering" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMYVO", ProgramName = "Yrkesintroduktion mot vård- och omsorgsprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "NA", ProgramName = "Naturvetenskapsprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "NBDJR", ProgramName = "Naturbruksprogrammet- Djurvård" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "RL", ProgramName = "Restaurang- och livsmedelsprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "SA", ProgramName = "Samhällsvetenskapsprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "SKSKO", ProgramName = "Anpassad gymnasieskola - Skog, mark och djur" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "TE", ProgramName = "Teknikprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "VIDES", ProgramName = "Fjärde året Teknikprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "VIPRO", ProgramName = "Fjärde åretTeknikprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "VO", ProgramName = "Vård- och omsorgsprogrammet" });
        }
    }

    /*
 Programkod	Programnamn
AHADM	Anpassad gymnasieskola - Administration, handel - och varuhantering
BA	Bygg- och anläggningsprogrammet
BF	Barn- och fritidsprogrammet
EE	El- och energiprogrammet
EK	Ekonomiprogrammet
ESEST	Estetiska programmet - Estetik och media
ESMUS	Estetiska programet- Musik
FGFOR	Anpassad gymnasieskola - Fordonsvård och godshantering
FS	Försäljnings- och serviceprogrammet
FT	Fordons- och transportprogrammet
HRHOT	Anpassad gymnasieskola - Hotell, restaurang och bageri
HTHOT0L	Hotell- och turismprogrammet - lärling
HVFRS	Hantverksprogrammet- Frisör, barberare och hår- och makeupstylist
IAIND	Anpassad gymnasieskola - Individuella programmet
IMAAUS	Individuellt alternativ - Förstärkt program
IMA	Individuellt alternativ
IMS	Språkintroduktion
IMVBA	Programinriktat - Bygg och anläggningsprogrammet
IMVBF	Programinritkat - Barn och fritidsprogrammet
IMVEE	Programinriktat val- El och energiprogrammet
IMVEK	Programinriktat val -Ekonomiprogrammet
IMVESEST	Programinriktat val - Estetiska programmet mot estetik och media
IMVESMUS	Programinriktat val- Estetiska programmet - Musik
IMVFS	Programinriktatval - Försäljnings- och service
IMVFT	Programinriktat val- Fordons- och transportprogrammet
IMVHT	Programinriktat val mot Hotell och turism programmet
IMVHVFRS	Programinriktat val -Hantverksprogrammet- Frisör, barberare och hår- och makeupstylist
IMVNA	Programinriktat val -Naturvetenskapsprogrammet
IMVNB	Programinriktat val- Naturbruksprogrammet - Djurpark
IMVRLKOK	Programinriktat val - Restaurang och livsmedelsprogrammet - Kök och servering
IMVSA	Programinriktat val- Samhällsvetenskapsprogrammet
IMVTE	Programinriktat val -Teknikprogrammet
IMVVO	Programinriktat val - Vård- och omsorgsprogrammet
IMYBA	Yrkesintroduktion mot Bygg och anläggningsprogrammet - Fastighetsskötsel
IMYFS	Yrkesintroduktion mot Försäljning och service
IMYFT	Yrkesintroduktion mot Fordon -och transport - Personbil
IMYNB	Yrkesintroduktion mot Naturbruksprogrammet - Trädgård
IMYRLKOK	Yrkesintroduktion mot Restaurang och livsmedelsprogrammet - Kök och servering
IMYVO	Yrkesintroduktion mot vård- och omsorgsprogrammet
NA	Naturvetenskapsprogrammet
NBDJR	Naturbruksprogrammet- Djurvård
RL	Restaurang- och livsmedelsprogrammet
SA	Samhällsvetenskapsprogrammet
SKSKO	Anpassad gymnasieskola - Skog, mark och djur
TE	Teknikprogrammet
VIDES	Fjärde året Teknikprogrammet
VIPRO	Fjärde åretTeknikprogrammet
VO	Vård- och omsorgsprogrammet
*/
}

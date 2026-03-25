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
            Programs.Add(new HighSchoolProgram() { ProgramCode = "BA25", ProgramName = "Bygg- och anläggningsprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "BF25", ProgramName = "Barn- och fritidsprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "EE25", ProgramName = "El- och energiprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "EK25", ProgramName = "Ekonomiprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "ESESM", ProgramName = "Estetiska programmet - Estetik och media" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "ESMUK", ProgramName = "Estetiska programmet - Musik" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "FS25", ProgramName = "Försäljnings- och serviceprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "FT25", ProgramName = "Fordons- och transportprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "HT25", ProgramName = "Hotell- och turismprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "HTHT00L", ProgramName = "Hotell- och turismprogrammet - lärlingsutbildning" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "FRFRR", ProgramName = "Frisör- och stylistprogrammet - Frisör" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "NA25", ProgramName = "Naturvetenskapsprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "NBDJD", ProgramName = "Naturbruksprogrammet - Djurvård" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "RL25", ProgramName = "Restaurang- och livsmedelsprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "SA25", ProgramName = "Samhällsvetenskapsprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "TE25", ProgramName = "Teknikprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "VO25", ProgramName = "Vård- och omsorgsprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "VIDEI", ProgramName = "Fjärde året Teknikprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "VIPRU", ProgramName = "Fjärde åretTeknikprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMS00G", ProgramName = "Språkintroduktion" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMVBAG", ProgramName = "Programinriktat val mot Bygg- och anläggningsprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMVBFG", ProgramName = "Programinriktat val mot Barn och fritidsprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMVEEG", ProgramName = "Programinriktat val mot El- och energiprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMVEKG", ProgramName = "Programinriktat val mot Ekonomiprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMVESGESM", ProgramName = "Programinriktat val mot Estetiska programmet - Estetik och media" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMVESGMUK", ProgramName = "Programinriktat val mot Estetiska programmet - Musik" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMVFSG", ProgramName = "Programinriktat val mot Försäljnings- och service" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMVFTG", ProgramName = "Programinriktat val mot - Fordons- och transportprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMVHTG", ProgramName = "Programinriktat val mot Hotell- och turismprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMVFRG", ProgramName = "Programinriktat val mot Frisör och stylistprogrammet - Frisör" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMVNAG", ProgramName = "Programinriktat val mot Naturvetenskapsprogramme" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMVNBG", ProgramName = "Programinriktat val mot Naturbruksprogrammet - Djurvård" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMVRLG", ProgramName = "Programinriktat val mot Restaurang och livsmedelsprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMVSAG", ProgramName = "Programinriktat val mot Samhällsvetenskapsprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMVTEG", ProgramName = "Programinriktat val mot Teknikprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMVVOG", ProgramName = "Programinriktat val mot Vård- och omsorgsprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMYBAG", ProgramName = "Yrkesintroduktion mot Bygg och anläggningsprogrammet - Fastighetsskötsel" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMYFSG", ProgramName = "Yrkesintroduktion mot Försäljning och service" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMYFTG", ProgramName = "Yrkesintroduktion mot Fordon -och transport - Personbil" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMYNBG", ProgramName = "Yrkesintroduktion mot Naturbruksprogrammet - Trädgård" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMYRLG", ProgramName = "Yrkesintroduktion mot Restaurang och livsmedelsprogrammet - Kök och servering" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMYVOG", ProgramName = "Yrkesintroduktion mot vård- och omsorgsprogrammet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "AHADM", ProgramName = "Anpassad gymnasieskola - Handel och service" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "FGFOR", ProgramName = "Anpassad gymnasieskola - Fordonsvård och godshantering" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IAIND", ProgramName = "Anpassad gymnasieskola - Individuella programmet" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "HRHOT", ProgramName = "Anpassad gymnasieskola - Hotell, restaurang och bageri" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "SKSKO", ProgramName = "Anpassad gymnasieskola - Skog, mark och djur" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMA00U1", ProgramName = "Individuellt alternativ - Förstärkt program" });
            Programs.Add(new HighSchoolProgram() { ProgramCode = "IMA00U", ProgramName = "Individuellt alternativ" });
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

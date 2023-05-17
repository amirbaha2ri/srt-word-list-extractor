using System.Text.RegularExpressions;

namespace SWE.Service.Implement
{
    public class WordService
    {
        public WordService()
        {

        }
        public List<string> GetWords(string srtContent)
        {

            string textFile = @"D:\Works\0 Sample Files\srt\topgun.srt";
            if (File.Exists(textFile))
            {
                srtContent = File.ReadAllText(textFile);
            }



            var res = new List<string>();
            string[] souceSrt = Regex.Split(srtContent, @"(?:\r?\n)*\d+\r?\n\d{2}:\d{2}:\d{2},\d{3} --> \d{2}:\d{2}:\d{2},\d{3}\r?\n");
            foreach (var part in souceSrt)
            {

                if (HasMoreThanOneWord(part))
                {
                    var partWords = BreakTextpart(part);
                    if (partWords != null)
                    {
                        res.AddRange(partWords);
                    }
                }
                else if (part != "")
                    res.Add(part);
            }
            res = res.Distinct().ToList();
            return res;
        }
        private bool HasMoreThanOneWord(string textPart)
        {
            if (textPart.Length > 0)
            {
                if (textPart.Contains(" "))
                {
                    return true;
                }
            }
            return false;
        }

        private List<string> BreakTextpart(string textPart)
        {
            try
            {
                var res = new List<string>();
                textPart = textPart.Replace("[", " ");
                textPart = textPart.Replace("]", " ");
                Regex pattern = new Regex("[;{}♪,\t.1234567890]|[\n]|[\r]|[\"]|[\']|[?]|[:]|[\\ ]{2}");
                pattern.Replace(textPart, " ");

                string[] words = textPart.Split();
                foreach (var w in words)
                {
                    if (w.Length > 1)
                    {
                        res.Add(w.ToLower());
                    }
                }
                return res;
            }
            catch (Exception ex)
            {

                throw new Exception("error",ex);
            }
            
        }
    }
}

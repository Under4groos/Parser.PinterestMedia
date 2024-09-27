using Newtonsoft.Json;
using Parser.PinterestMediaLib.Structures;
using System.Text.RegularExpressions;

namespace Parser.PinterestMediaLib
{
    public class PinParser : HttpClient
    {
        public List<Video> LinksVideo = new List<Video>();

        private string __PWS_INITIAL_PROPS__ = @"<script id=""__PWS_INITIAL_PROPS__"" type=""application\/json"">.+?<\/script>";
        private string __PWS_INITIAL_PROPS__repl_start = "<script id=\"__PWS_INITIAL_PROPS__\" type=\"application/json\">";
        private string REGEX___PWS_INITIAL_PROPS__repl_json = "\"add_fields=.+?,fetch_visual_search_objects=.+?noCache=?(true|false)\"";

        public void DefaultHeaders()
        {
            this.DefaultRequestHeaders.Add(
        "user-agent", "Mozilla/5.0 (X11; Linux aarch64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.188 Safari/537.36 CrKey/1.54.250320");

            this.DefaultRequestHeaders.Add(
               "Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");

            this.DefaultRequestHeaders.Add(
               "Accept-Language", "en-US,en;q=0.5");

            this.DefaultRequestHeaders.Add(
             "Connection", "keep-alive");
        }

        public void Parse(string URL)
        {
            string page = this.GetStringAsync(URL).Result;
            foreach (Match item in Regex.Matches(page, __PWS_INITIAL_PROPS__))
            {
                string json_data = item.Value.Trim().Replace(__PWS_INITIAL_PROPS__repl_start, "");
                json_data = json_data.Replace("</script>", "");
                json_data = Regex.Replace(json_data, REGEX___PWS_INITIAL_PROPS__repl_json, "objdata");


                json_data = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(json_data), Formatting.Indented);
                try
                {

                    // \"videos\":.+\{[\w\W]+?\}[\w\W]+?\"repin_count\"

                    bool p_ = false;
                    string json_dada = "";
                    string _line = string.Empty;
                    foreach (string line in json_data.Split("\n"))
                    {
                        _line = line.Trim();
                        if (_line.StartsWith("\"url\": \"https://v1.pinimg.com/videos/"))
                        {
                            _line = Regex.Match(_line, "https:(\\/){2}.+\\.pinimg.com(\\/.+?\\.(mp4))").Value;
                            if (_line == string.Empty)
                                continue;
                            var video_ = new Video()
                            {
                                Url = _line
                            };



                            if (LinksVideo.IndexOf(video_) == -1)
                            {
                                LinksVideo.Add(video_);
                            }

                        }

                    }



                }
                catch (Exception e)
                {
                    Console.Write(e.Message);

                }










            }
        }
    }
}

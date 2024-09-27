namespace Parser.PinterestMediaLib.Structures
{
    public sealed class Video
    {
        public string Url;
        public string UrlImg;
        public override string ToString()
        {
            return $"{Url}";
        }
        public override bool Equals(object? obj)
        {
            if (obj is Video video)
            {
                return video.Url == Url;
            }
            return false;
        }
    }

}

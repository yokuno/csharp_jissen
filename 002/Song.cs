namespace _002
{
    class Song
    {
        public string Title { get; set; }
        public string ArtistName { get; set; }
        public int Length { get; set; }


        public Song(string title, string artistName, int length)
        {
            this.Title = title;
            this.ArtistName = artistName;
            this.Length = length;
        }
    }
}

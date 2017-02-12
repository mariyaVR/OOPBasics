using OnlineRadioDatabase.Exceptions;

namespace OnlineRadioDatabase
{
    public class Song
    {
        private string artistName;
        private string songName;

        public Song(string artistName, string songName, SongLength length)
        {
            this.ArtistName = artistName;
            this.songName = songName;
            this.Length = length;
        }

        public string ArtistName
        {
            get { return this.artistName; }
            set
            {
                if (value.Length < 3 || value.Length > 20 )
                {
                    throw new InvalidArtistNameException();
                }

                this.artistName = value;
            }
        }

        public string SongName
        {
            get { return this.songName; }
            set
            {
                if (value == null || value.Length < 3 || value.Length > 30)
                {
                    throw new InvalidSongNameException();
                }

                this.songName = value;
            }
        }

        public SongLength Length { get; private set; }
    }
}
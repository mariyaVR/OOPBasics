using OnlineRadioDatabase.Exceptions;

namespace OnlineRadioDatabase
{
    public class SongLength
    {
        private long minutes;
        private long seconds;

        public SongLength(long minutes, long seconds)
        {
            this.Minutes = minutes;
            this.Seconds = seconds;
        }

        public long Minutes
        {
            get { return this.minutes; }
            set
            {
                if (value < 0 || value > 14)
                {
                    throw new InvalidSongMinutesException();
                }

                this.minutes = value;
            }
        }

        public long Seconds
        {
            get { return this.seconds; }
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new InvalidSongSecondsException();
                }

                this.seconds = value;
            }
        }
        public long FullSongLengthInSeconds { get; private set; }

        public void CalculateTime()
        {
            this.FullSongLengthInSeconds = this.minutes * 60 + this.seconds;
        }
    }
}
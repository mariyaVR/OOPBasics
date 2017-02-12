using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRadioDatabase.Exceptions
{
    public class InvalidSongNameException : InvalidSongException
    {
        private new const string Message = "Song name should be between 3 and 30 symbols.";
        public InvalidSongNameException() : base(Message)
        {
        }
    }
}

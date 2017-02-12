using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRadioDatabase.Exceptions
{
    public class InvalidSongException : Exception
    {
        private new const string Message = "Invalid song.";
        public InvalidSongException() : base(Message)
        {
        }

        public InvalidSongException(string message) : base(message)
        {
        }
    }
}
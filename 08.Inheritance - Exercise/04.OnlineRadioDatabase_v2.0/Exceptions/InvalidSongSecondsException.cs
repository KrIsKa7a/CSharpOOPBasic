using System;
using System.Collections.Generic;
using System.Text;

public class InvalidSongSecondsException : InvalidSongLenghtException
{
    public override string Message => "Song seconds should be between 0 and 59.";
}

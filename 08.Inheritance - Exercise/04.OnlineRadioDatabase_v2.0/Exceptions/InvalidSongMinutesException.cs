using System;
using System.Collections.Generic;
using System.Text;

public class InvalidSongMinutesException : InvalidSongLenghtException
{
    public override string Message => "Song minutes should be between 0 and 14.";
}

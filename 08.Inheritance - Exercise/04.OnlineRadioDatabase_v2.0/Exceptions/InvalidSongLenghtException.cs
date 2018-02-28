using System;
using System.Collections.Generic;
using System.Text;

public class InvalidSongLenghtException : InvalidSongException
{
    public override string Message => "Invalid song length.";
}

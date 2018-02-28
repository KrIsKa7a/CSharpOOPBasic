using System;
using System.Collections.Generic;
using System.Text;

public class InvalidArtistNameException : InvalidSongException
{
    public override string Message => "Artist name should be between 3 and 20 symbols.";
}

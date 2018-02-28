using System;
using System.Collections.Generic;
using System.Text;

public class Song
{
    private string artist;
    private string name;
    private string lenght;
    private int minutes;
    private int seconds;

    public Song(string artist, string name, string lenght)
    {
        this.Artist = artist;
        this.Name = name;
        this.Lenght = lenght;
    }

    public string Artist
    {
        get { return this.artist; }
        private set
        {
            if (value.Length < 3 || value.Length > 20)
            {
                throw new InvalidArtistNameException();
            }

            this.artist = value;
        }
    }

    public string Name
    {
        get { return this.name; }
        private set
        {
            if (value.Length < 3 || value.Length > 30)
            {
                throw new InvalidSongNameException();
            }

            this.name = value;
        }
    }

    public string Lenght
    {
        get { return this.lenght; }
        private set
        {
            var tokens = value
                .Split(":");

            if (tokens.Length != 2)
            {
                throw new InvalidSongLenghtException();
            }

            int currMin;
            int currSec;

            bool parsed1 = int.TryParse(tokens[0], out currMin);
            bool parsed2 = int.TryParse(tokens[1], out currSec);

            if (!(parsed1 && parsed2))
            {
                throw new InvalidSongLenghtException();
            }

            this.lenght = value;
            SetMinutesAndSeconds(currMin, currSec);
        }
    }

    public int Minutes
    {
        get { return this.minutes; }
    }

    public int Seconds
    {
        get { return this.seconds; }
    }

    private void SetMinutesAndSeconds(int currMin, int currSec)
    {
        if (currMin < 0 || currMin > 14)
        {
            throw new InvalidSongMinutesException();
        }

        if (currSec < 0 || currSec > 59)
        {
            throw new InvalidSongSecondsException();
        }

        this.minutes = currMin;
        this.seconds = currSec;
    }
}

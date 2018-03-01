using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Smartphone : ICallable, IBrowseable
{
    private string model;
    private string number;
    private string url;

    public Smartphone(string model)
    {
        this.Model = model;
    }

    public string Model
    {
        get { return this.model; }
        private set { this.model = value; }
    }

    public string BrowseURL(string website)
    {

        bool hasDigit = website.Any(char.IsDigit);
        if (hasDigit)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Invalid URL!");
            return sb.ToString();
        }
        else
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Browsing: {website}!");
            return sb.ToString();
        }
    }

    public string CallNumber(string phone)
    {
        bool hasCharacter = phone.Any(char.IsLetter);
        if (hasCharacter)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Invalid number!");
            return sb.ToString();
        }
        else
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Calling... {phone}");
            return sb.ToString();
        }
    }
}

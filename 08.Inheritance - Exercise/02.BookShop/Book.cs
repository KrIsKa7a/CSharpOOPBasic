using System;
using System.Collections.Generic;
using System.Text;

public class Book
{
    private const int MIN_TITLE_LENGHT = 3;

    private string title;
    private string author;
    private decimal price;

    public Book(string author, string title, decimal price)
    {
        this.Author = author;
        this.Title = title;
        this.Price = price;
    }

    protected string Author
    {
        get { return this.author; }
        private set
        {
            ValidateName(value);

            this.author = value;
        }
    }

    protected string Title
    {
        get { return this.title; }
        private set
        {
            if (value.Length < MIN_TITLE_LENGHT)
            {
                throw new ArgumentException("Title not valid!");
            }

            this.title = value;
        }
    }

    public virtual decimal Price
    {
        get { return this.price; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }

            this.price = value;
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Type: {this.GetType()}")
            .AppendLine($"Title: {this.Title}")
            .AppendLine($"Author: {this.Author}")
            .AppendLine($"Price: {this.Price:f2}");

        var result = sb.ToString().TrimEnd();

        return result;
    }

    private void ValidateName(string fullName)
    {
        var fullNameTokens = fullName.Split();

        if (fullNameTokens.Length == 2)
        {
            var secondName = fullNameTokens[1];

            if (Char.IsDigit(secondName[0]))
            {
                throw new ArgumentException("Author not valid!");
            }
        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        var accounts = new Dictionary<int, BankAccount>();

        var command = Console.ReadLine();

        while (command != "End")
        {
            var cmdArgs = command
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var cmdType = cmdArgs[0];
            var id = int.Parse(cmdArgs[1]);

            if (cmdType == "Create")
            {
                CreateAccount(accounts, id);
            }
            else if (cmdType == "Deposit")
            {
                DepositToAccount(accounts, cmdArgs, id);
            }
            else if (cmdType == "Withdraw")
            {
                WithdrawFromAccount(accounts, cmdArgs, id);
            }
            else if (cmdType == "Print")
            {
                PrintAccount(accounts, id);
            }

            command = Console.ReadLine();
        }
    }

    private static void PrintAccount(Dictionary<int, BankAccount> accounts, int id)
    {
        if (CheckIfAccountIsExistant(accounts, id))
        {
            Console.WriteLine("Account does not exist");
            return;
        }
        var acc = accounts[id];
        Console.WriteLine(acc);
    }

    private static void WithdrawFromAccount(Dictionary<int, BankAccount> accounts, string[] cmdArgs, int id)
    {
        var amount = decimal.Parse(cmdArgs[2]);

        if (CheckIfAccountIsExistant(accounts, id))
        {
            Console.WriteLine("Account does not exist");
            return;
        }

        var acc = accounts[id];

        if (amount > acc.Balance)
        {
            Console.WriteLine("Insufficient balance");
            return;
        }

        acc.Withdraw(amount);
        accounts[id] = acc;
    }

    private static void DepositToAccount(Dictionary<int, BankAccount> accounts, string[] cmdArgs, int id)
    {
        var amount = decimal.Parse(cmdArgs[2]);

        if (CheckIfAccountIsExistant(accounts, id))
        {
            Console.WriteLine("Account does not exist");
            return;
        }

        var acc = accounts[id];
        acc.Deposit(amount);
        accounts[id] = acc;
    }

    private static bool CheckIfAccountIsExistant(Dictionary<int, BankAccount> accounts, int id)
    {
        return !accounts.ContainsKey(id);
    }

    private static void CreateAccount(Dictionary<int, BankAccount> accounts, int id)
    {
        if (accounts.ContainsKey(id))
        {
            Console.WriteLine("Account already exists");
        }
        else
        {
            var acc = new BankAccount();
            acc.Id = id;
            accounts[id] = acc;
        }
    }
}


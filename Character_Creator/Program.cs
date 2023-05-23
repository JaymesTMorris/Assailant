using System.Data;
using System.Diagnostics;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using Shared;

class Program
{
    public static void Main(string[] args)
    {
        PrintMainMenu();
        string userInput = Console.ReadLine();

        HandleUserInput(userInput);
    }

    private static void HandleUserInput(string userInput)
    {
        if (userInput == "1")
        {
            CreateCharacter();

        }
        else if (userInput == "2")
        {
            ViewCharacters();
        }
        else if (userInput == "3")
        {
            Environment.Exit(0);
        }
        else
        {
            InvalidResponseMenu();
        }
    }

    private static void CreateCharacter()
    {
        Character characterToAdd = new Character();
        int hp, mp, str, agl, con, intel, wis, atkPwr, spPwr, mgArmor, physArmor;

        Console.Clear();
        Console.Write("Name: ");
        characterToAdd.Name = Console.ReadLine();
        Console.Write("Health: ");
        hp = int.Parse(Console.ReadLine());
        Console.Write("Mana: ");
        mp = int.Parse(Console.ReadLine());
        Console.Write("Strength: ");
        str = int.Parse(Console.ReadLine());
        Console.Write("Agility: ");
        agl = int.Parse(Console.ReadLine());
        Console.Write("Constitution: ");
        con = int.Parse(Console.ReadLine());
        Console.Write("Intelligence: ");
        intel = int.Parse(Console.ReadLine());
        Console.Write("Wisdom: ");
        wis = int.Parse(Console.ReadLine());
        Console.Write("Attack Power: ");
        atkPwr = int.Parse(Console.ReadLine());
        Console.Write("Spell Power: ");
        spPwr = int.Parse(Console.ReadLine());
        Console.Write("Magic Armor: ");
        mgArmor = int.Parse(Console.ReadLine());
        Console.Write("Physical Armor: ");
        physArmor = int.Parse(Console.ReadLine());
        characterToAdd.Stats = new Shared.Attributes.Attributes(hp, mp, str, agl, con, intel, wis, atkPwr, spPwr, mgArmor, physArmor);

        string json = Newtonsoft.Json.JsonConvert.SerializeObject(characterToAdd);
        string cmdText = $"INSERT INTO `character` (name, playerId, characterJSON) VALUES ('{characterToAdd.Name}', 1, '{json}');";

        try
        {
            MySqlConnection connection = AssailantServer.CreateDBConnection();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = cmdText;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            connection.Close();
            connection.Dispose();
            Console.WriteLine("Character Created!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("<<< catch : " + ex.ToString());
        }

        for (int seconds = 10; seconds >= 0; seconds--)
        {
            Console.Write("Returning to Menu [" + new string('=', 10 - (seconds - 1)) + new string(' ', seconds) + "]\r");
            System.Threading.Thread.Sleep(1000);
        }
        PrintMainMenu();
        HandleUserInput(Console.ReadLine());
    }

    private static void ViewCharacters()
    {
        Console.Clear();
        AssailantServer.PrintCharactersInDB();
        for (int seconds = 10; seconds >= 0; seconds--)
        {
            Console.Write("Returning to Menu [" + new string('=', 10 - (seconds - 1)) + new string(' ', seconds) + "]\r");
            System.Threading.Thread.Sleep(1000);
        }
        PrintMainMenu();
        HandleUserInput(Console.ReadLine());
    }

    private static void InvalidResponseMenu()
    {
        PrintMainMenu();
        Console.WriteLine("INVALID RESPONSE. PLEASE TRY AGAIN.");
        HandleUserInput(Console.ReadLine());
    }

    private static void WriteLineCentered(String text)
    {
        Console.Write(new string(' ', (Console.WindowWidth - text.Length) / 2));
        Console.WriteLine(text);
    }
    private static void PrintMainMenu()
    {
        Console.Clear();
        WriteLineCentered("╔╦═╦═╦═╦═╦╦╦╦═╦═╦╦══╦╗");
        WriteLineCentered("║║║║╚╣╚╣║║║║║║║║║╠╣╠╝║");
        WriteLineCentered("║║╩╠╗╠╗║╩║║╚╣╩║║║║║║ ║");
        WriteLineCentered("║╚╩╩═╩═╩╩╩╩═╩╩╩╩═╝╚╝ ║");
        WriteLineCentered("╚════════════════════╝");
        WriteLineCentered("╔╦═╦╗╔╦═╦══╦═╦═╦══╦═╦══╦╗╔╦═╦══╦═╦═╦══╦═╦══╦╗");
        WriteLineCentered("║║╔╣╚╝║║║░░║║║╔╩╣╠╣═╣░░║║║║╔╣░░║═╣║╠╣╠╣═╣░░║║");
        WriteLineCentered("║║╚╣╔╗║╩║╔╗╣╩║╚╗║║║═╣╔╗╣║║║╚╣╔╗╣═╣╩║║║║═╣╔╗╣║");
        WriteLineCentered("║╚═╩╝╚╩╩╩╝╚╩╩╩═╝╚╝╚═╩╝╚╝║║╚═╩╝╚╩═╩╩╝╚╝╚═╩╝╚╝║");
        WriteLineCentered("╚═══════════════════════╝╚══════════════════╝");
        WriteLineCentered("Type a number to continue. ");
        Console.WriteLine();
        WriteLineCentered("1. Create Character        ");
        WriteLineCentered("2. Print List of Characters");
        WriteLineCentered("3. Exit                    ");
        Console.Write(new string(' ', (Console.WindowWidth / 2) - 14) + "> ");
    }
}

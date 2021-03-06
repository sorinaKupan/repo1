// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace C_Features
{
    using System;
    using System.IO;
    using System.Text.Json;

    public class Program
    {
        static void Main(string[] args)
        {
            TeamMember teamMember = new TeamMember() { Name = "Member1" };
            string jsonString = JsonSerializer.Serialize(teamMember);
            Console.WriteLine(jsonString);
            File.WriteAllText("TeamMember.json", jsonString);
            var readText = File.ReadAllTextAsync("TeamMember.json");
            readText.Wait();
            var expectedOutput = readText.Result;
            var teamMemberDeserialized = JsonSerializer.Deserialize<TeamMember>(expectedOutput);
            Console.WriteLine(teamMemberDeserialized);
            Console.Write("What would you like?");
            var customerInput = Console.ReadLine();
            Func<string, string, string, string, Coffee> recipe = customerInput == "FlatWhite" ? FlatWhite : Espresso;
            Coffee coffee = MakeCoffee("grains", "milk", "water", "sugar", recipe);
            if (coffee == null)
            {
                Console.WriteLine("Sorry, your order can not be completed.");
            }
            else
            {
                Console.WriteLine($"Here is your coffee: {coffee}");
            }
        }

        static Coffee MakeCoffee(string grains, string milk, string water, string sugar, Func<string, string, string, string, Coffee> recipe)
        {
            try
            {
                Console.WriteLine("Start preparing coffee.");
                var coffee = recipe(grains, milk, water, sugar);
                return coffee;
            }
            catch(RecipeUnavailableException exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
            catch(Exception e)
            {
                Console.WriteLine($"Something went wrong, see exception details: {e.Message}");
                return null;
            }
            finally
            {
                Console.WriteLine("Finished.");
            }
        }

        static Coffee Espresso(string grains, string milk, string water, string sugar)
        {
            throw new ApplicationException();
        }
        static Coffee FlatWhite(string grains, string milk, string water, string sugar)
        {
            return new Coffee("Flat White");
        }
    }
}
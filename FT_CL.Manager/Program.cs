using CL.Stub;
using CL.Model;
using System;

namespace FT_Manager
{
    class Program
    {
        static Manager manager = new Manager(new Stub());

        static void Main(string[] args)
        {
            manager.LoadData();
            DisplayList();
            Console.WriteLine("---------------------------");
            manager.RemoveCard(manager.ListCards?[3]);
            DisplayList();
            var card = new Card("My question", "My answer");
            Console.WriteLine(card.ID);
            manager.AddCard(card);
            DisplayList();
        }

        static void DisplayList()
        {
            foreach (var card in manager.ListCards)
            {
                Console.WriteLine(card);
            }
        }
    }
}

using CL.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CL.Stub
{
    public class Stub : IPersistance
    {
        public List<Card> LoadData()
        {
            var listCards = new List<Card>();
            for(int i = 1; i <= 10; i++)
            {
                listCards.Add(new Card($"Question {i}", $"Answer {i}"));
            }
            return listCards;
        }

        public void SaveData(List<Card> listCards)
        {
            Debug.WriteLine("Save requested");
        }
    }
}

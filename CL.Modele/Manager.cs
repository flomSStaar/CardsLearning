using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CL.Model
{
    public class Manager
    {
        public IPersistance Persistance { get; private set; }
        public ObservableCollection<Card> ListCards { get; private set; }

        public Manager(IPersistance persistance)
        {
            Persistance = persistance;
            ListCards = new();
        }

        public void LoadData()
        {
            var data = Persistance?.LoadData();
            foreach(var card in data)
            {
                ListCards.Add(card);
            }
        }

        public void SavaData()
        {
            Persistance?.SaveData(new List<Card>(ListCards));
        }

        public void ReturnCard(Card card) => card?.ReturnCard();

        public bool AddCard(Card card)
        {
            if (card == null) throw new ArgumentNullException(nameof(card));
            if (ListCards.Contains(card)) return false;
            ListCards.Add(card);
            return true;
        }

        public bool RemoveCard(Card card)
        {
            if (card == null) throw new ArgumentNullException(nameof(card));
            if (!ListCards.Contains(card)) return false;
            ListCards.Remove(card);
            return true;
        }
    }
}

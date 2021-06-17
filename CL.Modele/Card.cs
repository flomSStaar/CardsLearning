using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CL.Model
{
    public class Card : INotifyPropertyChanged, IEquatable<Card>
    {
        internal static int nextID;

        public int ID { get; private set; }

        private string ask;
        public string Ask
        {
            get { return ask; }
            internal set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    ask = value;
                    OnPropertyChanged();
                }
            }
        }

        private string answer;

        public string Answer
        {
            get => answer;
            internal set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    answer = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool isReturned;
        public bool IsReturned
        {
            get => isReturned;
            internal set
            {
                isReturned = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public Card(string ask, string answer)
        {
            Ask = ask ?? throw new ArgumentNullException(nameof(ask));
            Answer = answer ?? throw new ArgumentNullException(nameof(answer));
            ID = ++nextID;
        }

        public void ReturnCard() => IsReturned = !IsReturned;

        public bool Equals(Card other)
        {
            if (ID == other.ID) return true;
            return false;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if(obj is Card card) Equals(card);
            return false;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Ask} / {Answer}";
        }
    }
}

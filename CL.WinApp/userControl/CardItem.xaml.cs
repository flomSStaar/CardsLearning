using CL.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace CL.WinApp.userControl
{
    /// <summary>
    /// Logique d'interaction pour CardItem.xaml
    /// </summary>
    public partial class CardItem : UserControl,INotifyPropertyChanged
    {
        public static readonly DependencyProperty CardProperty = DependencyProperty.Register(nameof(Card), typeof(Card), typeof(CardItem));

        public Card Card
        {
            get => GetValue(CardProperty) as Card;
            set => SetValue(CardProperty, value);
        }

        public string TextToPrint
        {
            get => _textToPrint;
            set
            {
                if(value != null)
                {
                    _textToPrint = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _textToPrint;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));

        public CardItem()
        {
            InitializeComponent();
        }

        private void buttonCard_Click(object sender, RoutedEventArgs e)
        {
            Card.ReturnCard();
            TextToPrint = Card.IsReturned ? Card.Answer : Card.Ask;
        }
    }
}

using CL.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Linq;
using System.Windows.Controls;
using System.Diagnostics;
using System;

namespace CL.WinApp.userControl
{
    /// <summary>
    /// Logique d'interaction pour CardViewer.xaml
    /// </summary>
    public partial class CardsViewer : UserControl
    {
        #region ItemsSource
        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(nameof(ItemsSource), typeof(IList<Card>), typeof(CardsViewer));

        public IList<Card> ItemsSource
        {
            get => GetValue(ItemsSourceProperty) as IList<Card>;
            set => SetValue(ItemsSourceProperty, value);
        }
        #endregion

        #region Selected Card
        public static readonly DependencyProperty SelectedCardProperty = DependencyProperty.Register(nameof(SelectedCard), typeof(Card), typeof(CardsViewer));

        public Card SelectedCard
        {
            get => GetValue(SelectedCardProperty) as Card;
            set => SetValue(SelectedCardProperty, value);
        }

        public static readonly RoutedEvent SelectedCardChangedEvent = EventManager.RegisterRoutedEvent(nameof(SelectedCardChanged), RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<Card>), typeof(CardsViewer));

        public event RoutedPropertyChangedEventHandler<Card> SelectedCardChanged
        {
            add { AddHandler(SelectedCardChangedEvent, value); }
            remove { RemoveHandler(SelectedCardChangedEvent, value); }
        }

        protected virtual void OnSelectedCardChanged(RoutedPropertyChangedEventArgs<Card> args) => RaiseEvent(args);

        #endregion

        #region Selected Index
        public static readonly DependencyProperty SelectedIndexProperty = DependencyProperty.Register(nameof(SelectedIndex), typeof(int), typeof(CardsViewer));

        public int SelectedIndex
        {
            get => (int)GetValue(SelectedIndexProperty);
            set => SetValue(SelectedIndexProperty, value);
        }

        public static readonly RoutedEvent SelectedIndexChangedEvent = EventManager.RegisterRoutedEvent(nameof(SelectedIndexChanged), RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<Card>), typeof(CardsViewer));

        public event RoutedPropertyChangedEventHandler<Card> SelectedIndexChanged
        {
            add { AddHandler(SelectedIndexChangedEvent, value); }
            remove { RemoveHandler(SelectedIndexChangedEvent, value); }
        }

        protected virtual void OnSelectedIndexChanged(RoutedPropertyChangedEventArgs<Card> args)
        {
            RaiseEvent(args);
        }
        #endregion

        public CardsViewer()
        {
            InitializeComponent();
        }

        private void buttonNext_Click(object sender, RoutedEventArgs e)
        {
            if(ItemsSource.Count > 0 && ItemsSource.Count - 1 >= SelectedIndex + 1)
            {
                SelectedIndex++;
                SelectedCard = ItemsSource.ElementAt(SelectedIndex);
            }
            else
            {
                Debug.WriteLine("Fin de liste, on ne peut pas aller au suivant");
                //Fin de la liste
            }
        }

        private void buttonPrevious_Click(object sender, RoutedEventArgs e)
        {
            if (ItemsSource.Count > 0 && SelectedIndex - 1 >= 0 && ItemsSource.Count - 1 >= SelectedIndex - 1 )
            {
                SelectedIndex--;
                SelectedCard = ItemsSource.ElementAt(SelectedIndex);
            }
            else
            {
                Debug.WriteLine("Fin de liste, on ne peut pas aller au précédent");
                //Fin de la liste
            }
        }

        private void initButton_Click(object sender, RoutedEventArgs e)
        {
            cardItem.IsEnabled = true;
            buttonNext.IsEnabled = true;
            buttonPrevious.IsEnabled = true;
            SelectedIndex = 0;
            SelectedCard = ItemsSource.FirstOrDefault();
        }
    }
}

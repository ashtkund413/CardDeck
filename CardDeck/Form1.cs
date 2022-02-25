using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardDeck
{
    public partial class Form1 : Form
    {
        // deck of cards
        List<string> deck = new List<string>();
        List<string> dealerCards = new List<string>();
        List <string> playerCards = new List<string>();
        public Form1()
        {
            InitializeComponent();

            //fill deck with standard 52 cards
            //H - Hearts, D - Diamonds, C - Clubs, S - Spades
            
            deck.AddRange(new string[] { "2H", "3H", "4H", "5H", "6H", "7H", "8H", "9H", "10H", "JH", "QH", "KH", "AH" });
            deck.AddRange(new string[] { "2D", "3D", "4D", "5D", "6D", "7D", "8D", "9D", "10D", "JD", "QD", "KD", "AD" });
            deck.AddRange(new string[] { "2C", "3C", "4C", "5C", "6C", "7C", "8C", "9C", "10C", "JC", "QC", "KC", "AC" });
            deck.AddRange(new string[] { "2S", "3S", "4S", "5S", "6S", "7S", "8S", "9S", "10S", "JS", "QS", "KS", "AS" });

            ShowDeck();
            if (shuffleButton.Enabled == true)
            {
                shuffleButton.BackColor = Color.White;


            }
            else

            {
                shuffleButton.BackColor = Color.Green;
            }
        }

        public void ShowDeck()
        {
            outputLabel.Text = $"";

            for (int i = 0; i < deck.Count(); i++)
            {
                outputLabel.Text += $"{deck[i]} ";
            }
            
        }

        private void shuffleButton_Click(object sender, EventArgs e)
        {
           
            dealButton.Enabled = true;
            List<string> deckTemp = new List<string>();
            Random randGen = new Random();

            while (deck.Count > 0)
            {
                int index = randGen.Next(0, deck.Count);                
                deckTemp.Add(deck[index]);
                deck.RemoveAt(index);
            }

            deck = deckTemp;
            shuffleButton.Enabled = false;
            ShowDeck();
        }

        private void dealButton_Click(object sender, EventArgs e)
        {
            collectButton.Enabled = true;
            for (int i = 0; i < 5; i++) 
            {
                playerCards.Add(deck[i]);
                deck.RemoveAt(i);
                playerCardsLabel.Text += $"{playerCards[i]} ";
                dealerCards.Add(deck[i]);
                deck.RemoveAt(i);
                dealerCardsLabel.Text += $"{dealerCards[i]} "; 

            }
            ShowDeck();
            dealButton.Enabled = false;
        }

        private void collectButton_Click(object sender, EventArgs e)
        {
            shuffleButton.Enabled = true;
            for (int i = 0; i < 5; i++)
            {
                deck.Add(playerCards[0]);
                playerCards.RemoveAt(0);
              
                deck.Add(dealerCards[0]);
                dealerCards.RemoveAt(0);
              playerCardsLabel.Text = $" ";
            dealerCardsLabel.Text = $" ";

            }
            collectButton.Enabled= false;
            ShowDeck();
           
        } 


        
    }
}

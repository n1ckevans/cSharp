using System;
using System.Collections.Generic;


namespace DeckOfCards
{
  public class Deck
  {

    private Card[] deck;
    private int currentCard;
    private const int numberOfCards = 52;
    private Random rand;


    public Deck()
    {
      string[] faces = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
      string[] suits = { "Hearts", "Clubs", "Diamonds", "Spades" };
      deck = new Card[numberOfCards];
      currentCard = 0;
      rand = new Random();
      for (int count = 0; count < deck.Length; count++)
      {
        deck[count] = new Card(faces[count % 13], suits[count / 13]);
      }

    }

    public void Shuffle()
    {
      currentCard = 0;
      for (int first = 0; first < deck.Length; first++)
      {
        int second = rand.Next(numberOfCards);
        Card temp = deck[first];
        deck[first] = deck[second];
        deck[second] = temp;
      }

    }

  public Card DealCard()
{
  if (currentCard < deck.Length)
  {
    return deck[currentCard++];
  }
  else {
    return null;
  }
}

    }
}
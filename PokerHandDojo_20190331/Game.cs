using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHandDojo_20190331
{
    public class Game
    {
        private string _firstPlayerName;
        private Hand _firstPlayerHand;

        private Dictionary<HandType, string> _handTypeLookup = new Dictionary<HandType, string>
            {
                {HandType.FourOfAKind,"Four of a kind" },
                {HandType.FullHouse,"Full House" }
            };

        private Hand _secondPlayerHand;

        public void SetFirstPlayerName(string name)
        {
            _firstPlayerName = name;
        }

        public void SetSecondPlayerName(string name)
        {
        }

        public void SetFirstPlayerHand(string hand)
        {
            var cards = hand.Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(card => new Card(card));
            _firstPlayerHand = new Hand(cards);
        }

        public void SetSecondPlayerHand(string hand)
        {
            var cards = hand.Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(card => new Card(card));
            _secondPlayerHand = new Hand(cards);
        }

        public string Result()
        {
            if (IsSameHandType(_firstPlayerHand.HandType, _secondPlayerHand.HandType) == false)
            {
                int winner = new HandTypeComparer().Compare(_firstPlayerHand.HandType, _secondPlayerHand.HandType);

                if (winner > 0)
                {
                    return
                        $"{_firstPlayerName} Win, {_handTypeLookup[_firstPlayerHand.HandType]}.";
                }
            }

            return $"{_firstPlayerName} Win, {_handTypeLookup[_firstPlayerHand.HandType]}.";
        }

        private int HindTypeCompare(HandType firstHandType, HandType secondHandType)
        {
            return 0;
        }

        public bool IsSameHandType(HandType firstHandType, HandType secondHandType)
        {
            return firstHandType == secondHandType;
        }
    }
}
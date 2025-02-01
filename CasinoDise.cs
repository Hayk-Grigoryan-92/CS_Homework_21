using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class CasinoDise
    {
        public void Casiono()
        {
            Casino casino = new Casino(100);

            while (true)
            {
                casino.ShowBalance();
                Console.WriteLine("Choose the game ");
                Console.Write("1. Number bet | 2. Odd bet | 3. Even bet | 4. Exit");
                Console.WriteLine();
                int choice = int.Parse(Console.ReadLine());
                if (choice < 1 || choice > 4)
                {
                    Console.WriteLine("You enter wrong choice, please try again");
                    continue ;
                }
                else if (choice == 4)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter bet amount");
                    int betAmount = int.Parse(Console.ReadLine());

                    if (betAmount > 0 && betAmount < 100)
                    {
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("Please choose dice number");
                                int diceNumber = int.Parse(Console.ReadLine());
                                if (diceNumber >= 1 && diceNumber <= 6)
                                {
                                    Bet bet = new NumberBet(betAmount)
                                   {
                                        BetDice = diceNumber
                                    };
                                    casino.PlaceBet(bet);
                                }
                                else
                                {
                                    throw new Exception("Wrong dice number");
                                }
                                break;
                            case 2:
                                Bet bet2 = new OddBet(betAmount);
                                casino.PlaceBet(bet2);
                                break;
                            case 3:
                                Bet bet3 = new OddBet(betAmount);
                                casino.PlaceBet(bet3);
                                break;
                        }
                    }
                    else
                    {
                        throw new Exception("Your bet cant be more than your balance");
                    }
                }
            }
        }
    }

    class Bet
    {
        public int Amount;
        private int _betDice;
        public int BetDice
        {
            get { return _betDice; }
            set
            {
                if (value > 0 && value <= 6)
                {
                    _betDice = value;
                }
                else
                {
                    throw new Exception("Wrong dice number");
                }
            }
        }

        public Bet(int amount)
        {
            Amount = amount;
        }

        public virtual bool IsWinningBet(int diceRoll)
        {
            return BetDice == diceRoll;
        }

        public virtual int Payout(int Amount)
        {
            Console.WriteLine("Congratulations You Win!!!");
            return Amount * 2;
        }
    }

    class NumberBet : Bet
    {

        public NumberBet(int amount) : base(amount)
        {

        }
        public override int Payout(int Amount)
        {
            Console.WriteLine("Congratulations You Win!!!");
            return Amount * 6;
        }
    }
    class OddBet : Bet
    {
        public OddBet(int amount) : base(amount)
        {

        }
        public override bool IsWinningBet(int diceRoll)
        {
            return diceRoll % 2 != 0;
        }
    }
    class EvenBet : Bet
    {
        public EvenBet(int amount) : base(amount)
        {

        }
        public override bool IsWinningBet(int diceRoll)
        {
            return diceRoll % 2 == 0;
        }
    }

    class Casino
    {
        private int _playerBalance = 100;

        public Casino(int initialBalance)
        {
            _playerBalance = initialBalance;
        }

        public void ShowBalance()
        {
            Console.WriteLine($"Your balance is : {_playerBalance}");
        }

        public void PlaceBet(Bet bet)
        {
            if (bet.Amount > _playerBalance)
            {
                Console.WriteLine("Insufficient founds.");
                return;
            }

            _playerBalance -= bet.Amount;
            int diceRoll = new Random().Next(1, 7);
            Console.WriteLine($"Dice rolled: {diceRoll}");

            if (bet.IsWinningBet(diceRoll))
            {
                int winnings = bet.Payout(bet.Amount);
                _playerBalance += winnings;
                Console.WriteLine($"You won! Payout: {winnings}");
            }
            else
            {
                Console.WriteLine("You lost the bet.");
            }
        }
    }
}

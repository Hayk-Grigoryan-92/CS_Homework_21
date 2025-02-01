using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class CasinoRoulette
    {
        public void CasinoRouletteGame()
        {
            CasinoR casino = new CasinoR(100);

            while (true)
            {
                casino.ShowBalance();
                Console.WriteLine("Choose the game ");
                Console.Write("1. Number bet | 2. Black bet | 3. Red bet | 4. Green 'Zero' bet | 5 Exit");
                Console.WriteLine();
                int choice = int.Parse(Console.ReadLine());
                if (choice < 1 || choice > 5)
                {
                    Console.WriteLine("You enter wrong choice, please try again");
                    continue;
                }
                else if (choice == 5)
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
                                if (diceNumber >= 1 && diceNumber <= 36)
                                {
                                    BetRoullete bet = new NumberBetR(betAmount)
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
                                BetRoullete bet2 = new BetInBlack(betAmount);
                                casino.PlaceBet(bet2);
                                break;
                            case 3:
                                BetRoullete bet3 = new BetInRed(betAmount);
                                casino.PlaceBet(bet3);
                                break;
                            case 4:
                                BetRoullete bet4 = new BetInGreen(betAmount);
                                casino.PlaceBet(bet4);
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

    class BetRoullete
    {
        public int Amount;
        private int _betDice;
        public int BetDice
        {
            get { return _betDice; }
            set
            {
                if (value >= 0 && value <= 36)
                {
                    _betDice = value;
                }
                else
                {
                    throw new Exception("Wrong dice number");
                }
            }
        }

        public BetRoullete(int amount)
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
            return Amount * 18;
        }
    }

    class NumberBetR : BetRoullete
    {

        public NumberBetR(int amount) : base(amount)
        {

        }
        public override int Payout(int Amount)
        {
            Console.WriteLine("Congratulations You Win!!!");
            return Amount * 36;
        }
    }

    class BetInGreen : BetRoullete
    {

        public BetInGreen(int amount) : base(amount)
        {

        }

        public override bool IsWinningBet(int diceRoll)
        {
            return diceRoll == 0;
        }
        public override int Payout(int Amount)
        {
            Console.WriteLine("Congratulations You Win!!!");
            return Amount * 37;
        }
    }
    class BetInBlack : BetRoullete
    {
        public BetInBlack(int amount) : base(amount)
        {

        }
        public override bool IsWinningBet(int diceRoll)
        {
            return diceRoll % 2 != 0;
        }
    }
    class BetInRed : BetRoullete
    {
        public BetInRed(int amount) : base(amount)
        {

        }
        public override bool IsWinningBet(int diceRoll)
        {
            return diceRoll % 2 == 0;
        }
    }

    class CasinoR
    {
        private int _playerBalance = 100;

        public CasinoR(int initialBalance)
        {
            _playerBalance = initialBalance;
        }

        public void ShowBalance()
        {
            Console.WriteLine($"Your balance is : {_playerBalance}");
        }

        public void PlaceBet(BetRoullete bet)
        {
            if (bet.Amount > _playerBalance)
            {
                Console.WriteLine("Insufficient founds.");
                return;
            }

            _playerBalance -= bet.Amount;
            int diceRoll = new Random().Next(0, 37);
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

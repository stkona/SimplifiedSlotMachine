using SimplifiedSlotMachine.Models;
using System;

namespace SimplifiedSlotMachine.Utils
{
    public static class Writer
    {
        public static void HandlePlayResult(PlayResult playResult)
        {
            Console.WriteLine();
            Console.WriteLine(playResult.Rounds);
            Console.WriteLine($"You have won: {playResult.Amount}");
        }

        public static void HandleWelcomeMessage()
        {
            Console.WriteLine("Please, deposit an amount you would like to play with:");
        }

        public static void HandleStakeAmountMessage()
        {
            Console.WriteLine("Please, enter stake amount:");
        }

        public static void HandleDepositNotEnoughMessage()
        {
            Console.WriteLine($"Deposit not enough for this stake.");
        }

        public static void HandleDepositNullMessage()
        {
            Console.WriteLine("You have no more money available, thanks for playing");
        }

        public static void HandleCurrentBalanceMessage(decimal deposit)
        {
            Console.WriteLine($"Current balance is: {deposit}");
        }
    }
}

using SimplifiedSlotMachine.Services;
using SimplifiedSlotMachine.Users;
using SimplifiedSlotMachine.Utils;
using System;

namespace SimplifiedSlotMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initiate required classes
            IPlayer player = new Player();
            ISlotMachine slotMachine = new SlotMachine();
            IPlayingService playingService = new PlayingService(player, slotMachine);

            // Handle welcome messages
            Writer.HandleWelcomeMessage();
            player.AmendDeposit(default, Convert.ToDecimal(Console.ReadLine()));

            Writer.HandleStakeAmountMessage();
            var inputStake = Console.ReadLine();

            while (player.Deposit > 0)
            {
                var stake = Convert.ToDecimal(inputStake);

                // Play round
                playingService.PlayRound(stake);

                // Handle null deposit value
                if (player.IsDepositNull())
                {
                    Writer.HandleDepositNullMessage();
                    break;
                }

                Writer.HandleCurrentBalanceMessage(player.Deposit);

                inputStake = Console.ReadLine();
            }
        }
    }
}

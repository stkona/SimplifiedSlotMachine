using SimplifiedSlotMachine.Users;
using SimplifiedSlotMachine.Utils;

namespace SimplifiedSlotMachine.Services
{
    public class PlayingService : IPlayingService
    {
        private readonly IPlayer _player;
        private readonly ISlotMachine _slotMachine;

        public PlayingService(IPlayer player, ISlotMachine slotMachine)
        {
            this._player = player;
            this._slotMachine = slotMachine;
        }

        public void PlayRound(decimal stake)
        {
            if (_player.IsDepositEnough(stake))
            {
                _player.AmendDeposit("stake", stake);
                var playResult = _slotMachine.Play(stake);
                Writer.HandlePlayResult(playResult);
                _player.AmendDeposit("win", playResult.Amount);
            }
            else
            {
                Writer.HandleDepositNotEnoughMessage();
            }
        }
    }
}

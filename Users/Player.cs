using System;

namespace SimplifiedSlotMachine.Users
{
    public class Player : IPlayer
    {
        private decimal _deposit { get; set; }

        public decimal Deposit
        {
            get
            {
                return _deposit;
            }
        }

        public void AmendDeposit(string method, decimal stake)
        {
            switch (method)
            {
                case "stake":
                    _deposit -= stake;
                    break;
                case "win":
                    _deposit += stake;
                    break;
                default:
                    _deposit = stake;
                    break;
            }
        }

        public bool IsDepositEnough(decimal stake)
        {
            return stake <= _deposit;
        }

        public bool IsDepositNull()
        {
            return _deposit == 0;
        }
    }
}

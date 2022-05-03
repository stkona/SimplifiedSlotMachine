namespace SimplifiedSlotMachine.Users
{
    public interface IPlayer
    {
        decimal Deposit { get; }

        void AmendDeposit(string method, decimal stake);
        bool IsDepositEnough(decimal stake);
        bool IsDepositNull();
    }
}
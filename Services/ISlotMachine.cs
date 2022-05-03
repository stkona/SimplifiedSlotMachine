using SimplifiedSlotMachine.Models;

namespace SimplifiedSlotMachine.Services
{
    public interface ISlotMachine
    {
        PlayResult Play(decimal stake);
        bool CheckIfRoundIsLegit(string round);
    }
}
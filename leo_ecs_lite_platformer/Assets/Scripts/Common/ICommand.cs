using System;

namespace Common
{
    public interface ICommand
    {
        event Action OnSucceed;
        event Action OnFailed;
        void Execute();
    }
}
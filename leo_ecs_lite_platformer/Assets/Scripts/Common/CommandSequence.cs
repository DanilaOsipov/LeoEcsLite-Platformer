using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public class CommandSequence : ICommand
    {
        private readonly List<ICommand> _sequenceCommands = new();

        public event Action OnSucceed = delegate { };
        public event Action OnFailed = delegate { };

        public void Execute()
        {
            if (_sequenceCommands.Count == 0)
            {
                OnSucceed();
            }
            else if (_sequenceCommands.Count == 1)
            {
                _sequenceCommands.First().OnSucceed += delegate { OnSucceed(); };
                _sequenceCommands.First().OnFailed += delegate { OnFailed(); };
            }
            else
            {
                for (int i = 0; i < _sequenceCommands.Count - 1; i++)
                {
                    _sequenceCommands[i].OnSucceed += _sequenceCommands[i + 1].Execute;
                    _sequenceCommands[i].OnFailed += delegate { OnFailed(); };
                }

                _sequenceCommands.Last().OnSucceed += delegate { OnSucceed(); };
                _sequenceCommands.Last().OnFailed += delegate { OnFailed(); };
            }
        }

        public CommandSequence Add(ICommand command)
        {
            _sequenceCommands.Add(command);
            return this;
        }
    }
}
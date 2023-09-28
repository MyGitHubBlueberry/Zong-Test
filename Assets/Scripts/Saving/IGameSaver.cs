using System;

namespace Saving
{
    interface IGameSaver
    {
        public event Action OnGameSave;
    }
}
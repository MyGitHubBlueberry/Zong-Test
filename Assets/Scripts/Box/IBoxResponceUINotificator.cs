
using System;

namespace Box
{
    public interface IBoxResponceUINotificator : IBoxResponce
    {
        event Action<string> OnResponceForUI;
    }
}
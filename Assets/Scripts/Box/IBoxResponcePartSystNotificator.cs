using System;

namespace Box
{
    public interface IBoxResponcePartSystNotificator : IBoxResponce
    {
        event Action OnResponceForParticleSystem;
    }
}
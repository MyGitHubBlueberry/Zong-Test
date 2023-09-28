using System;
using Box;

interface IBoxResponceSFXNotificator : IBoxResponce
{
    public event Action OnResponceForAudioSource;
}
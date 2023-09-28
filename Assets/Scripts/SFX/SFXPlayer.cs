using Box;
using UnityEngine;

namespace SFX
{
    public class SFXPlayer : MonoBehaviour
    {
        void Awake()
        {
            GetComponent<PositiveBoxResponce>().OnResponceForParticleSystem += GetComponent<AudioSource>().Play;
        }
    }
}
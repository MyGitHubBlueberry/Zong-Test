using Box;

namespace Effects.Box
{
    public class BoxParticleSystemSpawner : ObjectSpawner
    {
        void Start() =>
            GetComponent<IBoxResponcePartSystNotificator>().OnResponceForParticleSystem 
            += () => SetParentScale(Spawn());
    }
}
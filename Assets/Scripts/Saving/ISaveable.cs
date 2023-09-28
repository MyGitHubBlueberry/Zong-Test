using Newtonsoft.Json.Linq;

namespace Saving
{
    public interface ISaveable
    {
        JToken CaptureAsJToken();
        void RestoreFromJToken(JToken state);
    }
}

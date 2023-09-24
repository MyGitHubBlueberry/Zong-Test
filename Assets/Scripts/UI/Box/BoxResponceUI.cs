using Box;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace UI.Box
{
    [RequireComponent(typeof(IBoxResponceUINotificator))]
    public class BoxResponceUI : ObjectSpawner
    {
        void Start() =>
            GetComponent<IBoxResponceUINotificator>().OnResponceForUI += DiaplayUI;

        private void DiaplayUI(string message)
        {
            Transform canvas = Spawn();
            SetMessage(message, canvas);
        }
        
        private void SetMessage(string message, Transform canvas)
        {
            TextMeshProUGUI textObj = canvas.GetComponentInChildren<TextMeshProUGUI>();
            textObj.text = message;
        }
    }
}

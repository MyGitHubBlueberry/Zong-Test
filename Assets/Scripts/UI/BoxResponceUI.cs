using Box;
using TMPro;
using UnityEngine;

namespace UI.Box
{
    [RequireComponent(typeof(IBoxResponceUINotificator))]
    public class BoxResponceUI : MonoBehaviour
    {
        [SerializeField] Transform boxUICanvasPrefab;
        [SerializeField] Vector3 localInstantiatePosition;

        IBoxResponceUINotificator uiNotificator;

        void Awake() =>
            uiNotificator = GetComponent<IBoxResponceUINotificator>();

    
        void Start() =>
            uiNotificator.OnResponceForUI += DiaplayUI;

        private void DiaplayUI(string message)
        {
            Transform canvas = Instantiate(boxUICanvasPrefab, transform);
            canvas.localPosition = localInstantiatePosition;
            SetMessage(message, canvas);
        }
        
        private void SetMessage(string message, Transform canvas)
        {
            TextMeshProUGUI textObj = canvas.GetComponentInChildren<TextMeshProUGUI>();
            textObj.text = message;
        }
    }
}

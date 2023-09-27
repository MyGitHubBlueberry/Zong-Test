using PointSystem;
using TMPro;
using UnityEngine;

namespace UI.PointSystem
{
    public class PointSystemUI : MonoBehaviour
    {
        [SerializeField] Points points;
        [SerializeField] TextMeshProUGUI pointText;

        void Awake()
        {
            UpdateUI(0);
            points.OnPointsAdded += UpdateUI;
        }

        void UpdateUI(int currentPoints) =>
            pointText.text = currentPoints.ToString();
    }
}

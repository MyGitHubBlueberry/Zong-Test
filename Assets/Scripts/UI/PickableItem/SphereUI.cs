using UnityEngine;
using TMPro;
using PickableItem;

namespace UI.PickableItem
{
    public class SphereUI : ObjectSpawner
    {
        [SerializeField] string text;

        Transform uiInstance;
        bool isPlayerLooksAtTheSphere;
        bool showUI;

        void Awake()
        {
            uiInstance = Spawn();
            uiInstance.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }

        protected override Transform Spawn()
        {
            Transform uiInstanceHolder = base.Spawn();
            uiInstanceHolder.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
            Transform uiInstance = uiInstanceHolder.GetChild(0).GetComponent<Transform>();
            uiInstance.SetLocalPositionAndRotation(position, rotation);

            return uiInstance;
        }

        void Start()
        {
            GetComponent<Sphere>().OnPlayerLooksAtTheSphere += UpdateUI;
        }

        void UpdateUI()
        {
            isPlayerLooksAtTheSphere = true;
            showUI = true;
        }

        void Update()
        {
            KeepUIActiveWhilePlayerLooksAtTheSphere();
        }

        private void KeepUIActiveWhilePlayerLooksAtTheSphere()
        {
            isPlayerLooksAtTheSphere = showUI;
            showUI = false;

            uiInstance.gameObject.SetActive(isPlayerLooksAtTheSphere);
        }
    }
}

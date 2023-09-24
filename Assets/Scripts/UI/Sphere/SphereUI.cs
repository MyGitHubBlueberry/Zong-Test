using Sph = Sphere;
using UnityEngine;
using TMPro;

namespace UI.Sphere
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
            uiInstanceHolder.transform.localPosition = Vector3.zero;
            uiInstanceHolder.transform.localRotation = Quaternion.identity;
            Transform uiInstance = uiInstanceHolder.GetChild(0).GetComponent<Transform>();
            uiInstance.localPosition = position;
            uiInstance.localRotation = rotation;

            return uiInstance;
        }

        void Start()
        {
            GetComponent<Sph.Sphere>().OnPlayerLooksAtTheSphere += UpdateUI;
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

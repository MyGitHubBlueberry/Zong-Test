using System.Linq;
using Core;
using UnityEngine;

namespace UI
{
    public class ShowHideUI : MonoBehaviour
    {
        void Awake()
        {
            var triggers = Static.GetInstancesOfImplementingType<IMainUIShowTrigger>();
            foreach (var trigger in triggers)
                trigger.OnMainUIShowRequest += () => ShowMainUI(triggers.ToArray());

            gameObject.SetActive(false);
        }

        void ShowMainUI(IMainUIShowTrigger[] triggers)
        {
            gameObject.SetActive(true);
            foreach (var trigger in triggers)
                trigger.OnMainUIShowRequest -= () => ShowMainUI(triggers);
        }
    }
}
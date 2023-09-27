using UnityEngine;

namespace UI
{    
    public class ShowHideUI : MonoBehaviour
    {
        void Awake()
        {
            IMainUIShowTrigger.OnAnyMainUIShowRequest += ShowMainUI;

            gameObject.SetActive(false);
        }

        void ShowMainUI()
        {
            gameObject.SetActive(true);   
            IMainUIShowTrigger.OnAnyMainUIShowRequest -= ShowMainUI; 
        }
    }
}
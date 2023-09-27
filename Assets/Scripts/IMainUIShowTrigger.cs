using System;


    interface IMainUIShowTrigger
    {
        public static event Action OnAnyMainUIShowRequest;

        public static void ShowMainUI() => OnAnyMainUIShowRequest?.Invoke();
    }

using System;

namespace UI
{
    interface IMainUIShowTrigger
    {
        public event Action OnMainUIShowRequest;
    }
}

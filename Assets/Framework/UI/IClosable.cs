

using UnityEngine;
using UnityEngine.EventSystems;

namespace Framework.UI
{
    public interface IClosable
    {
       void OnClose(BaseEventData data);
    }
}

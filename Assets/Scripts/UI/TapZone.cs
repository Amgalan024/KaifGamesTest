using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class TapZone : MonoBehaviour, IPointerDownHandler
    {
        public event Action<Vector3> OnClick;

        public void OnPointerDown(PointerEventData eventData)
        {
            OnClick?.Invoke(eventData.position);
        }
    }
}
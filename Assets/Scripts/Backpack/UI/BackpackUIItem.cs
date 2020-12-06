using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Backpack.UI
{
    public class BackpackUIItem : MonoBehaviour, IPointerEnterHandler, IPointerUpHandler
    {
        public event Action<BackpackUIItem> OnUp;

        [SerializeField] private CanvasGroup group;
        [SerializeField] private Image image;

        public void Init(Sprite icon)
        {
            SetIcon(icon);
        }

        public void Show()
        {
            SetCanvasAlpha(true);
        }

        public void Hide()
        {
            SetCanvasAlpha(false);
        }
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            eventData.pointerPress = gameObject;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            OnUp?.Invoke(this);
        }

        private void SetIcon(Sprite sprite)
        {
            image.sprite = sprite;
        }

        private void SetCanvasAlpha(bool isActive)
        {
            group.alpha = isActive ? 1f : 0f;
        }
    }
}
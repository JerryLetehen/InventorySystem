using System;
using System.Collections.Generic;
using DraggableObject;
using UnityEngine;
using UnityEngine.Events;

namespace Backpack.UI
{
    public class BackpackItemsUIHolder : BackpackItemsHolderBase
    {
        [SerializeField] private PointerOnItemUpEvent onPointerOnItemUp;
        [SerializeField] private BackpackUIItem itemPrefab;

        private readonly IDictionary<BackpackUIItem, DraggableObjectBehavior> itemsMap = new Dictionary<BackpackUIItem, DraggableObjectBehavior>();
        private readonly IList<BackpackUIItem> freeItems = new List<BackpackUIItem>();

        protected override void Attach(DraggableObjectBehavior draggableObject)
        {
            var item = GetFreeItem();
            var holder = GetHolder(draggableObject.Type);
            HoldItem(item, holder);

            if (freeItems.Contains(item))
            {
                freeItems.Remove(item);
            }

            itemsMap[item] = draggableObject;
            item.OnUp += OnPointerOnItemUpHandler;
            item.Init(draggableObject.Icon);
            item.Show();
        }

        protected override void Detach(DraggableObjectBehavior draggableObject)
        {
            foreach (var itemPair in itemsMap)
            {
                if (itemPair.Value == draggableObject)
                {
                    itemPair.Key.OnUp -= OnPointerOnItemUpHandler;
                    FreeItem(itemPair.Key);
                    itemsMap.Remove(itemPair.Key);
                    return;
                }
            }
        }

        private void OnPointerOnItemUpHandler(BackpackUIItem item)
        {
            onPointerOnItemUp.Invoke(itemsMap[item]);
        }

        private void HoldItem(BackpackUIItem item, Transform holder)
        {
            var itemTransform = item.transform;
            itemTransform.SetParent(holder);
            itemTransform.localPosition = Vector3.zero;
        }

        private void FreeItem(BackpackUIItem item)
        {
            item.Hide();
            freeItems.Add(item);
        }

        private BackpackUIItem GetFreeItem()
        {
            if (freeItems.Count > 0)
            {
                return freeItems[0];
            }
            else
            {
                return Instantiate(itemPrefab, transform);
            }
        }

        [Serializable]
        private class PointerOnItemUpEvent : UnityEvent<DraggableObjectBehavior>
        {
        }
    }
}
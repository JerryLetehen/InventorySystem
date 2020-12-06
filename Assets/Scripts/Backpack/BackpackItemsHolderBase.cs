using System;
using DraggableObject;
using InventorySystem.Base;
using UnityEngine;

namespace Backpack
{
    public abstract class BackpackItemsHolderBase : MonoBehaviour
    {
        [SerializeField] private BackpackItemHolderDistributor holderDistributor;

        protected Transform DetachHolder => holderDistributor.DetachHolder;

        public void OnInventoryChangedHandler(InventoryChangeData<DraggableObjectBehavior> changeData)
        {
            GetAction(changeData.ChangeType)?.Invoke(changeData.Item);
        }

        protected Transform GetHolder(DraggableObjectType type) => holderDistributor.GetHolder(type);

        protected abstract void Attach(DraggableObjectBehavior draggableObject);
        protected abstract void Detach(DraggableObjectBehavior draggableObject);

        private Action<DraggableObjectBehavior> GetAction(InventoryChangeType changeType)
        {
            if (changeType == InventoryChangeType.Added)
            {
                return Attach;
            }

            if (changeType == InventoryChangeType.Removed)
            {
                return Detach;
            }

            return null;
        }
    }
}
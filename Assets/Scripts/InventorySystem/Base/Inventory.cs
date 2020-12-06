using System;
using System.Collections.Generic;

namespace InventorySystem.Base
{
    internal class Inventory<T> : IInventory<T>
    {
        public event Action<InventoryChangeData<T>> OnChanged;

        private readonly List<T> container = new List<T>();

        public void Add(T item)
        {
                container.Add(item);
                InvokeOnChanged(new InventoryChangeData<T>(item, InventoryChangeType.Added));
        }

        public void Remove(T item)
        {
            if (container.Contains(item))
            {
                container.Remove(item);
                InvokeOnChanged(new InventoryChangeData<T>(item, InventoryChangeType.Removed));
            }
        }

        private void InvokeOnChanged(InventoryChangeData<T> changeData)
        {
            OnChanged?.Invoke(changeData);
        }
    }
}
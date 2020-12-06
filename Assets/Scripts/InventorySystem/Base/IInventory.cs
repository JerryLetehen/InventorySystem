using System;

namespace InventorySystem.Base
{
    public interface IInventory<T>
    {
        event Action<InventoryChangeData<T>> OnChanged;
        void Add(T item);
        void Remove(T item);
    }
}
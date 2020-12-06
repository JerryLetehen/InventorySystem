using InventorySystem.Base;
using UnityEngine;

namespace InventorySystem
{
    public abstract class InventoryBehavior<T> : MonoBehaviour
    {
        private IInventory<T> inventory;

        private void Start()
        {
            inventory = new Inventory<T>();
            inventory.OnChanged += OnInventoryChanged;
        }

        protected void AddItem(T item)
        {
            inventory.Add(item);
        }

        protected void RemoveItem(T item)
        {
            inventory.Remove(item);
        }

        protected abstract void OnInventoryChanged(InventoryChangeData<T> data);
    }
}
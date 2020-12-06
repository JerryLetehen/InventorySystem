namespace InventorySystem.Base
{
    public readonly struct InventoryChangeData<T>
    {
        public readonly T Item;
        public readonly InventoryChangeType ChangeType;

        public InventoryChangeData(T item, InventoryChangeType changeType)
        {
            Item = item;
            ChangeType = changeType;
        }
    }
}
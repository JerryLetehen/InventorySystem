using DraggableObject;
using InventorySystem;
using InventorySystem.Base;
using UnityEngine;
using UnityEngine.Events;

namespace Backpack
{
    public class BackpackBehavior : InventoryBehavior<DraggableObjectBehavior>
    {
        [SerializeField] private UnityEvent onPointerDown;
        [SerializeField] private UnityEvent onPointerUp;
        [SerializeField] private BackpackItemDropEvent onChanged;

        public void OnMouseDown()
        {
            onPointerDown.Invoke();
        }

        public void OnMouseUp()
        {
            onPointerUp.Invoke();
        }

        public void OnDetachHandler(DraggableObjectBehavior draggableObject)
        {
            RemoveItem(draggableObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            var item = other.GetComponent<DraggableObjectBehavior>();
            if (item != null)
            {
                item.OnEndDrag += OnItemDragEndedHandler;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            var item = other.GetComponent<DraggableObjectBehavior>();
            if (item != null)
            {
                item.OnEndDrag -= OnItemDragEndedHandler;
            }
        }

        private void OnItemDragEndedHandler(DraggableObjectBehavior item)
        {
            item.SetPhysicsActive(false);
            item.SetDraggableState(false);
            AddItem(item);
        }

        protected override void OnInventoryChanged(InventoryChangeData<DraggableObjectBehavior> data)
        {
            onChanged.Invoke(data);
        }
    }
}
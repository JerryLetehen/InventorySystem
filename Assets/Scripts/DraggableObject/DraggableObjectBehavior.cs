using System;
using UnityEngine;

namespace DraggableObject
{
    public class DraggableObjectBehavior : MonoBehaviour
    {
        public event Action<DraggableObjectBehavior> OnEndDrag;

        [SerializeField] private DraggableObjectConfig config;
        [SerializeField] private Collider collider;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private Camera camera; // or init when create

        public string ID => config.ID;
        public DraggableObjectType Type => config.Type;
        public Sprite Icon => config.Icon;

        private Vector3 draggingOffset;
        private float draggingZCoord;
        private bool isDraggable = true;
        private bool isPressed;
        private bool isUnpressed;

        private bool IsAbleToDrag => isDraggable == true;
        
        public void SetPhysicsActive(bool isActive)
        {
            rb.isKinematic = !isActive;
            collider.isTrigger = !isActive;
        }

        public void SetDraggableState(bool isDraggable)
        {
            this.isDraggable = isDraggable;
        }

        private void Update()
        {
            if (isPressed)
            {
                StartDragging();
                isPressed = false;
            }

            if (isUnpressed)
            {
                StopDragging();
                isUnpressed = false;
            }
        }

        private void StartDragging()
        {
            SetPhysicsActive(false);
            var pos = transform.position;
            draggingZCoord = camera.WorldToScreenPoint(pos).z;
            draggingOffset = pos - GetMouseAsWorldPoint();
        }

        private void StopDragging()
        {
            SetPhysicsActive(true);
            OnEndDrag?.Invoke(this);
        }

        private void OnMouseDown()
        {
            if (IsAbleToDrag)
            {
                isPressed = true;
            }
        }

        private Vector3 GetMouseAsWorldPoint()
        {
            Vector3 mousePoint = Input.mousePosition;
            mousePoint.z = draggingZCoord;
            return camera.ScreenToWorldPoint(mousePoint);
        }

        private void OnMouseDrag()
        {
            if (IsAbleToDrag)
            {
                transform.position = GetMouseAsWorldPoint() + draggingOffset;
            }
        }

        private void OnMouseUp()
        {
            if (IsAbleToDrag)
            {
                isUnpressed = true;
            }
        }
    }
}
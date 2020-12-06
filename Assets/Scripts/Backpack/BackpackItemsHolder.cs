using DraggableObject;
using UnityEngine;

namespace Backpack
{
    public class BackpackItemsHolder : BackpackItemsHolderBase
    {
        [SerializeField] private BackpackItemsSnappingAnimation snappingAnimation;

        protected override void Detach(DraggableObjectBehavior draggableObject)
        {
            var objectTransform = draggableObject.transform;
            objectTransform.SetParent(DetachHolder);
            snappingAnimation.Snap(objectTransform, () =>
            {
                objectTransform.SetParent(null);
                draggableObject.SetPhysicsActive(true);
                draggableObject.SetDraggableState(true);
            });
        }

        protected override void Attach(DraggableObjectBehavior draggableObject)
        {
            var holder = GetHolder(draggableObject.Type);
            var objectTransform = draggableObject.transform;
            objectTransform.SetParent(holder);
            snappingAnimation.Snap(objectTransform);
        }
    }
}
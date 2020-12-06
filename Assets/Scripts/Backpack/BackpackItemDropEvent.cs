using System;
using DraggableObject;
using InventorySystem.Base;
using UnityEngine.Events;

namespace Backpack
{
    [Serializable]
    public class BackpackItemDropEvent : UnityEvent<InventoryChangeData<DraggableObjectBehavior>>
    {
    }
}
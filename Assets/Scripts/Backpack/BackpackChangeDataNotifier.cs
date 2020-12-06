using System;
using DraggableObject;
using InventorySystem.Base;
using UnityEngine;
using UnityEngine.Events;

namespace Backpack
{
    public class BackpackChangeDataNotifier : MonoBehaviour
    {
        [SerializeField] private UnityStringEvent notify;

        public void SendUpdate(InventoryChangeData<DraggableObjectBehavior> data)
        {
            notify?.Invoke(JsonUtility.ToJson(new ChangeData(data.Item.ID, data.ChangeType)));
        }

        [Serializable]
        private class UnityStringEvent : UnityEvent<string>
        {
        }

        [Serializable]
        private class ChangeData
        {
            public string ID;
            public InventoryChangeType ChangeType;

            public ChangeData(string id, InventoryChangeType changeType)
            {
                ID = id;
                ChangeType = changeType;
            }
        }
    }
}
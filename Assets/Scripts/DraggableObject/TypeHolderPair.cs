using System;
using UnityEngine;

namespace DraggableObject
{
    [Serializable]
    public class TypeHolderPair
    {
        [SerializeField] private Transform holder;
        [SerializeField] private DraggableObjectType type;

        public DraggableObjectType Type => type;
        public Transform Holder => holder;
    }
}
using DraggableObject;
using UnityEngine;

namespace Backpack
{
    public class BackpackItemHolderDistributor : MonoBehaviour
    {
        [SerializeField] private TypeHolderPair[] holderPairs;
        [SerializeField] private Transform detachHolder;

        public Transform DetachHolder => detachHolder;
        
        public Transform GetHolder(DraggableObjectType type)
        {
            foreach (var holderPair in holderPairs)
            {
                if (holderPair.Type == type)
                {
                    return holderPair.Holder;
                }
            }

            Debug.LogWarning($"Holder for {type} not found");
            
            return transform;
        }
    }
}
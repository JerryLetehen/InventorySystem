using System;
using DG.Tweening;
using UnityEngine;

namespace Backpack
{
    public class BackpackItemsSnappingAnimation : MonoBehaviour
    {
        [SerializeField] private float duration;
        [SerializeField] private Ease ease = Ease.InOutCubic;

        public void Snap(Transform @object, Action callback = null)
        {
            @object.DOKill();
            @object.DOLocalMove(Vector3.zero, duration).SetEase(ease).OnComplete(() => callback?.Invoke());
        }
    }
}
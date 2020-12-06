using UnityEngine;

namespace DraggableObject
{
    [CreateAssetMenu(fileName = "DraggableObjectConfig", menuName = "Presets/DraggableObjectConfig", order = 0)]
    public class DraggableObjectConfig : ScriptableObject
    {
        [SerializeField] private DraggableObjectType type;
        [SerializeField] private string id;
        [SerializeField] private string name;
        [SerializeField] private float weight;
        [SerializeField] private Sprite icon;

        public string ID => id;
        public DraggableObjectType Type => type;
        public Sprite Icon => icon;
    }
}
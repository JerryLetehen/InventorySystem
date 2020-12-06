using UnityEngine;

namespace Backpack.UI
{
    public class BackpackUI : MonoBehaviour
    {
        [SerializeField] private Canvas canvas;

        private bool isActive;

        private bool CheckToHide => Input.GetMouseButton(0) == false;
        
        public void Show()
        {
            SetCanvasActive(true);
        }

        public void Hide()
        {
            SetCanvasActive(false);
        }

        private void Update()
        {
            if (isActive)
            {
                if (CheckToHide)
                {
                    Hide();
                }
                else
                {
                    RotateToCamera();
                }
            }
        }
        
        private void SetCanvasActive(bool isActive)
        {
            this.isActive = isActive; 
            canvas.enabled = isActive;
        }

        private void RotateToCamera()
        {
            transform.LookAt(canvas.worldCamera.transform.position);
        }
    }
}
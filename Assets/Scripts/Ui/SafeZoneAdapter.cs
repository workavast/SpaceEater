using UnityEngine;

namespace SourceCode.Ui
{
    [RequireComponent(typeof(RectTransform))]
    public class SafeZoneAdapter : MonoBehaviour
    {
        private void Awake() 
            => AdaptUiForSafeZone();

#if UNITY_EDITOR
        private void FixedUpdate()
        {
            AdaptUiForSafeZone();
        }  
#endif

        private void AdaptUiForSafeZone()
        {
            var rect = GetComponent<RectTransform>();
            var safeZone = Screen.safeArea;
            var anchorMin = safeZone.position;
            var anchorMax = safeZone.position + safeZone.size;

            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;
            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;
            
            rect.anchorMin = anchorMin;
            rect.anchorMax = anchorMax;
        }
    }
}
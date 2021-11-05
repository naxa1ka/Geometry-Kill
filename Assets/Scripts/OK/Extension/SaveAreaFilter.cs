using UnityEngine;


public class SaveAreaFilter : MonoBehaviour
{
    private void Awake()
    {
        var rectTransform = GetComponent<RectTransform>();

        var safeArea = Screen.safeArea;

        var anchorMin = safeArea.position;
        var anchorMax = anchorMin + safeArea.size;

        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;

        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;

        rectTransform.anchorMin = anchorMin;
        rectTransform.anchorMax = anchorMax;
    }
}
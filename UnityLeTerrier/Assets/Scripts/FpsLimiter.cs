using UnityEngine;
[ExecuteInEditMode]
public class FpsLimiter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private int frameRate = 60;
    private void Start()
    {
        #if UNITY_EDITOR
        QualitySettings.vSyncCount=0;
        Application.targetFrameRate = frameRate;
        #endif
    }

}

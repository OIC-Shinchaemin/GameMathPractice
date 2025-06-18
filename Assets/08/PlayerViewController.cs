using UnityEngine;
using OIC;

public class PlayerViewController : MonoBehaviour
{
    public Transform target;
    public ViewVisualizer visualizer;
    public ViewSettingsSO settings;

    void Update()
    {
        if (target == null || settings == null || visualizer == null) return;

        Vector3 forward = transform.forward;
        Vector3 toTarget = (target.position - transform.position).normalized;

        float dot = OICMath.Dot(forward, toTarget);
        float threshold = OICMath.Cos(settings.viewAngle * 0.5f * Mathf.Deg2Rad);

        if (dot >= threshold)
        {
            visualizer.SetLineColor(settings.insideColor);
            Debug.Log("ターゲットは視野内にいます！");
        }
        else
        {
            visualizer.SetLineColor(settings.outsideColor);
            Debug.Log("視野外です。"); 
        }
    }
}

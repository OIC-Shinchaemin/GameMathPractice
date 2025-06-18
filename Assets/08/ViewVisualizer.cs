using UnityEngine;

public class ViewVisualizer : MonoBehaviour
{
    public ViewSettingsSO settings;
    private Color currentColor = Color.cyan;

    public void SetLineColor(Color color)
    {
        currentColor = color;
    }

    void OnDrawGizmos()
    {
        if (settings == null) return;

        Vector3 forward = transform.forward;
        float halfAngle = settings.viewAngle * 0.5f;

        Quaternion left = Quaternion.Euler(0, -halfAngle, 0);
        Quaternion right = Quaternion.Euler(0, halfAngle, 0);

        Gizmos.color = currentColor;
        Gizmos.DrawRay(transform.position, left * forward * settings.viewDistance);
        Gizmos.DrawRay(transform.position, right * forward * settings.viewDistance);
    }
}

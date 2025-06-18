using UnityEngine;

[CreateAssetMenu(menuName = "OIC/View Settings")]
public class ViewSettingsSO : ScriptableObject
{
    public float viewAngle = 90f;
    public float viewDistance = 5f;
    public Color insideColor = Color.green;
    public Color outsideColor = Color.red;
}

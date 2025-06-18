using UnityEngine;
using OIC;

public class EnemyOrbit : MonoBehaviour
{
    public Transform center;
    public float radius = 3f;
    public float speed = 1f;

    void Update()
    {
        float x = OICMath.Cos(Time.time * speed) * radius;
        float z = OICMath.Sin(Time.time * speed) * radius;
        transform.position = center.position + new Vector3(x, 0f, z);
    }
}

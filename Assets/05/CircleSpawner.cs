using UnityEngine;
using OIC;
using System.Collections.Generic;

public class CircleSpawner : MonoBehaviour
{
    [Header("円形配置設定")]
    [Tooltip("生成するオブジェクトのプレハブ")]
    public GameObject particlePrefab;

    [Tooltip("生成するオブジェクトの数")]
    public int particleCount = 12;

    [Tooltip("半径")]
    public float radius = 2f;

    [Tooltip("生成時の回転オフセット (度数)")]
    public float startAngle = 0f;

    [Header("回転設定")]
    [Tooltip("回転の速さ")]
    public float rotationSpeed = 30f;

    private List<CircleParticle> particles = new List<CircleParticle>();

    void Start()
    {
        SpawnCircle();
    }

    void Update()
    {
        RotateParticles();
    }

    /// <summary>
    /// 円形にオブジェクトを生成して配置する
    /// </summary>
    private void SpawnCircle()
    {
        if (particlePrefab == null) return;

        float angleStep = 360f / particleCount;

        for (int i = 0; i < particleCount; i++)
        {
            float angle = startAngle + angleStep * i;
            GameObject particle = Instantiate(particlePrefab, transform.position, Quaternion.identity, transform);

            CircleParticle circleParticle = particle.AddComponent<CircleParticle>();
            circleParticle.Initialize(angle, radius);

            particles.Add(circleParticle);
        }
    }

    /// <summary>
    /// 各オブジェクトを回転させる
    /// </summary>
    private void RotateParticles()
    {
        foreach (CircleParticle particle in particles)
        {
            if (particle != null)
            {
                particle.UpdatePosition(rotationSpeed * Time.deltaTime);
            }
        }
    }
}

/// <summary>
/// 円形に沿って移動するパーティクル
/// </summary>
public class CircleParticle : MonoBehaviour
{
    private float currentAngle;
    private float radius;

    /// <summary>
    /// 初期化
    /// </summary>
    /// <param name="startAngle">開始角度</param>
    /// <param name="radius">半径</param>
    public void Initialize(float startAngle, float radius)
    {
        this.currentAngle = startAngle;
        this.radius = radius;
    }

    /// <summary>
    /// 位置の更新
    /// </summary>
    /// <param name="rotationAmount">回転量 (度数)</param>
    public void UpdatePosition(float rotationAmount)
    {
        currentAngle += rotationAmount;

        if (currentAngle >= 360f) currentAngle -= 360f;

        float offsetX = OICMath.Cos(currentAngle) * radius;
        float offsetY = OICMath.Sin(currentAngle) * radius;

        transform.localPosition = new Vector3(offsetX, offsetY, 0f);
    }
}

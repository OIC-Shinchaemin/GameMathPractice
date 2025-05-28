using UnityEngine;
using OIC;
using System.Collections.Generic;

public class CircleSpawner : MonoBehaviour
{
    [Header("�~�`�z�u�ݒ�")]
    [Tooltip("��������I�u�W�F�N�g�̃v���n�u")]
    public GameObject particlePrefab;

    [Tooltip("��������I�u�W�F�N�g�̐�")]
    public int particleCount = 12;

    [Tooltip("���a")]
    public float radius = 2f;

    [Tooltip("�������̉�]�I�t�Z�b�g (�x��)")]
    public float startAngle = 0f;

    [Header("��]�ݒ�")]
    [Tooltip("��]�̑���")]
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
    /// �~�`�ɃI�u�W�F�N�g�𐶐����Ĕz�u����
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
    /// �e�I�u�W�F�N�g����]������
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
/// �~�`�ɉ����Ĉړ�����p�[�e�B�N��
/// </summary>
public class CircleParticle : MonoBehaviour
{
    private float currentAngle;
    private float radius;

    /// <summary>
    /// ������
    /// </summary>
    /// <param name="startAngle">�J�n�p�x</param>
    /// <param name="radius">���a</param>
    public void Initialize(float startAngle, float radius)
    {
        this.currentAngle = startAngle;
        this.radius = radius;
    }

    /// <summary>
    /// �ʒu�̍X�V
    /// </summary>
    /// <param name="rotationAmount">��]�� (�x��)</param>
    public void UpdatePosition(float rotationAmount)
    {
        currentAngle += rotationAmount;

        if (currentAngle >= 360f) currentAngle -= 360f;

        float offsetX = OICMath.Cos(currentAngle) * radius;
        float offsetY = OICMath.Sin(currentAngle) * radius;

        transform.localPosition = new Vector3(offsetX, offsetY, 0f);
    }
}

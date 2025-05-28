using UnityEngine;
using OIC;

public class OrbitMover : MonoBehaviour
{
    [Header("���S�_�ݒ�")]
    [Tooltip("��]�̒��S�_")]
    public Transform centerPoint;  // ���S�_ (�C�ӂ̃I�u�W�F�N�g)

    [Header("��]�ݒ�")]
    [Tooltip("��]�̔��a (����)")]
    public float radius = 3f;  // ��]�̔��a

    [Tooltip("��]�̑���")]
    public float speed = 1f;   // ��]�̑���

    [Tooltip("�����p�x (0 ~ 360��)")]
    public float startAngle = 0f;  // �����p�x

    private float currentAngle;  // ���݂̊p�x
    private SpriteRenderer spriteRenderer;  // SpriteRenderer�Q��

    private float lastLocalX;  // �O�t���[���̃��[�J��X���W

    void Start()
    {
        Initialize();
    }

    void Update()
    {
        ApplyOrbitMovement();
    }

    /// <summary>
    /// ����������
    /// </summary>
    private void Initialize()
    {
        currentAngle = startAngle;
        spriteRenderer = GetComponent<SpriteRenderer>();
        lastLocalX = transform.position.x - centerPoint.position.x;
    }

    /// <summary>
    /// ���S�_�̎���ɉ~�`�O���ňړ�������
    /// </summary>
    private void ApplyOrbitMovement()
    {
        if (centerPoint == null) return;

        // �p�x���X�V (1�b��30�x�i�ސݒ�)
        currentAngle += speed * Time.deltaTime * 30f;

        // 360���𒴂����烊�Z�b�g
        if (currentAngle >= 360f) currentAngle -= 360f;

        // ���W�A���ɕϊ����� Sin, Cos ���v�Z
        float offsetX = OICMath.Cos(currentAngle) * radius;
        float offsetY = OICMath.Sin(currentAngle) * radius;

        // ���݂̃��[�J��X���W
        float currentLocalX = offsetX;

        // X���̕������ς�����ꍇ�Ƀt���b�v�𔽓]
        if (spriteRenderer != null && Mathf.Sign(currentLocalX) != Mathf.Sign(lastLocalX))
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        // �V�����ʒu��ݒ�
        transform.position = new Vector3(centerPoint.position.x + offsetX, centerPoint.position.y + offsetY, transform.position.z);

        // ���[�J��X���W���X�V
        lastLocalX = currentLocalX;
    }
}

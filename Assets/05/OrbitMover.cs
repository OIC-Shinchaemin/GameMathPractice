using UnityEngine;
using OIC;

public class OrbitMover : MonoBehaviour
{
    [Header("中心点設定")]
    [Tooltip("回転の中心点")]
    public Transform centerPoint;  // 中心点 (任意のオブジェクト)

    [Header("回転設定")]
    [Tooltip("回転の半径 (距離)")]
    public float radius = 3f;  // 回転の半径

    [Tooltip("回転の速さ")]
    public float speed = 1f;   // 回転の速さ

    [Tooltip("初期角度 (0 ~ 360°)")]
    public float startAngle = 0f;  // 初期角度

    private float currentAngle;  // 現在の角度
    private SpriteRenderer spriteRenderer;  // SpriteRenderer参照

    private float lastLocalX;  // 前フレームのローカルX座標

    void Start()
    {
        Initialize();
    }

    void Update()
    {
        ApplyOrbitMovement();
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    private void Initialize()
    {
        currentAngle = startAngle;
        spriteRenderer = GetComponent<SpriteRenderer>();
        lastLocalX = transform.position.x - centerPoint.position.x;
    }

    /// <summary>
    /// 中心点の周りに円形軌道で移動させる
    /// </summary>
    private void ApplyOrbitMovement()
    {
        if (centerPoint == null) return;

        // 角度を更新 (1秒で30度進む設定)
        currentAngle += speed * Time.deltaTime * 30f;

        // 360°を超えたらリセット
        if (currentAngle >= 360f) currentAngle -= 360f;

        // ラジアンに変換して Sin, Cos を計算
        float offsetX = OICMath.Cos(currentAngle) * radius;
        float offsetY = OICMath.Sin(currentAngle) * radius;

        // 現在のローカルX座標
        float currentLocalX = offsetX;

        // X軸の符号が変わった場合にフリップを反転
        if (spriteRenderer != null && Mathf.Sign(currentLocalX) != Mathf.Sign(lastLocalX))
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        // 新しい位置を設定
        transform.position = new Vector3(centerPoint.position.x + offsetX, centerPoint.position.y + offsetY, transform.position.z);

        // ローカルX座標を更新
        lastLocalX = currentLocalX;
    }
}

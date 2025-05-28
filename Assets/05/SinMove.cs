using UnityEngine;
using OIC;

public class SinMove : MonoBehaviour
{
    /// <summary>
    /// 移動方向を設定する列挙型
    /// </summary>
    public enum MoveDirection { Left, Right }

    [Header("移動設定")]
    public MoveDirection moveDirection = MoveDirection.Right;  // 移動方向 (右 または 左)

    [Tooltip("移動速度")]
    public float speed = 2f;     // 移動速度

    [Tooltip("振幅 (Y軸の上下振動の大きさ)")]
    public float amplitude = 1f; // 振幅 (Y軸の振動幅)

    [Tooltip("振幅の周波数 (横幅の大きさ)")]
    public float frequency = 1f; // 振幅の周波数 (横幅の広さ)

    private float startY;   // 初期Y座標
    private Vector3 startPos;  // 初期位置

    // 画面の範囲 (左端と右端)
    private float screenLeft;
    private float screenRight;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        Initialize();
    }

    void Update()
    {
        CheckBounds();        // 画面の範囲をチェックして方向転換
        Move();               // 左右移動
        ApplySinWave();       // 上下振動
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    private void Initialize()
    {
        startY = transform.position.y;
        startPos = transform.position;

        // カメラの範囲を取得
        screenLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        screenRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

        // SpriteRendererの取得
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// 左右移動処理
    /// </summary>
    private void Move()
    {
        float moveSpeed = moveDirection == MoveDirection.Right ? speed : -speed;
        transform.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
    }

    /// <summary>
    /// 上下振動を適用する
    /// </summary>
    private void ApplySinWave()
    {
        float angle = Time.time * speed * frequency * 30f;
        float offsetY = OICMath.Sin(angle) * amplitude;
        transform.position = new Vector3(transform.position.x, startY + offsetY, transform.position.z);
    }

    /// <summary>
    /// 画面の外に出た場合、方向を反転し、Spriteを反転させる
    /// </summary>
    private void CheckBounds()
    {
        if (transform.position.x < screenLeft && moveDirection == MoveDirection.Left)
        {
            ChangeDirection();
        }
        else if (transform.position.x > screenRight && moveDirection == MoveDirection.Right)
        {
            ChangeDirection();
        }
    }

    /// <summary>
    /// 方向を変更し、Spriteの向きを反転する
    /// 現在の flipX 状態を基準に反転
    /// </summary>
    private void ChangeDirection()
    {
        // 移動方向の反転
        moveDirection = (moveDirection == MoveDirection.Left) ? MoveDirection.Right : MoveDirection.Left;

        // 現在の flipX 状態を反転
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }
}

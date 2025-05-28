using UnityEngine;
using OIC;

public class TargetFollower : MonoBehaviour
{
    [Header("ターゲット設定")]
    [Tooltip("追跡するターゲットオブジェクト")]
    public Transform target;  // ターゲット (プレイヤーなど)

    [Header("移動設定")]
    [Tooltip("移動速度")]
    public float speed = 2f;  // 移動速度

    void Update()
    {
        if (target != null)
        {
            MoveTowardsTarget();
        }
    }

    /// <summary>
    /// ターゲットの方向に向かって移動する (回転なし, フリップなし)
    /// </summary>
    private void MoveTowardsTarget()
    {
        // 方向を計算
        Vector2 direction = target.position - transform.position;

        // X軸とY軸の距離
        float distanceX = direction.x;
        float distanceY = direction.y;

        // 傾きを計算 (Tan = 高さ / 底辺)
        float tanValue = distanceY / distanceX;

        // X方向に進む量を決定 (絶対値を使う)
        float moveX = Mathf.Sign(distanceX) * speed * Time.deltaTime;

        // Y方向の移動量を計算 (Tan * Xの移動量)
        float moveY = tanValue * moveX;

        // 新しい位置を設定
        transform.position += new Vector3(moveX, moveY, 0f);
    }
}

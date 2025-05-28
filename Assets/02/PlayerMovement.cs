using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // 移動速度
    public float scaleX = 0.5f;  // キャラクターのX軸スケール
    private Vector3 initialScale; // 初期スケール

    private void Start()
    {
        initialScale = transform.localScale;
        transform.localScale = new Vector3(scaleX, initialScale.y, initialScale.z); // 初期状態: 右端で左を向いている
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // 水平方向の入力値 (-1: 左, 1: 右, 0: 入力なし)
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, 0f); // 移動方向

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime); // 移動

        UpdateScale(horizontalInput); // スケール更新
    }

    // スケール更新関数
    void UpdateScale(float horizontalInput)
    {
        float direction = 0f; // 向き (1: 左向き, -1: 右向き)

        if (horizontalInput != 0) // 移動中
        {
            direction = horizontalInput > 0 ? -1f : 1f; // 入力方向に基づいて向きを設定
        }
        else // 停止中
        {
            direction = transform.position.x >= 0 ? 1f : -1f; // X座標に基づいて向きを設定
        }

        transform.localScale = new Vector3(direction * scaleX, initialScale.y, initialScale.z); // スケールを適用
    }
}
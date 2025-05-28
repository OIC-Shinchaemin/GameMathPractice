using UnityEngine;

public class MoveForwardInFacingDirection : MonoBehaviour
{
    [Tooltip("移動スピード")]
    public float moveSpeed = 3f;  // 前進速度

    void Update()
    {
        // Z軸回転を元に「右方向（前方）」のベクトルを取得（2D用）
        Vector3 forward = transform.right;

        // 現在の位置に前方向へ進むベクトルを加える
        transform.position += forward * moveSpeed * Time.deltaTime;
    }
}
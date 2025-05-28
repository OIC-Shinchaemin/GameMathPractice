using UnityEngine;
using OIC;

public class SmoothLookAtMouse : MonoBehaviour
{
    [Tooltip("1秒あたりの最大回転速度（度）")]
    public float turnSpeed = 180f;  // 回転スピード

    void Update()
    {
        // ① 現在位置とマウス位置を取得
        Vector2 from = transform.position;
        Vector2 to = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // ② 目標方向の角度を計算（GetAngle関数を使用）
        float targetAngle = OICMath.GetAngle(from, to);

        // ③ 現在のZ軸角度を取得
        float currentAngle = transform.eulerAngles.z;

        // ④ 少しずつ角度を目標に近づける（MoveTowardsAngle）
        float newAngle = OICMath.MoveTowardsAngle(currentAngle, targetAngle, turnSpeed * Time.deltaTime);

        // ⑤ 回転を適用（Quaternionを使ってZ軸回転）
        transform.rotation = Quaternion.Euler(0f, 0f, newAngle);
    }
}

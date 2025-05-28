using UnityEngine;
using OIC;

public class BoyController : MonoBehaviour
{
    private Animator animator;
    public float maxMoveSpeed = 5f;        // キャラクターの最大移動速度

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Attack();
        }
    }

    public void Move(float power, Vector3 dir)
    {
        float moveSpeed = OICMath.Clamp(power * maxMoveSpeed, 0f, maxMoveSpeed);
        Vector3 move = dir * moveSpeed * Time.deltaTime;
        transform.position += move;

        /*
        // 方向があるときだけ回転処理を実行
        if (dir.sqrMagnitude > 0.001f)
        {
            float angle = OICMath.Atan2(dir.y, dir.x); // 0〜360° に変換
            transform.rotation = Quaternion.Euler(0f, 0f, angle); // Z軸回転
        } 
        */
    }

    public void Attack()
    {
        animator.SetTrigger("Attack");
    }
}

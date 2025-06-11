using UnityEngine;
using OIC;  // OICTween を含む名前空間

public class EaseMove : MonoBehaviour
{
    public enum EaseType
    {
        Linear,
        EaseInSine,
        // 必要に応じて他の種類を追加
    }

    public EaseType easeType = EaseType.EaseInSine;

    public Transform startPoint;
    public Transform endPoint;
    public float duration = 2f;

    private float elapsed = 0f;
    private bool isMoving = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            elapsed = 0f;
            isMoving = true;
        }

        if (isMoving)
        {
            elapsed += Time.deltaTime;
            float t = OICMath.Clamp01(elapsed / duration);

            float easeT = ApplyEasing(t);

            transform.position = Vector2.Lerp(startPoint.position, endPoint.position, easeT);

            if (t >= 1f) isMoving = false;
        }
    }

    float ApplyEasing(float t)
    {
        switch (easeType)
        {
            case EaseType.Linear:
                return OICTween.Linear(t);
            case EaseType.EaseInSine:
                return OICTween.EaseInSine(t);
            default:
                return t;  // 線形補間（Lerp）として扱う
        }
    }
}

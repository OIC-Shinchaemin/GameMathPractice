
using UnityEngine;
using UnityEngine.EventSystems;
using OIC;

public class DynamicVirtualJoystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public RectTransform canvasRect;       // ジョイスティックが所属するCanvas
    public RectTransform background;       // ジョイスティックの背景画像
    public RectTransform stick;            // ジョイスティックのスティック画像
    public float maxDistance = 100f;       // スティックの最大移動距離
    public float minThreshold = 10f;       // 入力と認識される最小距離
   
    public BoyController target;           // 移動対象のキャラクターなど

    private Vector2 origin;                // タッチ開始位置（ローカル座標）
    private Vector2 inputVector;           // 入力ベクトル
    private bool isMoving = false;         // 入力中フラグ

    public Vector2 InputVector => inputVector;

    private void Start()
    {
        background.gameObject.SetActive(false);
        stick.gameObject.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvasRect, eventData.position, eventData.pressEventCamera, out localPoint);

        origin = localPoint;

        background.anchoredPosition = origin;
        stick.anchoredPosition = origin;

        background.gameObject.SetActive(true);
        stick.gameObject.SetActive(true);

        isMoving = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvasRect, eventData.position, eventData.pressEventCamera, out localPoint);

        Vector2 direction = localPoint - origin;

        // 最小入力距離未満なら無視
        if (OICMath.Magnitude(direction) < minThreshold)
        {
            inputVector = Vector2.zero;
            stick.anchoredPosition = origin;
            return;
        }

        Vector2 clamped = Vector2.ClampMagnitude(direction, maxDistance * 0.6f);
        inputVector = clamped / maxDistance;

        stick.anchoredPosition = origin + clamped;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        background.gameObject.SetActive(false);
        stick.gameObject.SetActive(false);
        inputVector = Vector2.zero;
        isMoving = false;
    }

    private void Update()
    {
        if (isMoving && target != null && inputVector != Vector2.zero)
        {
            float power = OICMath.Magnitude(inputVector);

            target.Move(power, new Vector3(inputVector.x, inputVector.y, 0f));
        }
    }
}

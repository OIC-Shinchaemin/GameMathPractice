using UnityEngine;
using OIC; // OICMath を使用するために追加

public class AudioVolumeController : MonoBehaviour
{
    public AudioSource audioSource; // ボリュームを調整する AudioSource
    public Transform targetObject;  // 距離を比較する対象オブジェクトの Transform
    public float minVolume = 0.1f;  // 最小ボリューム
    public float maxVolume = 1.0f;  // 最大ボリューム
    public float maxDistance = 10f; // 最大距離 (この距離以上ではボリューム 0)

    void Update()
    {
        // 2つのオブジェクト間の X 軸距離を計算
        float distanceX = OICMath.Abs(transform.position.x - targetObject.position.x);

        // 距離に基づいてボリュームを計算
        float volume = CalculateVolume(distanceX);

        // ボリュームを設定
        audioSource.volume = volume;
    }

    // 距離に基づいてボリュームを計算する関数
    float CalculateVolume(float distanceX)
    {
        if (distanceX <= maxDistance)
        {
            // 距離に反比例してボリュームを計算 (近いほど maxVolume, 遠いほど minVolume)
            return maxVolume - (maxVolume - minVolume) * (distanceX / maxDistance);
        }
        else
        {
            // 最大距離以上ならボリューム 0
            return 0f;
        }
    }
}
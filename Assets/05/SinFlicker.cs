using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using OIC;

public class SinFlicker : MonoBehaviour
{
    [Tooltip("点滅の速さ (1秒あたりのサイクル数)")]
    public float frequency = 1f; // 点滅の速さ

    [Tooltip("アルファ値の最小値 (0 ~ 1)")]
    public float minAlpha = 0.3f; // 最小アルファ値

    [Tooltip("アルファ値の最大値 (0 ~ 1)")]
    public float maxAlpha = 1f;   // 最大アルファ値

    [Header("対象イメージリスト (手動設定)")]
    public List<Image> imageList = new List<Image>(); // イメージリスト

    private float startTime; // 開始時間

    void Start()
    {
        startTime = Time.time; // 開始時間を取得
        InitializeImages();
    }

    void Update()
    {
        ApplyFlicker();
    }

    /// <summary>
    /// イメージリストの初期化
    /// Inspectorで設定されていない場合、子オブジェクトから自動で取得する
    /// </summary>
    private void InitializeImages()
    {
        if (imageList.Count == 0)
        {
            Image[] childImages = GetComponentsInChildren<Image>();
            imageList.AddRange(childImages);
        }
    }

    /// <summary>
    /// Sin関数を使用して点滅効果を適用する
    /// - 現在は Sin 関数の出力範囲 (0 ~ 1) をそのまま使用
    /// - minAlpha から始める計算式は下記のコメントを参照
    /// </summary>
    private void ApplyFlicker()
    {
        // Sin 関数の出力は -1 ~ 1
        // (Sin + 1) / 2 にすることで 0 ~ 1 に変換される
        float alpha = (OICMath.Sin(Time.time * frequency * 90f) + 1f) / 2f;

        // 現在の構造では 1 から始まる
        // - minAlpha から始める場合は -90度のシフトを追加する
        // float alpha = (OICMath.Sin((Time.time - startTime) * frequency * 90f - 90f) + 1f) / 2f;

        // アルファ値の範囲内に収める
        float range = maxAlpha - minAlpha;
        alpha = minAlpha + (range * alpha);

        // 各イメージに対してアルファ値を適用
        foreach (Image img in imageList)
        {
            if (img != null)
            {
                img.color = new Color(img.color.r, img.color.g, img.color.b, alpha);
            }
        }
    }
}

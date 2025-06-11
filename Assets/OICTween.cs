using UnityEngine;

namespace OIC
{
    public static class OICTween
    {
        /// <summary>
        /// 線形補間（Linear）: 一定の割合で進む
        /// </summary>
        public static float Linear(float t)
        {
            return t;
        }

        /// <summary>
        /// EaseInSine: ゆっくり始まって加速する
        /// </summary>
        public static float EaseInSine(float t)
        {
            return 1f - Mathf.Cos((t * Mathf.PI) / 2f);
        }
    }
}

using UnityEngine;

namespace OIC
{
    public static class OICTween
    {
        /// <summary>
        /// ���`��ԁiLinear�j: ���̊����Ői��
        /// </summary>
        public static float Linear(float t)
        {
            return t;
        }

        /// <summary>
        /// EaseInSine: �������n�܂��ĉ�������
        /// </summary>
        public static float EaseInSine(float t)
        {
            return 1f - Mathf.Cos((t * Mathf.PI) / 2f);
        }
    }
}

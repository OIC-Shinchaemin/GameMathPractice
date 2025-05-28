using UnityEngine;

namespace OIC
{
    /// <summary>
    /// �Q�[���J���ł悭�g�����w�֐����܂Ƃ߂����[�e�B���e�B�N���X
    /// ����K�v�ȋ@�\��ǉ����Ă������Ƃ��ł��܂��B
    /// </summary>
    public static class OICMath
    {
        // ������ Abs / Min / Max / Clamp �Ȃǂ�ǉ����Ă����܂��傤
        // �����̐�Βl���v�Z����֐�
        public static float Abs(float value)
        {
            return value < 0 ? -value : value;
        }

        // �����̍ŏ��l���v�Z����֐�
        public static float Min(float a, float b)
        {
            return a < b ? a : b;
        }

        // �����̍ő�l���v�Z����֐�
        public static float Max(float a, float b)
        {
            return a > b ? a : b;
        }

        // �����͈̔͂𐧌�����֐�
        public static float Clamp(float value, float min, float max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }   

        // ������ magnitude / distance / normalized �Ȃǂ�ǉ����Ă����܂��傤

        // �x�N�g���̑傫�����v�Z����֐�
        public static float Magnitude(Vector2 v)
        {
            return Mathf.Sqrt(v.x * v.x + v.y * v.y);
        }

        // 2�_�Ԃ̋������v�Z����֐�
        public static float Distance(Vector2 a, Vector2 b)
        {
            return Magnitude(b - a);
        }

        // �x�N�g���𐳋K������֐�
        public static Vector2 Normalized(Vector2 v)
        {
            float magnitude = Magnitude(v);
            if (magnitude > 0)
            {
                return new Vector2(v.x / magnitude, v.y / magnitude);
            }
            return Vector2.zero;
        }

        // ������ rad2deg / deg2rad �Ȃǂ�ǉ����Ă����܂��傤
        // ���W�A����x�ɕϊ�����֐�
        public static float Rad2Deg(float radian)
        {
            return radian * (180f / Mathf.PI);
        }

        // �x�����W�A���ɕϊ�����֐�
        public static float Deg2Rad(float degree)
        {
            return degree * (Mathf.PI / 180f);
        }

        // ������ sin / cos / tan / atan2 �Ȃǂ�ǉ����Ă����܂��傤
        // �T�C���֐�
        public static float Sin(float angle)
        {
            return Mathf.Sin(Deg2Rad(angle));
        }

        // �R�T�C���֐�
        public static float Cos(float angle)
        {
            return Mathf.Cos(Deg2Rad(angle));
        }

        // �^���W�F���g�֐�
        public static float Tan(float angle)
        {
            return Mathf.Tan(Deg2Rad(angle));
        }

        // �A�[�N�^���W�F���g�֐�
        public static float Atan2(float y, float x)
        {
            float angle = Rad2Deg(Mathf.Atan2(y, x));

            // �p�x�� 0 ~ 360 �ɕϊ�
            if (angle < 0)
                angle += 360f;

            return angle;
        }

        // GetAngle , MoveTowardsAngle �Ȃǂ�ǉ����Ă����܂��傤
        // 2�̊p�x�̍����v�Z����֐�
        public static float GetAngle(Vector2 from, Vector2 to)
        {
            Vector2 dir = to - from;
            return Atan2(dir.y, dir.x);
        }

        // �p�x���w�肵���p�x�Ɍ������Ĉړ�����֐�
        public static float Sign(float value)
        {
            if (value > 0f) return 1f;
            if (value < 0f) return -1f;
            return 0f;
        }

        // �p�x�̍����v�Z����֐�
        public static float DeltaAngle(float current, float target)
        {
            float delta = (target - current) % 360f;
            if (delta > 180f) delta -= 360f;
            if (delta < -180f) delta += 360f;
            return delta;
        }

        // �p�x���w�肵���p�x�Ɍ������čő�̕ω��ʂňړ�����֐�
        public static float MoveTowardsAngle(float current, float target, float maxDelta)
        {
            float delta = DeltaAngle(current, target);
            if (Abs(delta) <= maxDelta) return target;
            return current + Sign(delta) * maxDelta;
        }
    }
}
using UnityEngine;

namespace OIC
{
    /// <summary>
    /// ゲーム開発でよく使う数学関数をまとめたユーティリティクラス
    /// 今後必要な機能を追加していくことができます。
    /// </summary>
    public static class OICMath
    {
        // ここに Abs / Min / Max / Clamp などを追加していきましょう
        // 整数の絶対値を計算する関数
        public static float Abs(float value)
        {
            return value < 0 ? -value : value;
        }

        // 整数の最小値を計算する関数
        public static float Min(float a, float b)
        {
            return a < b ? a : b;
        }

        // 整数の最大値を計算する関数
        public static float Max(float a, float b)
        {
            return a > b ? a : b;
        }

        // 整数の範囲を制限する関数
        public static float Clamp(float value, float min, float max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }   

        // ここに magnitude / distance / normalized などを追加していきましょう

        // ベクトルの大きさを計算する関数
        public static float Magnitude(Vector2 v)
        {
            return Mathf.Sqrt(v.x * v.x + v.y * v.y);
        }
        
        public static float Magnitude(Vector3 v)
        {
            return Mathf.Sqrt(v.x * v.x + v.y * v.y + v.z * v.z);
        }

        // 2点間の距離を計算する関数
        public static float Distance(Vector2 a, Vector2 b)
        {
            return Magnitude(b - a);
        }

        // ベクトルを正規化する関数
        public static Vector2 Normalized(Vector2 v)
        {
            float magnitude = Magnitude(v);
            if (magnitude > 0)
            {
                return new Vector2(v.x / magnitude, v.y / magnitude);
            }
            return Vector2.zero;
        }

        public static Vector3 Normalized(Vector3 v)
        {
            float magnitude = Magnitude(v);
            if (magnitude > 0)
            {
                return new Vector3(v.x / magnitude, v.y / magnitude, v.z / magnitude);
            }
            return Vector3.zero;
        }

        // ここに rad2deg / deg2rad などを追加していきましょう
        // ラジアンを度に変換する関数
        public static float Rad2Deg(float radian)
        {
            return radian * (180f / Mathf.PI);
        }

        // 度をラジアンに変換する関数
        public static float Deg2Rad(float degree)
        {
            return degree * (Mathf.PI / 180f);
        }

        // ここに sin / cos / tan / atan2 などを追加していきましょう
        // サイン関数
        public static float Sin(float angle)
        {
            return Mathf.Sin(Deg2Rad(angle));
        }

        // コサイン関数
        public static float Cos(float angle)
        {
            return Mathf.Cos(Deg2Rad(angle));
        }

        // タンジェント関数
        public static float Tan(float angle)
        {
            return Mathf.Tan(Deg2Rad(angle));
        }

        // アークタンジェント関数
        public static float Atan2(float y, float x)
        {
            float angle = Rad2Deg(Mathf.Atan2(y, x));

            // 角度を 0 ~ 360 に変換
            if (angle < 0)
                angle += 360f;

            return angle;
        }

        // GetAngle , MoveTowardsAngle などを追加していきましょう
        // 2つの角度の差を計算する関数
        public static float GetAngle(Vector2 from, Vector2 to)
        {
            Vector2 dir = to - from;
            return Atan2(dir.y, dir.x);
        }

        // 角度を指定した角度に向かって移動する関数
        public static float Sign(float value)
        {
            if (value > 0f) return 1f;
            if (value < 0f) return -1f;
            return 0f;
        }

        // 角度の差を計算する関数
        public static float DeltaAngle(float current, float target)
        {
            float delta = (target - current) % 360f;
            if (delta > 180f) delta -= 360f;
            if (delta < -180f) delta += 360f;
            return delta;
        }

        // 角度を指定した角度に向かって最大の変化量で移動する関数
        public static float MoveTowardsAngle(float current, float target, float maxDelta)
        {
            float delta = DeltaAngle(current, target);
            if (Abs(delta) <= maxDelta) return target;
            return current + Sign(delta) * maxDelta;
        }

        // MoveTowards 関数を追加していきましょう
        // 2つのベクトル間を指定した速度で移動する関数
        public static Vector2 MoveTowards(Vector2 current, Vector2 target, float maxDistanceDelta)
        {            
            float distance = Distance(current, target); // 2D平面での距離計算
            if (distance <= maxDistanceDelta || distance == 0f)
            {
                return target;
            }

            Vector2 direction = target - current;
            return current + Normalized(direction) * maxDistanceDelta;
        }
        
        // ここに Lerp 関数を追加していきましょう
        // 線形補間を行う関数
        public static Vector2 Lerp(Vector2 a, Vector2 b, float t)
        {
            t = Clamp(t, 0f, 1f); // tを0〜1の範囲に制限
            return new Vector2(
                a.x + (b.x - a.x) * t,
                a.y + (b.y - a.y) * t
            );        
        }

        // ここに Lerp (vector3) 関数を追加していきましょう
        // 線形補間を行う関数 (Vector3)
        public static Vector3 Lerp(Vector3 a, Vector3 b, float t)
        {
            t = Clamp(t, 0f, 1f); // tを0〜1の範囲に制限
            return new Vector3(
                a.x + (b.x - a.x) * t,
                a.y + (b.y - a.y) * t,
                a.z + (b.z - a.z) * t
            );
        }


        // Clamp01 関数を追加していきましょう
        // 0〜1の範囲に制限する関数
        public static float Clamp01(float value)
        {
            return Clamp(value, 0f, 1f);
        }
    }
}
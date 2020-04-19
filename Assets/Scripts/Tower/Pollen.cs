// J.K. 2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 花粉の制御
public class Pollen : MonoBehaviour
{
    [SerializeField] private float line_speed = 5.0f;
    [SerializeField] private float curve_speed = 0.5f;

    // ベジェ曲線の変数
    Vector3 start;      // 開始位置
    Vector3 control1;   // 中継ポイント１
    Vector3 control2;   // 中継ポイント２
    Vector3 end;        // 終了位置
    float elapsed;      // 経過地点

    enum AttackType { line, curve }
    AttackType my_type;

    private void Start()
    {
        // 開始位置は最初の自分の位置
        start = transform.position;
        // 中継ポイント１
        // x座標:画面幅内でランダム
        // y座標:ワールド座標の0以上自分の高さ未満からランダム
        control1 = new Vector3(Random.Range(ScreenManager.Instance.Screen_min_size.x, ScreenManager.Instance.Screen_max_size.x),
            Random.Range(0.0f, transform.position.y), 0.0f);


        // 中継ポイント２
        // x座標:中継１と範囲は同じ。符号も同じにする
        // y座標:下から4分の1の地点以上ワールド座標0未満の地点からランダム
        float x = Random.Range(0.0f, ScreenManager.Instance.Screen_max_size.x);
        control2 = new Vector3(control1.x > 0.0f ? x : -x, Random.Range(ScreenManager.Instance.Screen_min_size.y / 2, 0.0f), 0.0f);


        // 終了位置は画面外にして到達すると消えるようにする
        // x座標：中継と符号は逆にする
        // y座標：
        x = Random.Range(0.0f, ScreenManager.Instance.Screen_max_size.x + 0.5f);
        end = new Vector3(control1.x > 0.0f ? -x : x, ScreenManager.Instance.Screen_min_size.y - 0.5f, 0.0f);


        elapsed = 0.0f;
        my_type = Random.value >= 0.5f ? AttackType.line : AttackType.curve;

        //Debug.Log("start:" + start);
        //Debug.Log("control1:" + control1);
        //Debug.Log("control2:" + control2);
        //Debug.Log("end:" + end);

    }

    void Update()
    {
        if (my_type == AttackType.line)
        {
            transform.Translate(0.0f, -line_speed * Time.deltaTime, 0.0f);
        }
        else if (my_type == AttackType.curve)
        {
            elapsed += curve_speed * Time.deltaTime;
           // transform.position = BezierCurve(start, control1, control2, end, elapsed);
            transform.position = MyBezeirCurve(start, control1, control2, end, elapsed);
        }

        if (ScreenManager.Instance.OutScreen(transform.position) || elapsed > 1.0f)
        {
            Destroy(gameObject);
        }

    }

    /// <summary>
    /// ベジェ曲線を使い弓なりに移動（Unity機能版）
    /// 今回は3次ベジェ曲線でより不規則な軌道にする
    /// (スタート位置、中継１、中継２、終了位置、経過地点）
    /// </summary>
    /// <param name="p0"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    Vector3 BezierCurve(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        Vector3 q0 = Vector3.Lerp(p0, p1, t);
        Vector3 q1 = Vector3.Lerp(p1, p2, t);
        Vector3 q2 = Vector3.Lerp(p2, p3, t);

        Vector3 q3 = Vector3.Lerp(q0, q1, t);
        Vector3 q4 = Vector3.Lerp(q1, q2, t);

        return Vector3.Lerp(q3, q4, t);
    }

    /// <summary>
    /// ベジェ曲線を使い弓なりに移動（自作版）
    /// (スタート位置、中継１、中継２、終了位置、経過地点）
    /// </summary>
    /// <param name="p0"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    Vector3 MyBezeirCurve(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        float a = 1 - t;

        float px = a * a * a * p0.x + 3 * a * a * t * p1.x + 3 * a * t * t * p2.x + t * t * t * p3.x;
        float py = a * a * a * p0.y + 3 * a * a * t * p1.y + 3 * a * t * t * p2.y + t * t * t * p3.y;

        return new Vector3(px, py);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}

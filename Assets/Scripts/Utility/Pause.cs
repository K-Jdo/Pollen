// J.K. 2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ゲーム内の時間を止める
public class Pause : MonoBehaviour
{
    protected float start_time;
    protected float time;         // 経過時間

    virtual protected void Update()
    {
        time = Time.realtimeSinceStartup - start_time;

    }

    protected void TimeStop()
    {
        start_time = Time.realtimeSinceStartup;
        time = 0.0f;

        // ゲーム内の時間を停止
        Time.timeScale = 0;

    }
}

// J.K. 2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// ゲーム終了時の処理
public class EndCount : Pause
{
    public bool IsEnd { get; set; }
    void Start()
    {
        start_time = -1.0f;
        IsEnd = false;
    }

    protected override void Update()
    {
        if (IsEnd)
        {
            if(start_time <= 0.0f)
            {
                SoundManager.Instance.PlaySound(SoundManager.SoundName.end);
                TimeStop();
            }
            base.Update();
            if(time >= 4.0f)
            {
                SceneManager.LoadScene("ResultScene");
            }
        }
    }
}

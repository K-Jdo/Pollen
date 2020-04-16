// J.K. 2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// スタート時に時間を止め音を鳴らす
public class StartCount : Pause
{

    void Start()
    {
        SoundManager.Instance.PlaySound(SoundManager.SoundName.start);
        TimeStop();
    }

    protected override void Update()
    {
        base.Update();
        // 音が鳴り終わればゲーム開始
        if(time >= 2.0f)
        {
            Time.timeScale = 1;
            Destroy(gameObject);
        }
    }
}

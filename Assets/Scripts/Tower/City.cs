// J.K. 2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 街の処理
public class City : Tower
{    
    void Start()
    {
        HitPoint = 100.0f;
        max_hp = 100.0f;
        // 当たり判定させるオブジェクトのタグ
        collision_name = "Pollen";
    }

    protected override void Update()
    {
        base.Update();

        if(HitPoint <= 0.0f)
        {
            HitPoint = 0.0f;
            ScreenManager.Instance.IsWin = false;
            // 終了の音
            //SoundManager.Instance.PlaySound(SoundManager.SoundName.end);
        }
    }

    /// <summary>
    /// 回復アイテムを使った処理
    /// </summary>
    public void UseHealItem()
    {
        // 仮の回復値
        HitPoint += 10.0f;
    }
}

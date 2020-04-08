// J.K. 2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 街の処理
public class City : Tower
{
    void Start()
    {
        hp = 100.0f;
        // TODO 当たり判定させるオブジェクトのタグが決まると初期値に入れる
        collision_name = "Pollen";
    }

    void Update()
    {
        if(hp <= 0.0f)
        {
            ScreenManager.Instance.IsWin = false;
            Debug.Log("hpがなくなったよ!");
            // ここにリザルト画面に飛ぶ処理を書く
        }    
    }

    /// <summary>
    /// 回復アイテムを使った処理
    /// </summary>
    public void UseHealItem()
    {
        // 仮の回復値
        hp += 10.0f;
    }
}

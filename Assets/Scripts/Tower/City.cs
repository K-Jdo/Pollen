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
        collision_name = "";
    }
}

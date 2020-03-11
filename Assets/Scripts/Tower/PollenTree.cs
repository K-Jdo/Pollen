// J.K. 2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 木の処理
public class PollenTree : Tower
{
    [SerializeField] private GameObject poolen;
    const float COOL_TIME = 2.0f;   // 花粉のクールタイム
    float poolen_time;              // 経過時間

    void Start()
    {
        // とりあえず仮の値
        hp = 20.0f;
        collision_name = "";

        poolen_time = 0.0f;
    }

    void Update()
    {
        poolen_time += Time.deltaTime;

        // 2秒ごとに花粉を出現させる
        if(poolen_time >= COOL_TIME)
        {
            GameObject.Instantiate(poolen);
            poolen_time = 0.0f;
        }
    }
}

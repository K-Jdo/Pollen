// J.K. 2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 木の処理
public class PollenTree : Tower
{
    [SerializeField] private GameObject tree_manager = default;
    [SerializeField] private GameObject pollen = default;
    TreeManager manager;
    const float COOL_TIME = 2.0f;   // 花粉のクールタイム
    float pollen_time;              // 経過時間

    void Start()
    {
        // とりあえず仮の値
        hp = 20.0f;
        collision_name = "";

        manager = tree_manager.GetComponent<TreeManager>();
        pollen_time = 0.0f;
    }

    void Update()
    {
        pollen_time += Time.deltaTime;
        // 2秒ごとに花粉を出現させる
        if(pollen_time >= COOL_TIME)
        {
            Instantiate(pollen, transform);
            pollen_time = 0.0f;
        }

        if(hp <= 0.0f)
        {
            manager.Tree_count--;
        }
    }
}

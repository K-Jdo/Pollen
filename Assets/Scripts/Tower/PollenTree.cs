// J.K. 2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 木の処理
public class PollenTree : Tower
{
    [SerializeField] private GameObject pollen = default;
    float cool_time;        // 花粉のクールタイム
    float pollen_time;      // 経過時間

    void Start()
    {
        // とりあえず仮の値
        HitPoint = 20.0f;
        max_hp = 20.0f;
        collision_name = "Bullet";

        pollen_time = 0.0f;
        // クールタイムはランダムに決定
        cool_time = Random.Range(2.0f, 6.0f);
    }

    protected override void Update()
    {
        base.Update();

        pollen_time += Time.deltaTime;

        if(pollen_time >= cool_time)
        {
            Instantiate(pollen, transform);
            pollen_time = 0.0f;
        }

        if(HitPoint <= 0.0f)
        {
            TreeManager.Instance.Tree_count--;
            Destroy(gameObject);
        }
    }

    public void SetImage(Image image, Vector3 rectPos)
    {
        hp_bar = image;
        hp_bar.rectTransform.localPosition = rectPos;
    }
}

// J.K. 2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    [SerializeField] protected Image hp_bar = default;
    public float HitPoint { get; set; }
    protected float max_hp;
    protected string collision_name;    // どのオブジェクトと当たり判定を発生させるか

    virtual protected void Update()
    {
        hp_bar.rectTransform.localScale = new Vector3(HitPoint / max_hp, 1.0f, 1.0f);
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        string tag_name = collision.gameObject.tag;
        if (tag_name == collision_name)
        {
            HitPoint -= 3.0f;
        }
    }
}

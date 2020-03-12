// J.K. 2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    protected float hp;
    protected string collision_name;    // どのオブジェクトと当たり判定を発生させるか

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        string tag_name = collision.gameObject.tag;
        
        if (tag_name == collision_name)
        {
            hp -= 3.0f;
        }
    }
}

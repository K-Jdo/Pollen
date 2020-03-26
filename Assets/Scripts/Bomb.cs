// 製作者；塚野莉央
// 爆弾

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    void Update()
    {
        transform.Translate(0, 0.2f, 0);
    }

    //木にぶつかったら消滅
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Destroy(gameObject);
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}

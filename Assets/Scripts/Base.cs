// 製作者：塚野
// 拠点

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    public Sprite sprite;

    private float hit;
    
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        City city = new City();
        hit = city.HitPoint;
        // if文の中に画像を変える条件を書く
        if(hit < 30)
        {
            GetComponent<CircleCollider2D>().enabled = false;
            spriteRenderer.sprite = sprite;
        }        
    }
}

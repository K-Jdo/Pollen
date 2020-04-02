// 製作者：塚野
// 拠点

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    public Sprite sprite;

    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        // if文の中に画像を変える条件を書く
        if(Input.GetKeyDown("joystick button 2"))
        {
            spriteRenderer.sprite = sprite;
        }        
    }
}

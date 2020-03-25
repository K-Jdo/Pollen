// J.K. 2020
using System.Collections;
using UnityEngine;

// 画面サイズの取得
public class ScreenManager : SingletonMonoBehaviour<ScreenManager>
{
    // ゲーム画面の大きさを格納する変数
    public Vector2 screen_max_size;     // 画面右上の座標
    public Vector2 screen_min_size;     // 画面左下の座標

    protected override void Awake()
    {
        base.Awake();
        // 画面サイズを取得, ワールドに変換
        screen_max_size = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)); 
        screen_min_size = Camera.main.ScreenToWorldPoint(Vector2.zero);
    }

    /// <summary>
    /// 画面外に出たときの処理
    /// 主に弾など
    /// </summary>
    /// <param name="position"></param>
    public bool OutOfScreen(Vector2 position)
    {
        // 画面外に出たら消える
        if(position.x > screen_max_size.x || position.x < screen_min_size.x
            || position.y > screen_max_size.y || position.y < screen_min_size.y)
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// 画面外に出ないようにする処理
    /// (座標、colliderのサイズ)
    /// </summary>
    /// <param name="position"></param>
    /// <param name="size"></param>
    public void RangeOfScreen(Vector2 position, Vector2 size)
    {
        transform.position = new Vector2(Mathf.Clamp(position.x, screen_min_size.x + size.x, screen_max_size.x - size.x),
           Mathf.Clamp(transform.position.y, screen_min_size.y + size.y, screen_max_size.y - size.y));
    }

    
}

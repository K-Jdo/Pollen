// J.K. 2020
using System.Collections;
using UnityEngine;

// 画面制御
public class ScreenManager : SingletonMonoBehaviour<ScreenManager>
{
    // ゲーム画面の大きさを格納する変数
    public Vector2 Screen_max_size { get; set; }    // 画面右上の座標
    public Vector2 Screen_min_size { get; set; }     // 画面左下の座標

    public bool IsWin { get; set; }

    protected override void Awake()
    {
        base.Awake();
        // 画面サイズを取得, ワールドに変換
        Screen_max_size = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)); 
        Screen_min_size = Camera.main.ScreenToWorldPoint(Vector2.zero);
        IsWin = false;

        DontDestroyOnLoad(this);
    }

    /// <summary>
    /// 画面外に出たときの処理
    /// 主に弾など
    /// </summary>
    /// <param name="position"></param>
    public bool OutScreen(Vector2 position)
    {
        // 画面外に出たら消える
        if(position.x > Screen_max_size.x || position.x < Screen_min_size.x
            || position.y > Screen_max_size.y || position.y < Screen_min_size.y)
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// 画面外に出ないようにする処理
    /// (座標、BoxColliderのサイズ)
    /// </summary>
    /// <param name="position"></param>
    /// <param name="size"></param>
    public Vector2 RangeScreen(Vector2 position, Vector2 size)
    {
        return new Vector2(Mathf.Clamp(position.x, Screen_min_size.x + size.x, Screen_max_size.x - size.x),
           Mathf.Clamp(position.y, Screen_min_size.y + size.y, Screen_max_size.y - size.y));
    }

    /// <summary>
    /// 画面外に出ないようにする処理
    /// (座標、CircleColliderの半径)
    /// </summary>
    /// <param name="position"></param>
    /// <param name="radius"></param>
    public Vector2 RangeScreen(Vector2 position, float radius)
    {
        return new Vector2(Mathf.Clamp(position.x, Screen_min_size.x + radius, Screen_max_size.x - radius),
           Mathf.Clamp(position.y, Screen_min_size.y + radius, Screen_max_size.y - radius));
    }
}

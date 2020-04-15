// J.K. 2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// ボタンの制御
public class Button : ButtonController
{
    string[] names =
    {
        "Start",
        "Credit",
        "Title"
    };

    protected override void OnClick(string name)
    {
        if(names[0] == name)
        {
            // ゲームに遷移
            Debug.Log("ゲーム");
        }
        else if(names[1] == name)
        {
            // クレジットに遷移
            Debug.Log("クレジット");
        }
        else if(names[2] == name)
        {
            // タイトルシーンに遷移
            Debug.Log("タイトルへ");
        }
    }
}

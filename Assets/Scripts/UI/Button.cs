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
        SoundManager.Instance.PlaySound(SoundManager.SoundName.click);
        if(names[0] == name)
        {
            // ゲームに遷移
            SceneManager.LoadScene("GameScene");
        }
        else if(names[1] == name)
        {
            // クレジットに遷移
            SceneManager.LoadScene("CreditScene");
        }
        else if(names[2] == name)
        {
            // タイトルシーンに遷移
            SceneManager.LoadScene("ResultScene");
        }
    }
}

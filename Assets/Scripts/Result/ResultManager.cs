// J.K. 2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// リザルトシーンを管理するクラス
public class ResultManager : MonoBehaviour
{
    [SerializeField] private Text text = default;
    void Start()
    {
        if (ScreenManager.Instance.IsWin)
        {
            SoundManager.Instance.PlaySound(SoundManager.SoundName.clear);
            text.text = "WIN";
        }
        else
        {
            SoundManager.Instance.PlaySound(SoundManager.SoundName.defeat);
            text.text = "PANDEMIC";
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("joystick button 0"))
        {
            // タイトルシーンに戻る
            Debug.Log("タイトルに戻るよ！");
        }
    }
}

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
            text.text = "WIN";
        }
        else
        {
            text.text = "PANDEMIC";
        }
    }

    void Update()
    {
        if(Input.GetKeyDown("joystick button 0"))
        {
            // タイトルシーンに戻る
            Debug.Log("タイトルに戻るよ！");
        }
    }
}

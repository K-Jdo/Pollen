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
    float sound_end = 7.0f;

    float time = 0.0f;
    void Start()
    {
        Time.timeScale = 1;
        if (ScreenManager.Instance.IsWin)
        {
            SoundManager.Instance.PlaySound(SoundManager.SoundName.clear);
            text.text = "WIN";
        }
        else
        {
            SoundManager.Instance.PlaySound(SoundManager.SoundName.defeat);
            text.text = "PANDEMIC";
            sound_end = 6.0f;
        }
        Debug.Log(sound_end);
    }

    void Update()
    {
        time += Time.deltaTime;
        Debug.Log(time);
        if(time <= sound_end)
        {
            return;
        }

        if (Input.GetKeyDown("joystick button 0") || Input.GetMouseButtonDown(0))
        {
            // タイトルシーンに戻る
            SceneManager.LoadScene("TitleScene");
        }
    }
}

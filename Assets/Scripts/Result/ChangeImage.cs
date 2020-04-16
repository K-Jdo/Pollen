// J.K. 2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// UIイメージを変更する
public class ChangeImage : MonoBehaviour
{
    [SerializeField] private Sprite sprite = default;
    private void Awake()
    {
        // 敗北時の画像に変更
        if (!ScreenManager.Instance.IsWin)
        {
            GetComponent<Image>().sprite = sprite;
        }
    }
}

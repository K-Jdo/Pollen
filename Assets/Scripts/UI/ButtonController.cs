// J.K. 2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ボタンのコントロールするクラス
public class ButtonController : MonoBehaviour
{
    [SerializeField] private ButtonController button = default;

    public void OnClick()
    {
        button.OnClick(gameObject.name);
    }

    protected virtual  void OnClick(string name)
    {
        // ここでは何もしない
    }
}

// 製作者：塚野莉央
// プレイヤーが爆弾を発射する処理

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject BombPrefab;

    // とりあえず、スペースキーを押したら爆弾発射
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(BombPrefab, transform.position, Quaternion.identity);
        }
    }
}

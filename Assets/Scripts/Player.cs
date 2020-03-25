// 製作者：塚野莉央
// プレイヤーが爆弾を発射する処理

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject BombPrefab;

    void Update()
    {
        // 攻撃
        if (Input.GetKeyDown("joystick button 1"))
        {
            Instantiate(BombPrefab, transform.position, Quaternion.identity);
        }

        // 回復
        if(Input.GetKeyDown("joystick button 4") && Input.GetKeyDown("joystick button 0"))
        {
            Debug.Log("Cure");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 拠点に入ったとき
        Debug.Log("Enter");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // 拠点にいるとき
        Debug.Log("Stay");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // 拠点から出たとき
        Debug.Log("Exit");
    }
}

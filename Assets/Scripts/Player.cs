// 製作者：塚野莉央
// プレイヤーの攻撃・回復

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public double hp = 100;
    public GameObject BombPrefab;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //攻撃
        if (collider.gameObject.tag == "Attack")
        {
            if (Input.GetKeyDown("joystick button 0"))
            {
                Instantiate(BombPrefab, transform.position, transform.rotation);
            }
        }

        //回復
        if (collider.gameObject.tag == "Heal")
        {
            if (Input.GetKeyDown("joystick button 5") && Input.GetKeyDown("joystick button 0"))
            {
                hp *= 1.3;
            }
        }
    }
}

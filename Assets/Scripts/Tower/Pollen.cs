// J.K. 2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 花粉の制御
public class Pollen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0.0f, -0.1f, 0.0f);
        if (ScreenManager.Instance.OutOfScreen(transform.position))
        {
            Destroy(gameObject);
        }
    }
}

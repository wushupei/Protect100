using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spark : MonoBehaviour
{
    void OnEnable()
    {
        Invoke("Des", 1); //1s后自行销毁
    }
    void Des()
    {
        Destroy(gameObject);
    }
}

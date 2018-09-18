using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aerolite : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y < -20) //落到一定位置,销毁自身
            Destroy(gameObject);
    }
}

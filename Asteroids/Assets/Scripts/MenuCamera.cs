using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamera : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += Vector3.up * 0.03f;
    }
}

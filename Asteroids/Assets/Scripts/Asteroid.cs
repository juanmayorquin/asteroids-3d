using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private float minScale, maxScale, tumble;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 scale = Vector3.one;
        scale.x = UnityEngine.Random.Range(minScale, maxScale);
        scale.y = UnityEngine.Random.Range(minScale, maxScale);
        scale.z = UnityEngine.Random.Range(minScale, maxScale);

        transform.localScale = scale;

        GetComponent<Rigidbody>().angularVelocity = UnityEngine.Random.insideUnitSphere * UnityEngine.Random.Range(-tumble, tumble);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

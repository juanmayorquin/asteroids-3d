using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private float minScale, maxScale, tumble;
    [SerializeField] private Asteroid nextAsteroid;
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

    private void Awake()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)) * 30;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Duplicar()
    {
        if(nextAsteroid != null)
        {
            Asteroid ast1 = Instantiate(nextAsteroid, transform.position, transform.rotation);
            ast1.GetComponent<Rigidbody>().velocity = transform.forward * 50;

            Asteroid ast2 = Instantiate(nextAsteroid, transform.position, transform.rotation);
            ast2.GetComponent<Rigidbody>().velocity = -transform.forward * 50;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}

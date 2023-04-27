using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Transactions;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] private GameObject balaPrefab;
    [SerializeField] private Rigidbody rb;
    [SerializeField] float timeAlive, timer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > timeAlive)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.collider.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Asteroid>().Duplicar();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}

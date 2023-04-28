using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Bala : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] float timeAlive, timer;
    [SerializeField] AudioManager audioManager;
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
            //PlayerInfo.score += collision.collider.GetComponent<Asteroid>().score;
            collision.gameObject.GetComponent<Asteroid>().Duplicar();
            audioManager.asteroidBoom.Play();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}

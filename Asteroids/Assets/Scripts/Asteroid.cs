using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public int score;
    [SerializeField] private float minScale, maxScale, tumble;
    [SerializeField] private Asteroid nextAsteroid;
    [SerializeField] private GameObject explosion;
    public AudioSource explode;
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
            Instantiate(nextAsteroid, transform.position, transform.rotation);
            Instantiate(nextAsteroid, transform.position, transform.rotation);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerInfo.vidas--;
            collision.gameObject.GetComponent<Player>().ResetPosition();

            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        var exp = Instantiate(explosion, transform.position, transform.rotation);
        explode.Play();
        PlayerInfo.score += score;
    }
}

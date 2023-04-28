using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int turnoDisparador = 0;
    [SerializeField] private float rotationSpeed, speed, bulletSpeed, cooldown;
    private float timer;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform rightFire, leftFire;
    [SerializeField] private GameObject propulsor1, propulsor2, propulsor3, explosion;
    [SerializeField] private Bala Bala;
    public AudioSource shoot, impulse, death;
    
    private float xTarget = 0;
    private float yTarget = 0;
    private float zTarget = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Rotar();
        Avanzar();
        Shoot();

        if(rb.velocity.magnitude <= 0.1f )
        {
            propulsor1.GetComponent<TrailRenderer>().enabled = false;
            propulsor2.GetComponent<TrailRenderer>().enabled = false;
            propulsor3.GetComponent<TrailRenderer>().enabled = false;
        }
        else if (rb.velocity.magnitude >= 0.11f)
        {
            propulsor1.GetComponent<TrailRenderer>().enabled = true;
            propulsor2.GetComponent<TrailRenderer>().enabled = true;
            propulsor3.GetComponent<TrailRenderer>().enabled = true;
        }
    }

    public void Rotar()
    {
        xTarget = Input.GetAxis("Vertical") * rotationSpeed * Time.deltaTime;
        yTarget = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        zTarget = Input.GetAxis("Roll") * rotationSpeed * Time.deltaTime;

        transform.Rotate(xTarget, yTarget, -zTarget);
    }

    public void Avanzar()
    {
        rb.velocity = Input.GetAxis("Jump") * speed * transform.forward;
        if ( Input.GetKeyDown(KeyCode.Space))
        {
            impulse.Play();
        }
        
    }

    void Shoot()
    {
        timer += Time.deltaTime;

        if (Input.GetAxis("Fire1") != 0)
        {
            if(timer > cooldown)
            {
                switch(turnoDisparador)
                {
                    case 0:
                        var bullet = Instantiate(Bala, rightFire.position, rightFire.rotation);
                        bullet.GetComponent<Rigidbody>().velocity = (rightFire.forward * bulletSpeed);
                        shoot.Play();
                        timer = 0;
                        turnoDisparador++;
                        break;
                    case 1:
                        var bala = Instantiate(Bala, leftFire.position, leftFire.rotation);
                        bala.GetComponent<Rigidbody>().velocity = (rightFire.forward * bulletSpeed);
                        shoot.Play();
                        timer = 0;
                        turnoDisparador = 0;
                        break;
                }
            }
        }
    }

    public void ResetPosition()
    {
        transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
        rb.angularVelocity = Vector3.zero;
        rb.velocity = Vector3.zero;
    }

    private void OnDestroy()
    {
        Instantiate(explosion, transform.position, transform.rotation);
    }
}

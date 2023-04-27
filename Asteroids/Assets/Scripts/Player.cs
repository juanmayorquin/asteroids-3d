using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int turnoDisparador = 0;
    [SerializeField] private float rotationSpeed, speed, bulletSpeed, timer, cooldown;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform rightFire, leftFire;
    [SerializeField] private Bala Bala;
    
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
        rb.velocity = transform.forward * speed * Input.GetAxis("Jump");
        
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
                        bullet.GetComponent<Rigidbody>().velocity = rightFire.forward * bulletSpeed;
                        timer = 0;
                        turnoDisparador++;
                        break;
                    case 1:
                        var bala = Instantiate(Bala, leftFire.position, leftFire.rotation);
                        bala.GetComponent<Rigidbody>().velocity = rightFire.forward * bulletSpeed;
                        timer = 0;
                        turnoDisparador = 0;
                        break;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        
    }
}

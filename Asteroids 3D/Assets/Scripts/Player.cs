using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isMoving;
    [SerializeField] private float rotationSpeed, speed;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform rightFire, leftFire;
    [SerializeField] private GameObject Bala;
    
    private float xTarget = 0;
    private float yTarget = 0;
    private float zTarget = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Rotar();
        Avanzar();
        Shoot();

        if(rb.velocity.magnitude > 1)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
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
        rb.velocity = transform.forward * speed * Input.GetAxis("Jump");
        
    }

    void Shoot()
    {
        if (Input.GetAxis("Fire1") != 0)
        {
            Debug.Log("Hola");
            Instantiate(Bala, leftFire.position, transform.rotation);
        }
    }
}

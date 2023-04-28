using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Vector3 velocity = Vector3.one;
    [SerializeField] private GameObject player;
    private Vector3 distance;

    // Start is called before the first frame update
    void Start()
    {
        distance = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 toPos = player.transform.position + (player.transform.rotation * distance * 1.25f);
        transform.position = Vector3.SmoothDamp(transform.position, toPos, ref velocity, 0.1f);

        Quaternion toRot = Quaternion.LookRotation((player.transform.position - transform.position), player.transform.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, toRot, 10f * Time.deltaTime);
    }
}

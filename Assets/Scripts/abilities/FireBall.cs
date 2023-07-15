using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public FireBall fireBall;
    Rigidbody rigidbody;
    public float speed;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        speed = 100.0f;
    }

    // Update is called once per frame
    void Update()
    {
        fireBall.transform.LookAt(target.transform);
        rigidbody.velocity = transform.forward * speed;
    }
}

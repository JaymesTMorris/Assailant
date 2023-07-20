using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shared.Skills.Fireball;

public class FireBallObject : MonoBehaviour
{
    public FireBallObject fireBall;
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
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auraeffects : MonoBehaviour
{
   // Start is called before the first frame update
    void Start()
    {
        GameObject instance = Instantiate(Resources.Load("heal", typeof(GameObject))) as GameObject;
        instance.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

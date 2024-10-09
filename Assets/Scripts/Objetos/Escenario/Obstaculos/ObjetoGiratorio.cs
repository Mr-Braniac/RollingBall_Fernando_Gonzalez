using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoGiratorio : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float fuerzaDeGiro;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddTorque(new Vector3(0, 10, 0) * fuerzaDeGiro, ForceMode.VelocityChange);

    }

    // Update is called once per frame
    void Update()
    {
       
    }
}



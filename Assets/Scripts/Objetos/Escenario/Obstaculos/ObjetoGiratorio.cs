using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class ObjetoGiratorio : MonoBehaviour
{
    [SerializeField] private Vector3 direccion; //Dirección del movimiento
    [SerializeField] private float velocidad; //Velocidad del movimiento
    [SerializeField] private float TiempoDeVuelta; //El tiempo en el cual cambiamos de dirección


    //HACER QUE LA PLATAFORMA HAGA MOVIMIENTO DE IDA Y VUELTA
    // A TRAVÉS DEL TRANSFORM (NO FÍSICAS)

    private Rigidbody rb;
    private float timer; //Cronómetro.

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // En el velocity, ya esta medido por segundo, por lo cual no es necesario hacer Time.deltaTime.
        rb.velocity = direccion * velocidad;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // A mi timer le SUMO 1 POR SEGUNDO
        // timer = timer + 1 * Time.deltaTime;
        if (timer > TiempoDeVuelta)
        {
            // Cambiar dirección. ()
            direccion *= -1;
            rb.velocity = direccion * velocidad; //Refresco la velocidad nueva.
            // Reset tiempo
            timer = 0;

        }

    }


}

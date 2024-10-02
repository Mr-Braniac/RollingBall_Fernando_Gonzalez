using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    public Vector3 puntoInicial; //Punto inicial de la plataforma
    public Vector3 puntoFinal; //Punto final de la plataforma
    public float velocidad = 2.0f; //Velocidad de la plataforma

    private bool moviendoHaciaPuntoFinal = true;
    

    // Start is called before the first frame update
    void Start()
    {
        //seteamos la ubicación inicial del objeto
        puntoInicial = transform.position;

        Debug.Log("Posicion Inicial: " + puntoInicial);
        Debug.Log("Posición Final: " + puntoFinal);
    }

    // Update is called once per frame
    void Update()
    {
        MoverPlataforma();

    }

    void MoverPlataforma()
    {
        if (moviendoHaciaPuntoFinal)
        {
            transform.position = Vector3.MoveTowards(transform.position, puntoFinal, velocidad * Time.deltaTime);

            Debug.Log("Moviendo hacia Punto Final: " + transform.position);

        }
        if (transform.position == puntoFinal)
        {
            moviendoHaciaPuntoFinal = false;

            Debug.Log("Cambio de dirección: Hacia el punto inicial");
        }

        else
        {
            transform.position = Vector3.MoveTowards(transform.position, puntoInicial, velocidad * Time.deltaTime);

            Debug.Log("Moviendo hacia Punto Incial" + transform.position);

            if (Vector3.Distance(transform.position, puntoInicial) < 1f)
            {
                moviendoHaciaPuntoFinal = true;

                Debug.Log("Cambio de dirección: Hacia el punto Final");
            }

        }

    }

}

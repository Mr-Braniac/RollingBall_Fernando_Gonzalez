using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    private Vector3 puntoInicial; //Punto inicial de la plataforma
    private Vector3 puntoFinal; //Punto final de la plataforma
    public float velocidad = 5.0f; //Velocidad de la plataforma

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
            Vector3 direccion = (puntoFinal - transform.position).normalized;

            transform.Translate(direccion * velocidad * Time.deltaTime, Space.World);

        }
        if (transform.position == puntoFinal)
        {
            moviendoHaciaPuntoFinal = false;

            Debug.Log("Cambio de dirección: Hacia el punto inicial");

            if (transform.position != puntoFinal)
            {
                moviendoHaciaPuntoFinal = false;
            }
            
        }
        else
        {
            Vector3 direccion = (puntoInicial - transform.position).normalized;

            transform.Translate(direccion * velocidad * Time.deltaTime, Space.World);

            if (transform.position == puntoInicial)
            {
                moviendoHaciaPuntoFinal = true;
            }
        }

        

    }

}

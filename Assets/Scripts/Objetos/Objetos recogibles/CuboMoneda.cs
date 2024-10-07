using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuboMoneda : MonoBehaviour
{
    [SerializeField] private float velocidadGiro;
    [SerializeField] private AudioClip clipMoneda;
    //private GameManager gameManager;


    void Start()
    {
        //gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //El cubo ha de totar a 30º/s de forma CONSTANTE en el eje "y" global.
        transform.Rotate(new Vector3(0, 1, 0) * velocidadGiro * Time.deltaTime, Space.World);
    }


    //M´todo que se ejecuta JUDTO ANTES de destruirnos
    private void OnDestroy()
    {
        if (gameObject != null)
        {

            //gameManager.ReproducirSonido(clipMoneda);

        }
        // Comunicar al Gamemanager que quiero

        //2. Comunicarnos con el gameManager invocando dicha función
    }
}

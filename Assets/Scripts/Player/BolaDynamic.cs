using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//Cosas para textos y UI
using Unity.UI;
using TMPro;

public class BolaDynamic : MonoBehaviour
{
    //private GameManager gameManager;
    [SerializeField] private AudioClip clipSalto;

    private Rigidbody rb;
    [SerializeField] private float fuerza;
    [SerializeField] private float fuezaSalto = 5;
    private float inputH;
    private float inputV;
    [SerializeField] private TMP_Text textoScore;
    private int score;
    private Vector3 posicionSpawn;
    [SerializeField] private LayerMask queEsSaltable;


    void Start()
    {
        posicionSpawn = transform.position;

        rb = GetComponent<Rigidbody>();

        //gameManager = GameObject.FindObjectOfType<GameManager>();
    }
    //Trigger es que se puede ATRAVESAR

    void Update()
    {
        LacturaInputs();

        Salto();
    }

    private void LacturaInputs()
    {
        inputH = Input.GetAxisRaw("Horizontal");
        inputV = Input.GetAxisRaw("Vertical");
    }
    private void Salto()
    {
        //Cuando se aprieta el ESPACIO, la bola debe saltar.
        if (Input.GetKeyDown(KeyCode.Space)/* && EstoyEnSuelo*/)
        {
            rb.AddForce(Vector3.up * fuezaSalto, ForceMode.Impulse);
            //gameManager.ReproducirSonido(clipSalto);
        }
    }

    private bool EstoyEnSuelo()
    {
        bool sueloDebajo = Physics.Raycast(transform.position, Vector3.down, 0.3f, queEsSaltable);
        return sueloDebajo;

    }


    //Las FUERZAS CONTINUAS SIEMPRE van en el FixedUpdate. (Ciclo continuo)
    //Se ejecuta cada 0,02 segundos DE FORMA FIJA
    private void FixedUpdate()
    {
        rb.AddForce(new Vector3(inputH, 0, inputV).normalized * fuerza, ForceMode.Force);

    }

    private void ActualizarUi()
    {
        score++;
        textoScore.text = "Score: " + score;
    }

    //Cuando la bola ATRAVIESE el cubo moneda, se lo ha de comer.
    private void OnTriggerEnter(Collider other)
    {
        Saltar(other);
    }

    private void Saltar(Collider other)
    {
        //Construir una UI que refleje la puntuación.
        //Por cada cubo que se coja sumamos 1 puntos.
        //
        //El ComparTag es para hacer bien el comprobar los tag.
        if (other.CompareTag("Moneda"))
        {
            ActualizarUi();

            Destroy(other.gameObject);
        }
    }
    private void Caida(Collider Reset)
    {
        if (Reset.CompareTag("Reset"))
        {
            transform.position = posicionSpawn;
        }
    }



}
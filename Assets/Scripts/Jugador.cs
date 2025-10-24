using System.Collections;
using System.Threading;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jugador : MonoBehaviour
{
    [SerializeField] float velocidad = 0.1f;
    [SerializeField] int vida = 5;
    [SerializeField] string nombre = "PJ 1";
    [SerializeField] bool invulnerable = false;
    [SerializeField] Vector3 posicionInicial = new Vector3(0, 0, 0);
    [SerializeField] int[] municiones = { 500, 0, 0 };
    public InputActionReference mover, atacar;
    [SerializeField] GameObject prefabBala;
    [SerializeField] GameObject prefabExplosion;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void OnEnable()
    {
        atacar.action.started += Atacar;
    }

    void OnDisable()
    {
        atacar.action.started -= Atacar;
    }

    void Atacar(InputAction.CallbackContext obj)
    {
        TripleDisparo();
    }

    void TripleDisparo()
    {
        CrearBala(new Vector3(0, 1.5f, 0), 0);
        CrearBala(new Vector3(1f, 1, 0), -45);
        CrearBala(new Vector3(-1f, 1, 0), 45);
    }

    void CrearBala(Vector3 desplazamiento, float angulo)
    {
        Instantiate(prefabBala, transform.position + desplazamiento, Quaternion.Euler(0, 0, angulo));

    }

    // Update is called once per frame
    void Update()
    {
        //transform.position.x += 0.1f;
        Vector2 direccion = mover.action.ReadValue<Vector2>();
        // print("Direccion: " + direccion);
        //print(Time.deltaTime);
        transform.position += (Vector3)direccion * velocidad * Time.deltaTime;

        if (vida < 1)
        {
            CrearExplosion(transform.position);
            Destroy(this.gameObject);
        }

    }

    void CrearExplosion(Vector3 posicion)
    {
        Instantiate(prefabExplosion, posicion, Quaternion.Euler(0, 0, 0));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("RocaColision"))
        {
            vida -= 3;

        }

        if (collision.gameObject.CompareTag("EnemigoColision"))
        {
            vida -= 1;
        }


    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EvilBalaColision"))
        {
            Destroy(collision.gameObject);
            vida -= 1;

        }

    }

}

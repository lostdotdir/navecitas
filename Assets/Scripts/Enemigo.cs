using System.Collections;
using UnityEngine;

public class Enemigo : MonoBehaviour
{

    [SerializeField] float velocidad = 0.1f;
    [SerializeField] int vida = 3;
    [SerializeField] string nombre;
    [SerializeField] bool invulnerable = false;
    [SerializeField] bool empiezaIzquierda = true;
    [SerializeField] Vector3 posicionInicial = new Vector3(0, 0, 0);
    [SerializeField] GameObject prefabExplosion;
    [SerializeField] GameObject prefabEvilBala;
    [SerializeField] float intervaloDisparos = 1f;
    SpriteRenderer spriteRenderer;

    float contador;

    void CrearBala(Vector3 desplazamiento, float angulo)
    {
        Instantiate(prefabEvilBala, transform.position + desplazamiento, Quaternion.Euler(0, 0, angulo));

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(DisparoRepetitivo());
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direccion = new Vector3(0, 0, 0);

        if (transform.position.x < -10)
        {
            print("estoy a la derecha");
            empiezaIzquierda = false;
        }

        else if (transform.position.x > 10)
        {
            print("estoy a la izquierda");
            empiezaIzquierda = true;
        }

        if (empiezaIzquierda)
        {
            direccion = new Vector3(-10, 0, 0);
        }

        else
        {
            direccion = new Vector3(10, 0, 0);
        }

        transform.position += (Vector3)direccion * velocidad * Time.deltaTime;
    }

    void CrearExplosion(Vector3 posicion)
    {
        Instantiate(prefabExplosion, posicion, Quaternion.Euler(0, 0, 0));
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BalaColision"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(RecibirImpacto());

            if (vida > 1)
            {
                vida--;
            }
            else
            {
                CrearExplosion(transform.position);
                Destroy(this.gameObject);
            }

        }

    }

    IEnumerator DisparoRepetitivo()
    {
        while (true)
        {
            yield return new WaitForSeconds(intervaloDisparos);
            CrearBala(new Vector3(0, -1, 0), 180);

        }
    }

    IEnumerator RecibirImpacto()
    {
        spriteRenderer.color = new Color(0, 0.85f, 0.93f);
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }
}

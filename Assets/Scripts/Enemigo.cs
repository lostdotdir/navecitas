using UnityEngine;

public class Enemigo : MonoBehaviour
{

    [SerializeField] float velocidad = 0.1f;
    [SerializeField] int vida = 3;
    [SerializeField] string nombre;
    [SerializeField] bool invulnerable = false;
    [SerializeField] Vector3 posicionInicial = new Vector3(0, 0, 0);
    [SerializeField] GameObject prefabExplosion;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
}

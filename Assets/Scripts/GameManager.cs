using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject prefabRoca;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnRoca());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnRoca()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(2f,4f));
            CrearRoca();

        }
    }
    
    void CrearRoca()
    {
        Vector3 posicion = new Vector3(Random.Range(-9f, 9f), Random.Range(-5f, 5f), 0);
        Instantiate(prefabRoca, posicion, Quaternion.Euler(0,0, Random.Range(0,360)));
    }
}

using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] float velocidad = 3;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += new Vector3(0, velocidad, 0) * Time.deltaTime;
        transform.position += transform.up * Time.deltaTime * velocidad;
    }
}

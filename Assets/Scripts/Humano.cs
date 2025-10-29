using UnityEngine;
using UnityEngine.InputSystem;

public class Humano : MonoBehaviour
{

    [SerializeField] public InputActionReference saltar, mover, atacar;
    [SerializeField] float velocidad = 3, fuerzaSalto = 6;
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void OnEnable()
    {
        atacar.action.started += Atacar;
        saltar.action.started += Saltar;
    }

    void OnDisable()
    {
        atacar.action.started -= Atacar;
        saltar.action.started -= Saltar;
    }

    private void Atacar(InputAction.CallbackContext obj)
    {

    }

    private void Saltar(InputAction.CallbackContext obj)
    {
        rb.linearVelocityY = fuerzaSalto;
    }

    // Update is called once per frame
    void Update()
    {
        float direccion = mover.action.ReadValue<float>();

        //transform.position += direccion * velocidad * Vector3.right * Time.deltaTime;
        rb.linearVelocityX = velocidad * direccion;
    }
}

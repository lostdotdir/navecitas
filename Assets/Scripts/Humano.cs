using UnityEngine;
using UnityEngine.InputSystem;

public class Humano : MonoBehaviour
{

    [SerializeField] public InputActionReference saltar, mover, atacar;
    [SerializeField] float velocidad = 3, fuerzaSalto = 6, distanciaSensorSuelo = 0.6f;
    [SerializeField] LayerMask mascaraSuelo;
    [SerializeField] bool enSuelo;
    Rigidbody2D rb;
    Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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
        if (enSuelo)
        {
            rb.linearVelocityY = fuerzaSalto;
        }
    }

    // Update is called once per frame
    void Update()
    {
        SensorSuelo();
        Movimiento();
        ActualizarAnimator();
    }

    void Movimiento()
    {
        float direccion = mover.action.ReadValue<float>();

        //transform.position += direccion * velocidad * Vector3.right * Time.deltaTime;
        rb.linearVelocityX = velocidad * direccion;

        if (direccion < 0)
            transform.rotation = Quaternion.Euler(0, 180, 0);
        else if (direccion > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void ActualizarAnimator()
    {
        if (rb.linearVelocityX == 0)
        {
            animator.SetBool("movx", false);
        }
        else
        {
            animator.SetBool("movx", true);
        }
        animator.SetFloat("vely", rb.linearVelocityY);
        animator.SetBool("ensuelo", enSuelo);
    }

    void SensorSuelo()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distanciaSensorSuelo, mascaraSuelo);
        Debug.DrawRay(transform.position, Vector2.down * distanciaSensorSuelo, Color.red);
        enSuelo = hit ? true : false;
    }
}

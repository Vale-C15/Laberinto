using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;
    public float maxSpeed = 10f;

    private Rigidbody rb;
    private Vector3 moveDirection;
    private Vector3 startPosition = new Vector3(-2f, 0.4f, -5.9f); //El jugador siempre inicia en este punto

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.position = startPosition;

    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calcular la dirección de movimiento
        moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        if (moveDirection != Vector3.zero)
        {
            Vector3 newPosition = rb.position + moveDirection * speed * Time.fixedDeltaTime;
            rb.MovePosition(newPosition);
        }
    }
}

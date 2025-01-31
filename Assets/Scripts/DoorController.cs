using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform door; // Referencia a la puerta
    public Vector3 openPositionOffset = new Vector3(0f, 0f, 5f);
    public float openSpeed = 5f; // Velocidad de apertura
    public KeyCode openKey = KeyCode.X; // Tecla para abrir la puerta
    public string playerTag = "Player"; // Tag del jugador
    public int requiredKeys = 5; // Número de llaves necesarias para abrir la puerta

    private Vector3 closedPosition; // Posición inicial (cerrada)
    private Vector3 targetPosition; // Posición objetivo
    private bool isOpen = false; // Estado de la puerta
    private bool playerNearby = false; // ¿Está el jugador cerca?
    private Keys keyManager;

    void Start()
    {
        // Guardar la posición inicial de la puerta
        closedPosition = door.localPosition;
        targetPosition = closedPosition;

    }

    void Update()
    {
        // Verificar si el jugador está cerca, presiona la tecla X y tiene suficientes llaves
        if (playerNearby && Input.GetKeyDown(openKey) && keyManager != null && keyManager.GetKeyCount() >= requiredKeys)
        {
            // Alternar el estado de la puerta
            isOpen = !isOpen;

            if (isOpen)
            {
                targetPosition = closedPosition + openPositionOffset;
            }
            else
            {
                targetPosition = closedPosition;
            }
        }

        // Suavizar el movimiento hacia la posición objetivo
        door.localPosition = Vector3.Lerp(door.localPosition, targetPosition, Time.deltaTime * openSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        // Verificar si el jugador entró en el área de la puerta
        if (other.CompareTag(playerTag))
        {
            playerNearby = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Verificar si el jugador salió del área de la puerta
        if (other.CompareTag(playerTag))
        {
            playerNearby = false;
        }
    }
}

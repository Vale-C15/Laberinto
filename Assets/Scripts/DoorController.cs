using UnityEngine;
using TMPro;

public class DoorController : MonoBehaviour
{
    public Transform door; // Referencia a la puerta
    private Vector3 openPositionOffset = new Vector3(2f, 0f, 0f);
    public float openSpeed = 3f; // Velocidad de apertura
    public KeyCode openKey = KeyCode.X; // Tecla para abrir la puerta
    public string playerTag = "Player"; // Tag del jugador
    public int requiredKeys = 5; // N�mero de llaves necesarias para abrir la puerta
    public KeyController keyManager;
    public TextMeshProUGUI congratulationMessageText;

    private Vector3 closedPosition; // Posici�n inicial (cerrada)
    private Vector3 targetPosition; // Posici�n objetivo
    private bool isOpen = false; // Estado de la puerta
    private bool playerNearby = false; // �Est� el jugador cerca?
    

    void Start()
    {
        // Guardar la posici�n inicial de la puerta
        closedPosition = door.localPosition;
        targetPosition = closedPosition;

    }

    void Update()
    {
        // Verificar si el jugador est� cerca, presiona la tecla X y tiene suficientes llaves
        if (playerNearby && Input.GetKeyDown(openKey) && keyManager != null && keyManager.GetKeyCount() >= requiredKeys)
        {
            // Alternar el estado de la puerta
            isOpen = !isOpen;

            if (isOpen)
            {
                targetPosition = closedPosition + openPositionOffset;
                congratulationMessageText.text = "�FELCIDADES! Has ganado c:";
            }
            else
            {
                targetPosition = closedPosition;
            }
        }

        // Suavizar el movimiento hacia la posici�n objetivo
        door.localPosition = Vector3.Lerp(door.localPosition, targetPosition, Time.deltaTime * openSpeed);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verificar si el jugador entr� en el �rea de la puerta
        if (collision.collider.CompareTag(playerTag))
        {
            playerNearby = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Verificar si el jugador sali� del �rea de la puerta
        if (collision.collider.CompareTag(playerTag))
        {
            playerNearby = false;
        }
    }
}

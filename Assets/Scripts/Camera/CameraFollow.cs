using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Referencia al jugador
    public Vector3 offset = new Vector3(0f, 2f, -2f); // Posición fija detrás del jugador
    public float rotationSpeed = 5f; // Velocidad de rotación de la cámara

    void LateUpdate()
    {
        // Posiciona la cámara exactamente detrás del jugador con el offset
        transform.position = target.position + target.TransformDirection(offset);

        // Hace que la cámara mire al jugador suavemente
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}

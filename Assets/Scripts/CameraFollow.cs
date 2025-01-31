using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Referencia al jugador
    public Vector3 offset; // Posición fija detrás del jugador
    public float rotationSpeed = 5f; // Velocidad de rotación de la cámara

    void Update() {
        offset = new Vector3(0f, 3f, -3f);
    }

    void LateUpdate()
    {
        transform.position = target.position + target.TransformDirection(offset);

        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}

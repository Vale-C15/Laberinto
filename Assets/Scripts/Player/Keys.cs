using UnityEngine;

public class Keys : MonoBehaviour
{
    public int keyCount = 0;
    public int requiredKeys = 5; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            keyCount++;
            Destroy(other.gameObject);

            print("Llaves recolectadas: " + keyCount);

            // Comprobamos si ya tiene todas las llaves
            if (keyCount >= requiredKeys)
            {
                print("�Has recolectado todas las llaves!");
                // Aqu� puedes agregar l�gica para abrir la salida o ganar el nivel
            }
        }
    }

    public int GetKeyCount()
    {
        return keyCount;
    }
}

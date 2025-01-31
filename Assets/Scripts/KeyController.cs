using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyController : MonoBehaviour
{
    public int keyCount = 0;
    public int requiredKeys = 5;
    public Image[] keyIcons = new Image[5]; // Array de imágenes de llaves en la UI
    public TextMeshProUGUI keysMessageText; //Texto UI

    private void Start()
    {
        UpdateKeyUI();

        // Desactivar todas las imágenes de las llaves al inicio
        foreach (var keyIcon in keyIcons)
        {
            keyIcon.enabled = false; 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            keyCount++;
            Destroy(other.gameObject);
            UpdateKeyUI();

            // Comprobamos si ya tiene todas las llaves
            if (keyCount >= requiredKeys)
            {
                keysMessageText.text = "¡Has recolectado todas las llaves! Presiona \"X\" para abrir la puerta";
            }
        }
    }

    void UpdateKeyUI()
    {
        for (int i = 0; i < keyIcons.Length; i++)
        {
            keyIcons[i].enabled = (i < keyCount); // Activa solo las imágenes de llaves recolectadas
        }
    }

    public int GetKeyCount()
    {
        return keyCount;
    }
}

using UnityEngine;

public class InstructionsUI : MonoBehaviour
{
    public GameObject instruccionesPanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            instruccionesPanel.SetActive(false);
        }
    }
}

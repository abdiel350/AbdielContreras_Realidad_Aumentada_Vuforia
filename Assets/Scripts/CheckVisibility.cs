using UnityEngine;

public class CheckVisibility : MonoBehaviour
{
    void OnEnable() {
        Debug.Log("¡EL SUELO SE HA ACTIVADO!");
    }
    void OnDisable() {
        Debug.Log("EL SUELO SE HA OCULTADO");
    }
}
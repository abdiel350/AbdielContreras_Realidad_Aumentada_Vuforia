using UnityEngine;
using UnityEngine.AI;

public class TouchNavigation : MonoBehaviour
{
    [Header("Configuración de AR")]
    public Camera arCamera;       
    public Transform targetPointer; 

    [Header("Personajes")]
    public NavMeshAgent[] agents;  

    void Update()
    {
        bool isPressed = false;
        Vector3 pos = Vector3.zero;

        // Detección de Input (PC y Móvil)
        #if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetMouseButtonDown(0))
        {
            isPressed = true;
            pos = Input.mousePosition;
        }
        #elif UNITY_IOS || UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                isPressed = true;
                pos = t.position;
            }
        }
        #endif

        if (isPressed)
        {
            Ray ray = arCamera.ScreenPointToRay(pos);
            RaycastHit hit;

            // Lanzamos el rayo para ver si toca el suelo
            if (Physics.Raycast(ray, out hit))
            {
                // 1. Mover el puntero visual al lugar del toque
                if (targetPointer != null)
                {
                    targetPointer.position = hit.point;
                }

                // 2. Avisar a todos los agentes que se muevan a ese punto
                foreach (var agent in agents)
                {
                    // Solo enviamos la orden si el personaje está activo en la escena
                    // (es decir, si Vuforia está detectando su marcador)
                    if (agent.gameObject.activeInHierarchy)
                    {
                        agent.SetDestination(hit.point);
                    }
                }
            }
        }
    }
}
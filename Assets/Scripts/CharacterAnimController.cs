using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class CharacterAnimController : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;

    void Start()
    {
        // Obtenemos las referencias automáticamente al empezar
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Obtenemos la velocidad actual del agente
        // .magnitude nos da un número (0 si está parado, >0 si se mueve)
        float speed = agent.velocity.magnitude;

        // Pasamos ese número al parámetro "Speed" que creamos en el Animator
        // Usamos un pequeño suavizado (0.1f) para que la transición sea fluida
        animator.SetFloat("Speed", speed, 0.1f, Time.deltaTime);
    }
}
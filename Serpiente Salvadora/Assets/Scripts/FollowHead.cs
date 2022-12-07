using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowHead : MonoBehaviour
{
    [SerializeField] private Transform _headObjetivo;
    [SerializeField] private NavMeshAgent _navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        // Siguientes 2 lineas son para ignorar las propiedades del rotacion del NavMesh que para empezar está en -90 y podría desaparecer nuestro objeto 
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        _navMeshAgent.SetDestination(_headObjetivo.position);
    }

    // Despues tengo que agregar el componente NavMesh Agent al enemigo que va a seguir a la serpiente 
}

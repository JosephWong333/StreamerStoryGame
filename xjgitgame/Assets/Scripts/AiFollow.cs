using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiFollow : MonoBehaviour
{
    [SerializeField]
    NavMeshAgent nma;

    [SerializeField]
    Transform target;

    public bool canGo = false;

    // Start is called before the first frame update
    void Start()
    {
        nma = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canGo)
            nma.SetDestination(target.position);
    }
}

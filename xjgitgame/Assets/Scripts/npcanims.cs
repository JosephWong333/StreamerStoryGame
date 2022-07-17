using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class npcanims : MonoBehaviour
{
    [SerializeField]
    NavMeshAgent nma;

    [SerializeField]
    Transform target;

    [SerializeField]
    Animator anim;

    [SerializeField]
    string trigger2;

    bool canMove = true;

    [SerializeField]
    float closeamount = 1f;

    // Start is called before the first frame update
    void Start()
    {
        nma = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            nma.SetDestination(target.position);
            if (Vector3.Distance(transform.position, target.position) < closeamount)
            {
                canMove = false;
                anim.SetTrigger(trigger2);
            }

        }
           
    }

}

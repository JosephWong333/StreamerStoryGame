using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2END : MonoBehaviour
{
    [SerializeField]
    private S2TIME s2time;


    //public void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        Debug.Log("HIT PLAYER WIN");
    //        s2time.ForceEnd();
    //    }
    //}

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.CompareTag("Player"))
        {
            Debug.Log("HIT PLAYER WIN");
            s2time.ForceEnd();
        }
    }
}

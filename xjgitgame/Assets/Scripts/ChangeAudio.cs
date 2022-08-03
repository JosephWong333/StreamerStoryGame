using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAudio : MonoBehaviour
{
    // Trigger-based
    [Header("Audio Data")]
    [SerializeField] private GameObject Audio1;
    [SerializeField] private GameObject Audio2;
    [Header("IF Data")]
    [SerializeField] private bool destroySelf = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Audio1.activeInHierarchy == true)
            {
                Audio1.SetActive(false);
                Audio2.SetActive(true);
                if (destroySelf) { Destroy(gameObject); }
            }
            else
            {
                Audio1.SetActive(true);
                Audio2.SetActive(false);
                if (destroySelf) { Destroy(gameObject); }
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnDeact : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;

    // Update is called once per frame
    void Update()
    {
        // to skip video
        if (Input.GetKeyDown(KeyCode.Return)) {
            obj.SetActive(false);
        }
    }

}

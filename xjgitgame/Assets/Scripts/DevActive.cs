using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevActive : MonoBehaviour
{

    [SerializeField]
    GameObject obj;

    [SerializeField]
    bool isActive = false;

    [SerializeField]
    bool useEsc = false;

    public void actor()
    {
        obj.SetActive(isActive);
    }

    public void actorLock()
    {
        Cursor.lockState = CursorLockMode.Locked;
        obj.SetActive(isActive);
    }


    public void Update()
    {
        if (useEsc)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.lockState = CursorLockMode.None;
                obj.SetActive(isActive);
            }
        }
    }


}

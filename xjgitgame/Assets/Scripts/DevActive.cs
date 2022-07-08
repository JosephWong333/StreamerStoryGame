using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevActive : MonoBehaviour
{

    [SerializeField]
    GameObject obj;

    [SerializeField]
    bool isActive = false;

    public void actor()
    {
        obj.SetActive(isActive);
    }


}

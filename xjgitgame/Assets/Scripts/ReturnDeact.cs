using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnDeact : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;

    [Header("DeAct2")]
    [SerializeField]
    private GameObject obj2;
    // Update is called once per frame
    //void Update()
    //{
    //    // to skip video
    //    //if (Input.GetKeyDown(KeyCode.Return)) {
    //    //    obj.SetActive(false);
    //    //}
    //}

    public void Start()
    {
        
    }

    public void DeAct()
    {
        obj.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void DeAct2()
    {
        obj.SetActive(false);
        obj2.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }

}

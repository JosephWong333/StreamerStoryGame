using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

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

    [Header("DeAct3")]
    [SerializeField]
    private bool isDeAct3 = false;
    [SerializeField]
    private GameObject SleepingMamo;
    [SerializeField]
    private GameObject RunningMamo;
    [SerializeField]
    private Volume volume;
    //[SerializeField]
    private ChromaticAberration chromaticAbberation;

    [Header("DeActS2")]
    [SerializeField]
    private S2TIME s2time;
    [SerializeField]
    private npcanims[] NPCs;
    [SerializeField]
    private AiFollow copCar;

    public void Awake()
    {
        if (isDeAct3)
            volume.profile.TryGet<ChromaticAberration>(out chromaticAbberation);
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

    public void DeAct3() //starting mamo scene
    {
        obj.SetActive(false);
        obj2.SetActive(true); // enabling new music
        Cursor.lockState = CursorLockMode.Locked;
        // enable mamo stuff N
        SleepingMamo.SetActive(false);
        RunningMamo.SetActive(true);
        chromaticAbberation.intensity.value = 1;
    }

    public void NewScene(int index) //Restart
    {
        SceneManager.LoadScene(index);
    }

    public void DeActS2()
    {
        obj.SetActive(false);
        obj2.SetActive(true);
        s2time.StartTimerBack();

        Cursor.lockState = CursorLockMode.Locked;

        foreach (npcanims npc in NPCs) {
            npc.canMove = true;
        }

        copCar.canGo = true;
    }

}

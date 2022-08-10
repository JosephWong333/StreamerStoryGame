using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class S2TIME : MonoBehaviour
{
    [SerializeField]
    private TMP_Text TimerText;

    public int timeLeft = 100;
    public bool working = true;

    [Header("objects")]

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject[] LoseObjects;

    [SerializeField]
    private GameObject vidLOSE;

    [SerializeField]
    private GameObject vidWIN;


    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    // Start is called before the first frame update
    IEnumerator Timing()
    {
        while (timeLeft > 0 && working == true)
        {
            yield return new WaitForSeconds(1f);
            if (working == true)
                timeLeft -= 1;
        }
        // When done
        End();
    }

    public void StopTimer()
    {
        working = false;
    }

    public void StartTimerBack()
    {
        working = true;
        StartCoroutine(Timing());
    }

    // Update is called once per frame
    public void End()
    {
        //safeguard
        if (working == false) { return; }

        //lose?
        if (timeLeft == 0 && working == true) {

            player.GetComponent<MotionCar>().enabled = false;
            // wowzers
            foreach (GameObject x in LoseObjects)
            {
                x.SetActive(false);
            }
            vidLOSE.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            return;
        }

        working = false;
        Debug.Log("DONENENEN111");
    }

    public void ForceEnd()
    {
        player.GetComponent<MotionCar>().enabled = false;
            // wowzers
        foreach (GameObject x in LoseObjects)
        {
            x.SetActive(false);
        }
        vidWIN.SetActive(true);
        Cursor.lockState = CursorLockMode.None;

        working = false;
        Debug.Log("DONE@2222");
        gameObject.SetActive(false);
    }

    public void Update()
    {
        TimerText.text = "TIME LEFT: " + timeLeft;
    }

}

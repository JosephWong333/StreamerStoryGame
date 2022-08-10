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

        working = false;
        Debug.Log("DONENENEN111");
    }

    public void Update()
    {
        TimerText.text = "TIME LEFT: " + timeLeft;
    }

}

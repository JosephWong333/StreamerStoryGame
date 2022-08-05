using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S1Ray : MonoBehaviour
{

    [SerializeField] private LayerMask targetLayerMask;
    [SerializeField] private LayerMask target1;
    [SerializeField] private LayerMask target2;
    [SerializeField] private float Distance = 5f;

    [Header("Do Data")]
    [SerializeField] private Image PickUpimage;
    //[SerializeField] private Image Holdimage;
    //[SerializeField] private GameObject NewMusic;
    [SerializeField] private GameObject Music1;
    //[SerializeField] private GameObject Music2;
    [SerializeField] private VideoSystem StartVideo;
    //[SerializeField] private VideoSystem EndVideo1;  // LOSE 
    //[SerializeField] private VideoSystem EndVideo2;  // WIN will need to do a next scene button


    private void Start()
    {
        // by default music 1 and 2 are both disabled
        // wait a second for level loader fade transition
        // video
        StartCoroutine(timer1(1));
    }

    IEnumerator timer1(float time)
    {
        yield return new WaitForSeconds(time);
        StartVideo.Shoot();
        Cursor.lockState = CursorLockMode.None;
        //Music1.SetActive(true); //dothis in possible close button
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit HitInfo;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out HitInfo, Distance, targetLayerMask))
        {
            PickUpimage.gameObject.SetActive(true);

            if (Input.GetMouseButtonDown(0) && (targetLayerMask == target1))
            {
                HitInfo.transform.gameObject.SetActive(false);
                print("DONE");
                // set off video
                // then Hold Image shows
                // chromattic abberation
                // new action music
                // mamo runs at you (has screaming audiosource)
            }

            if (Input.GetMouseButtonDown(0) && (targetLayerMask == target2))
            {
                print("DONE");
                // disable mamo
                // disable music
                // start already preprepared video
            }

        }
        else
        {
            PickUpimage.gameObject.SetActive(false);
        }
    }
}

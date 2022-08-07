using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S1Ray : MonoBehaviour
{

    [SerializeField] private LayerMask targetLayerMask;
    [SerializeField] private string target1;
    [SerializeField] private string target2;
    [SerializeField] private float Distance = 5f;

    [Header("Do Data")]
    [SerializeField] private Image PickUpimage;
    [SerializeField] private Image UseKeyimage;
    [SerializeField] private Image NeedsKeyimage;

    //[SerializeField] private Image Holdimage;
    //[SerializeField] private GameObject NewMusic;
    [SerializeField] private GameObject Music1;
    [SerializeField] private GameObject Music2;
    [SerializeField] private GameObject dramaMusic;
    [SerializeField] private VideoSystem StartVideo;
    [SerializeField] private GameObject MamoVideo1;
    //[SerializeField] private VideoSystem MamoEndVideoLose;  // in mamo script
    [SerializeField] private GameObject MamoEndVideoWin;  // WIN will need to do a next scene button
    [SerializeField] private GameObject Mamo;

    bool part1 = false;

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
        PickUpimage.gameObject.SetActive(false);
        UseKeyimage.gameObject.SetActive(false);
        NeedsKeyimage.gameObject.SetActive(false);

        RaycastHit HitInfo;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out HitInfo, Distance, targetLayerMask))
        {
            print("H: " + HitInfo.transform.gameObject.layer);
            print("V1: " + target1);
            print("V2: " + target2);

            if (HitInfo.transform.gameObject.CompareTag(target1))
            {
                PickUpimage.gameObject.SetActive(true);
            }
            else
            {
                PickUpimage.gameObject.SetActive(false);
            }
                
            if (HitInfo.transform.gameObject.CompareTag(target2) && part1 == false)
            {
                Debug.Log("HI CAR before cutscene");
                NeedsKeyimage.gameObject.SetActive(true);
            }
            else
            {
                NeedsKeyimage.gameObject.SetActive(false);
            }

            if (HitInfo.transform.gameObject.CompareTag(target2) && part1 == true)
            {
                UseKeyimage.gameObject.SetActive(true);
            }
            else
            {
                UseKeyimage.gameObject.SetActive(false);
            }
                

            if (Input.GetMouseButtonDown(0) && part1 == false && HitInfo.transform.gameObject.CompareTag(target1)) //key
            {
                Music1.SetActive(false);
                Music2.SetActive(false);
                MamoVideo1.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                HitInfo.transform.gameObject.SetActive(false);
                print("DONE");
                part1 = true;
                // In button script custom method: do under
                // set off video
                // then Hold Image shows
                // chromattic abberation
                // new action music
                // mamo runs at you (has screaming audiosource)
            }

            if (Input.GetMouseButtonDown(0) && part1 == true && HitInfo.transform.gameObject.CompareTag(target2)) //car
            {
                print("DONE");

                // disable mamo
                // disable music
                Mamo.SetActive(false);
                dramaMusic.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                MamoEndVideoWin.SetActive(true);
                // start already preprepared video
            }
        }
    }
}

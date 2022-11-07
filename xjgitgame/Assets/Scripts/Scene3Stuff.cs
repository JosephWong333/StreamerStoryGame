using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scene3Stuff : MonoBehaviour
{
    [SerializeField]
    private GameObject itself;
    [SerializeField]
    private GameObject music;

    // RPS game
    [SerializeField]
    private TMP_Text RoundNumber;

    [SerializeField]
    private TMP_Text PlayerWins;

    [SerializeField]
    private TMP_Text BotWins;

    [SerializeField]
    private int player;
    // 0: none
    // 1: rock
    // 2: paper
    // 3: scissors

    

    void Start()
    {
        print("STARTED");
    }

    public void RockClicked()
    {
        player = 1;
    }
    public void PaperClicked()
    {
        player = 2;
    }
    public void ScissorsClicked()
    {
        player = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeActS3()
    {
        itself.SetActive(false);
        music.SetActive(true);
        //Cursor.lockState = CursorLockMode.Locked;
    }
}

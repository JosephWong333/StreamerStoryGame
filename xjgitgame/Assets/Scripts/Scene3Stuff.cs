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

    public int playerWins = 0;
    public int botWins = 0;

    [SerializeField]
    private int player;
    // 0: none
    // 1: rock
    // 2: paper
    // 3: scissors

    [SerializeField]
    private int bot;
    // 0: none
    // 1: rock
    // 2: paper
    // 3: scissors

    [SerializeField]
    Image Playerimage;

    [SerializeField]
    Image Botimage;

    [SerializeField]
    Sprite rocksprite;
    [SerializeField]
    Sprite papersprite;
    [SerializeField]
    Sprite scissorssprite;

    [SerializeField]
    AudioSource victmusic;
    [SerializeField]
    AudioSource lossmusic;
    [SerializeField]
    AudioSource TiedMusic;

    [SerializeField]
    GameObject lossSign;

    [SerializeField]
    GameObject winSign;

    public int round;


    void Start()
    {
        print("STARTED");
    }

    public void RockClicked()
    {
        if (round >= 11)
        {
            return;
        }
        round += 1;
        player = 1;
        Playerimage.sprite = rocksprite;
        GamePlay();
    }
    public void PaperClicked()
    {
        if (round >= 11)
        {
            return;
        }
        round += 1;
        player = 2;
        Playerimage.sprite = papersprite;
        GamePlay();
    }
    public void ScissorsClicked()
    {
        if (round >= 11)
        {
            return;
        }
        round += 1;
        player = 3;
        Playerimage.sprite = scissorssprite;
        GamePlay();
    }

    public void GamePlay()
    {
        bot = Random.Range(1, 3);
        if (bot == 1)
        {
            Botimage.sprite = rocksprite;
        }
        else if (bot == 2)
        {
            Botimage.sprite = papersprite;
        }
        else if (bot == 3)
        {
            Botimage.sprite = scissorssprite;
        }

        if (player == bot)
        {
            //tie
            print("local tie");
            TiedMusic.Play();
        }
        else if ((player == 1 && bot == 3) || (player == 2 && bot == 1) || (player == 3 && bot == 2))
        {
            //win
            print("local win");
            playerWins += 1;
            victmusic.Play();
        }
        else
        {
            //loss
            print("local loss");
            botWins += 1;
            lossmusic.Play();
        }

        if (round >= 11)
        {
            StartCoroutine(End());
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        RoundNumber.text = "Round: " + round;
        PlayerWins.text = playerWins.ToString();
        BotWins.text = botWins.ToString();

    }

    public void DeActS3()
    {
        itself.SetActive(false);
        music.SetActive(true);
        //Cursor.lockState = CursorLockMode.Locked;
    }

    IEnumerator End()
    {
        yield return new WaitForSeconds(3);
        if (round >= 11)
        {
            if (playerWins == botWins)
            {
                // final tie
                print("final tie");
                lossSign.SetActive(true);
                music.SetActive(false);
                victmusic.Stop();
                lossmusic.Stop();
                TiedMusic.Stop();
            }
            else if (playerWins > botWins)
            {
                // final win
                print("final win");
                winSign.SetActive(true);
                music.SetActive(false);
                victmusic.Stop();
                lossmusic.Stop();
                TiedMusic.Stop();

            }
            else
            {
                // final loss
                print("final loss");
                lossSign.SetActive(true);
                music.SetActive(false);
                victmusic.Stop();
                lossmusic.Stop();
                TiedMusic.Stop();

            }
        }
    }
}

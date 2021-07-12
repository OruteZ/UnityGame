using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int PlayerHP = 5;
    public int stageIndex;
    public GameObject[] Stages;
    public PlayerMove player;
    public Image[] UIHP;

    public void NextStage()
    {
        if (stageIndex < Stages.Length-1)
        {
            Stages[stageIndex++].SetActive(false);
            Stages[stageIndex].SetActive(true);
            playerReposition();
        }
        else
        {
            Debug.Log("게임 클리어");
            SceneManager.LoadScene("MainMenu");
        }
    }

    void playerReposition()
    {
        player.transform.position = new Vector3(-1, 6, 1);
    }
    // Start is called before the first frame update
    void Start()
    {
        stageIndex = 0;

    }

    // Update is called once per frame
    void Update()
    {
  
    }

    public void Damaged()
    {
        PlayerHP--;
        UIHP[PlayerHP].color = new Color(1, 0, 0, 0.4f);
        if (PlayerHP <= 0) GameOver();
    }

    void GameOver()
    {
        Debug.Log("게임 오버");
        SceneManager.LoadScene("MainMenu");
    }
}

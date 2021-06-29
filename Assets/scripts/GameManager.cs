using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int stageIndex;
    public GameObject[] Stages;
    public PlayerMove player;
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
}

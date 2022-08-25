using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    [Header("�v���C���[")]
    [SerializeField]
    GameObject Player;

    [Header("GameClear���")]
    [SerializeField]
    GameObject Canvas_Clear;

    [Header("GameOver���")]
    [SerializeField]
    GameObject Canvas_OUT;

    [Header("GameOver")]
    [SerializeField]
    public bool GameOver;

    void Start()
    {
        Canvas_Clear.SetActive(false);
        Canvas_OUT.SetActive(false);
    }

    void Update()
    {
        if(GameOver == true)
        {
            if (Player.GetComponent<PlayerManager>().Score == 10)
            {
                Player.GetComponent<PlayerManager>().Player_Clear = true;

                Canvas_Clear.SetActive(true);
                Canvas_OUT.SetActive(false);
            }
            else
            {
                Player.GetComponent<PlayerManager>().Player_Deth = true;

                Canvas_Clear.SetActive(false);
                Canvas_OUT.SetActive(true);

            }
        }
    }
    public void SceneChange()
    {
        SceneManager.LoadScene("Title");
    }
}

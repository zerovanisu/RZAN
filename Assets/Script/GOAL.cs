using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOAL : MonoBehaviour
{
    [Header("����鑬�x")]
    [SerializeField]
    float Speed;

    [Header("�~�܂�")]
    [SerializeField]
    bool Stop;

    [Header("�v���C���[")]
    [SerializeField]
    GameObject Player;

    [Header("�f�B���N�^�[")]
    [SerializeField]
    GameObject Director;

    private void Start()
    {
        Stop = false;
        Player = GameObject.Find("Player");
        Director = GameObject.Find("GameDirector");
    }

    private void FixedUpdate()
    {
        if(Stop == false)
        {
            transform.Translate(-Speed, 0, 0);
        }

        if(this.transform.position.x <= Player.transform.position.x)
        {
            Stop = true;
            Director.GetComponent<GameDirector>().GameOver = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

        }
    }
}

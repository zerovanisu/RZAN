using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Tap_Controller : MonoBehaviour
{
    [SerializeField, Header("エフェクト")]
    GameObject Tap_Effect;

    ParticleSystem[] Effect_Children;

    [SerializeField, Header("カメラ")]
    private Camera Game_Camera;

    void Start()
    {
        Effect_Children = Tap_Effect.GetComponentsInChildren<ParticleSystem>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown((int)MouseButton.LeftMouse))
        {
            var pos = Input.mousePosition;
            pos.z = 10f;

            transform.position = Game_Camera.ScreenToWorldPoint(pos);

            for (int i = 0; i < Effect_Children.Length; i++)
            {
                Effect_Children[i].Play();
            }
        }
    }
}

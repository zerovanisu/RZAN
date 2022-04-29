using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap_Controller : MonoBehaviour
{
    [Header("エフェクト")]
    [SerializeField]
    private ParticleSystem Tap_Effect;

    [Header("カメラ")]
    [SerializeField]
    private Camera Game_Camera;

    void Start()
    {
        
    }

    void Update()
    {
        var pos = Input.mousePosition;
        pos.z = 10f[=]
    }
}

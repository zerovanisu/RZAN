using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap_Controller : MonoBehaviour
{
    [Header("�G�t�F�N�g")]
    [SerializeField]
    private ParticleSystem Tap_Effect;

    [Header("�J����")]
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

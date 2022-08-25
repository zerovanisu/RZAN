using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [Header("—¬‚ê‚é‘¬“x")]
    [SerializeField]
    float Speed;

    private void FixedUpdate()
    {
        transform.Translate(-Speed, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerManager>().AddScore();
            Destroy(this.gameObject);
        }
    }
}

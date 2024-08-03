using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketsScript : MonoBehaviour
{
    PlayerController pl;
    private void Start()
    {
        pl=GameObject.Find("Player").GetComponent<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cekirge"))
        {
            if (!pl.isbluebomb)
            {
                pl.Score++;
                Destroy(collision.gameObject);
            }
            else
            {
                pl.Score+=3;
                Destroy(collision.gameObject);
            }
        }
    }
}

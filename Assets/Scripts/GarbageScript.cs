using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GarbageScript : MonoBehaviour
{
    PlayerController pt;
    public int istila;
    private void Start()
    {
        pt = GameObject.Find("Player").GetComponent<PlayerController>();
        istila = 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Cekirge"))
        {
            istila++;
            Destroy(collision.gameObject);
            if (istila == 5)
            {
                PlayerPrefs.SetInt("Skor", pt.Score);
                PlayerPrefs.SetString("İstila", "Var");
                SceneManager.LoadScene(2);
            }
        }
        Destroy(collision.gameObject);
    }
}

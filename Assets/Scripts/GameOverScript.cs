using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    Text mevcut, enyuksek,gameover;
    RawImage rw;
    public Sprite cekirge, tarla;

    private void Awake()
    {
        mevcut = GameObject.Find("mevcutskor").GetComponent<Text>();
        enyuksek = GameObject.Find("enyuksekskor").GetComponent<Text>();
        rw = GameObject.Find("RawImage").GetComponent<RawImage>();
        gameover = GameObject.Find("gameover").GetComponent<Text>();
    }
    void Start()
    {
        if (PlayerPrefs.GetString("�stila") == "Var")
        {
            gameover.text = "Çekirgeler Tarlayı istila Etti!";
            rw.texture = cekirge.texture;
        }
        else
        {
            gameover.text = "Kırmızı Bomba sebebiyle emekliye eyrıldın.";
            rw.texture = tarla.texture;
        }
        PlayerPrefs.SetInt("P", 0);
        if (PlayerPrefs.GetInt("Skor") > PlayerPrefs.GetInt("EnY�ksekSkor", 0))
        {
            PlayerPrefs.SetInt("EnY�ksekSkor", PlayerPrefs.GetInt("Skor"));
            PlayerPrefs.Save();
        }
        yazdir();
    }

    void yazdir()
    {
        mevcut.text = "Skorunuz: " + PlayerPrefs.GetInt("Skor");
        enyuksek.text = "En Y�ksek Skor: " + PlayerPrefs.GetInt("EnY�ksekSkor");
    }
    public void resetle()
    {
        PlayerPrefs.SetInt("EnY�ksekSkor", PlayerPrefs.GetInt("Skor"));
        yazdir();
    }
}

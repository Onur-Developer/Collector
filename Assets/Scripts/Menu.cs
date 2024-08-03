using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    Image ým;
    Button play;
    Text playtx;
    private void Awake()
    {
        PlayerPrefs.SetInt("P", 1);
        ým = GetComponent<Image>();
        play =GetComponent<Button>();
        playtx = play.transform.GetChild(0).GetComponent<Text>();
    }
    private void Start()
    {
    }
    public void OnpoýnterEnter()
    {
        if (PlayerPrefs.GetInt("P") == 1)
        {
            ým.color = new Color(255, 255, 255, 255);
            playtx.fontSize = 40;
        }
        else
        {
            ým.color = new Color(255, 255, 255, 255);
            playtx.fontSize = 70;
        }
    }
    public void OnpoýnterExit()
    {
        if(PlayerPrefs.GetInt("P") == 1)
        {
            ým.color = new Color(255, 255, 255, 0);
            playtx.fontSize = 20;
        }
        else
        {
            ým.color = new Color(255, 255, 255, 0);
            playtx.fontSize = 50;
        }
    }
    public void basla()
    {
        SceneManager.LoadScene(1);
    }
    public void anamenu()
    {
        SceneManager.LoadScene(0);
    }
    public void cýkýs()
    {
        Application.Quit();
    }
}

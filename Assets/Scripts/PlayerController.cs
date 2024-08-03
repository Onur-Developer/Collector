using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    AudioSource au;
    Animator wallan, basketanim, basketanim2, cameraanim;
    public Rigidbody2D rgb;
    public float speed = 5f;
    public Text ScoreText;
    public int Score = 0, Can = 3;
    public GameObject gameoverpanel, wall, baskets,pausepanel;
    public Button yenıdenbasla, pausebuttonn,devambutton,yenıdenbaslabutton,anamenubutton,cıkısbutton,sesbutton;
    SpriteRenderer sp;
    public bool isgreenbomb, isyellowbomb, isbluebomb,soundbool;
    public float isgreenbombcooldown = 10, isyellowbombcooldown = 10;
    SpriteRenderer re;
    Image panelımage;
    public byte color = 0;
    public Sprite SesVar, SesYok;
    Image soundbuttonımage;
    void Start()
    {
        soundbuttonımage=GameObject.Find("SoundButton").GetComponent<Image>();
        sesbutton = GameObject.Find("SoundButton").GetComponent<Button>();
        au=GameObject.Find("Ses").GetComponent<AudioSource>();
        pausepanel = GameObject.Find("PausePanel2");
        devambutton=GameObject.Find("DevamButton").GetComponent<Button>();
        yenıdenbaslabutton=GameObject.Find("YenidenBaslaButton").GetComponent<Button>();
        anamenubutton = GameObject.Find("AnaMenuButton").GetComponent<Button>();
        cıkısbutton=GameObject.Find("CıkısButton").GetComponent<Button>();
        pausebuttonn = GameObject.Find("PauseButton").GetComponent<Button>();
        panelımage = GameObject.Find("PausePanel").GetComponent<Image>();
        cameraanim = GameObject.Find("Main Camera").GetComponent<Animator>();
        basketanim = GameObject.Find("Basket1").GetComponent<Animator>();
        basketanim2 = GameObject.Find("Basket2").GetComponent<Animator>();
        baskets = GameObject.Find("Baskets");
        wall = GameObject.Find("Wall");
        wallan = wall.GetComponent<Animator>();
        re = wall.GetComponent<SpriteRenderer>();
        Time.timeScale = 1;
        //  gameoverpanel = GameObject.Find("GameOverPanel");
        // yenıdenbasla = GameObject.Find("BastanBasla").GetComponent<Button>();
        pausebuttonn.interactable = true;
        sesbutton.onClick.AddListener(ses);
        pausebuttonn.onClick.AddListener(pausebutton);
        yenıdenbaslabutton.onClick.AddListener(yenıdenbaslaa);
        anamenubutton.onClick.AddListener(anamenu);
        cıkısbutton.onClick.AddListener(cıkıs);
        devambutton.onClick.AddListener(devam);
        // yenıdenbasla.onClick.AddListener(yenıdenbaslaa);
        baskets.SetActive(false);
        // gameoverpanel.SetActive(false);
        wall.SetActive(false);
        sp = GetComponent<SpriteRenderer>();
        rgb = GetComponent<Rigidbody2D>();
        ScoreText = GameObject.Find("Score").GetComponent<Text>();
    }

    void Update()
    {
        ScoreText.text = Score.ToString();
        rgb.velocity = Vector2.right * Input.GetAxisRaw("Horizontal") * speed;

        if (isgreenbomb)
        {
            isgreenbombcooldown -= Time.deltaTime;
            wallan.SetBool("WallAnim", true);
            if (isgreenbombcooldown < 0)
            {
                isgreenbomb = false;
                wall.SetActive(false);
                isgreenbombcooldown = 10;
            }
        }
        if (isyellowbomb)
        {
            isyellowbombcooldown -= Time.deltaTime;
            basketanim.SetBool("BasketsAnim", true);
            basketanim2.SetBool("BasketsAnim", true);
            if (isyellowbombcooldown < 0)
            {
                isyellowbomb = false;
                baskets.SetActive(false);
                isyellowbombcooldown = 10;
            }
        }
    }

    void ses()
    {
        if (!soundbool)
        {
            soundbuttonımage.sprite = SesYok;
            au.enabled = false;
            soundbool = true;
        }
        else
        {
            soundbuttonımage.sprite = SesVar;
            au.enabled = true;
            soundbool = false;
        }
    }
    void anamenu()
    {
        SceneManager.LoadScene(0);
    }
    void cıkıs()
    {
        Application.Quit();
    }
    void devam()
    {
        pausebuttonn.interactable = true;
        pausepanel.transform.localScale = Vector3.zero;
        panelımage.color = new Color32(0, 0, 0, 0);
        Time.timeScale = 1f;
        color = 0;

    }
    void panelanimation()
    {
        if (color >= 200)
        {
            CancelInvoke("panelanimation");
            Time.timeScale = 0;
        }
        else
        {
            if (color <= 80)
            {
                pausepanel.transform.localScale += new Vector3(0.1f, 0.1f);
            }
            color += 10;
            panelımage.color = new Color32(0, 0, 0, color);
        }
    }

    public void pausebutton()
    {
        pausebuttonn.interactable = false;
        InvokeRepeating("panelanimation", 0.03f, 0.03f);
    }
    void yenıdenbaslaa()
    {
        SceneManager.LoadScene("Oyun");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Cekirge"))
        {
            if (!isbluebomb)
            {
                Score++;
                Destroy(collision.gameObject);
            }
            else
            {
                Score += 3;
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.CompareTag("Bomba"))
        {
            Can--;
            Destroy(collision.gameObject);
            switch (Can)
            {
                case 0:
                    PlayerPrefs.SetInt("Skor", Score);
                    PlayerPrefs.SetString("İstila", "Yok");
                    SceneManager.LoadScene(2);
                    break;
                case 1:
                    sp.color = Color.red;
                    break;
                case 2:
                    sp.color = Color.yellow;
                    break;
                case 3:
                    sp.color = Color.white;
                    break;
            }
        }
        if (collision.gameObject.CompareTag("Bugday"))
        {
            if (Can >= 3)
            {
                if (!isbluebomb)
                {
                    Score++;
                    Destroy(collision.gameObject);
                }
                else
                {
                    Score += 3;
                    Destroy(collision.gameObject);
                }
            }
            else
            {
                Can++;
                Destroy(collision.gameObject);
                switch (Can)
                {
                    case 1:
                        sp.color = Color.red;
                        break;
                    case 2:
                        sp.color = Color.yellow;
                        break;
                    case 3:
                        sp.color = Color.white;
                        break;
                }
            }

        }
        if (collision.gameObject.CompareTag("GreenBomba"))
        {
            if (isgreenbomb)
            {
                isgreenbombcooldown = 10;
                wallan.Play("WallAnimation1", -1, 0f);
                Destroy(collision.gameObject);
            }
            else
            {
                isgreenbomb = true;
                wall.SetActive(true);
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.CompareTag("YellowBomba"))
        {
            if (isyellowbomb)
            {
                isyellowbombcooldown = 10;
                basketanim.Play("BasketAnim", -1, 0f);
                basketanim2.Play("BasketAnim", -1, 0f);
                Destroy(collision.gameObject);
            }
            else
            {
                isyellowbomb = true;
                baskets.SetActive(true);
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.CompareTag("BlueBomba"))
        {
            if (!isbluebomb)
            {
                isbluebomb = true;
                cameraanim.SetBool("isAnim", true);
                Destroy(collision.gameObject);
            }
            else
            {
                isbluebomb = false;
                cameraanim.SetBool("isAnim", false);
                Destroy(collision.gameObject);
            }
        }
    }
}

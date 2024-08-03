using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu2 : MonoBehaviour
{
    RectTransform rc;
    int i, control,control2;
    GameObject panel;
    Button forwardbutton,backbutton,nasýloynanýrbutton,ok;
    bool panelopen;
    private void Awake()
    {
        Time.timeScale = 1f;
        ok=GameObject.Find("Ok").GetComponent<Button>();
        nasýloynanýrbutton=GameObject.Find("HowToPlay").GetComponent<Button>();
        control = 0;
        control2 = 0;
        backbutton=GameObject.Find("BackButton").GetComponent<Button>();
        forwardbutton = GameObject.Find("ForwardButton").GetComponent<Button>();
        ok.onClick.AddListener(okk);
        nasýloynanýrbutton.onClick.AddListener(nasýloynanýr);
        backbutton.onClick.AddListener(back);
        forwardbutton.onClick.AddListener(forward);
        i = 0;
        panel = GameObject.Find("HowToPlayPanel");
    }
    void panelanimation()
    {
        panel.transform.GetChild(i).transform.localScale += new Vector3(0.1f, 0.1f);
        control++;
        if (control >= 8)
        {
            CancelInvoke("panelanimation");
            control = 0;
            backbutton.interactable = true;
            forwardbutton.interactable = true;
        }
    }
    void forward()
    {
        forwardbutton.interactable = false;
        panel.transform.GetChild(i).transform.localScale = new Vector3(0,0,1);
        i++;
        rc = panel.transform.GetChild(i).GetComponent<RectTransform>();
        rc.offsetMin = new Vector2(-46, -70);
        rc.offsetMax = new Vector2(-46, -70);
        rc.pivot = new Vector2(1, 1);
        if (i == 6)
        {
            forwardbutton.transform.localScale = new Vector2(0, 0);
        }
        else
        {
            forwardbutton.transform.localScale = new Vector2(1, 1);
            backbutton.transform.localScale = new Vector2(1, 1);
        }
        InvokeRepeating("panelanimation", 0.05f, 0.05f);
    }
    void back()
    {
        backbutton.interactable = false;
        panel.transform.GetChild(i).transform.localScale = new Vector3(0, 0, 1);
        i--;
        rc = panel.transform.GetChild(i).GetComponent<RectTransform>();
        rc.offsetMin=new Vector2(128,-70);
        rc.offsetMax=new Vector2(128,-70);
        rc.pivot = new Vector2(0.2f, 1);

        if (i == 0)
        {
            backbutton.transform.localScale = new Vector2(0, 0);
        }
        else
        {
            backbutton.transform.localScale = new Vector2(1, 1);
            forwardbutton.transform.localScale = new Vector2(1, 1);
        }
        InvokeRepeating("panelanimation", 0.05f, 0.05f);
    }

    void panelanimation2()
    {
        if (panelopen)
        {
            panel.transform.localScale += new Vector3(0.1f, 0.1f);
            control2++;
            if (control2 >= 10)
            {
                CancelInvoke("panelanimation2");
                control2 = 0;
                panelopen = false;
                panel.transform.localScale = new Vector3(1.05f, 1.05f);
            }
        }
        else
        {
            panel.transform.localScale -= new Vector3(0.1f, 0.1f);
            control2++;
            if (control2 >= 10)
            {
                CancelInvoke("panelanimation2");
                control2 = 0;
                panelopen = true;
                panel.transform.localScale = new Vector3(0, 0);
                panel.transform.GetChild(i).transform.localScale = new Vector3(0, 0);
            }
        }
    }

    void nasýloynanýr()
    {
        i = 0;
        backbutton.transform.localScale = new Vector2(0, 0);
        forwardbutton.transform.localScale = new Vector2(1, 1);
        InvokeRepeating("panelanimation2", 0.05f, 0.05f);
        panelopen= true;
        panel.transform.GetChild(0).transform.localScale=new Vector2(0.8f, 0.8f);
    }
    void okk()
    {
        InvokeRepeating("panelanimation2", 0.05f, 0.05f);
    }

}

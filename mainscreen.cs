using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainscreen : MonoBehaviour
{
    public TMP_Text uid;
    public TMP_Text time_;
    public TMP_Text quest_;
    private bool IsShowUI;
    private Touch tempTouchs; 
    private Vector3 touchedPos;
    public Image messbutton;
    public Sprite messbutton1;
    public Sprite messbutton2;
    private bool touchOn;
    private float runtime;
    private int touchsun;
    // Start is called before the first frame update
    void Awake()
    {

    }
    void Start()
    {
        SetResolution();
        touchsun = 0;
        quest_.text = "";
        IsShowUI = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(data.isnewmess == true)
        {
            messbutton.sprite = messbutton1;
        }
        else
        {
            messbutton.sprite = messbutton2;
        }
        time_.text = $"{string.Format("{0:00}",(int)(data.time/60))}:{string.Format("{0:00}",(int)(data.time%60))}";
        if(IsShowUI == true)
            uid.text = "uid: " + login.uid_pre;
        else
            uid.text = "";
        touchOn = false;
        if (Input.touchCount > 0) 
        {
            for (int i=0; i<Input.touchCount; i++) 
            {
                tempTouchs = Input.GetTouch (i);
                if (tempTouchs.phase == TouchPhase.Began) 
                {
                    touchedPos = Camera.main.ScreenToWorldPoint (tempTouchs.position);
                    if (touchedPos.x < -1.35 && touchedPos.x > -2.25 && touchedPos.y < -3.74 && touchedPos.y > -4.67)
                    {
                        SceneManager.LoadScene("call");
                    }
                    if (touchedPos.x < -0.17 && touchedPos.x > -1.07 && touchedPos.y < -3.74 && touchedPos.y > -4.67)
                    {
                        SceneManager.LoadScene("message");
                    }
                    if (touchedPos.x < 1.03 && touchedPos.x > 0.15 && touchedPos.y < -3.74 && touchedPos.y > -4.67)
                    {
                        SceneManager.LoadScene("search");
                    }
                    if (touchedPos.x < 2.22 && touchedPos.x > 1.33 && touchedPos.y < -3.74 && touchedPos.y > -4.67)
                    {
                        SceneManager.LoadScene("submit");
                    }
                    if (touchedPos.x < -1.4 && touchedPos.x > -2.05 && touchedPos.y < 2.90 && touchedPos.y > 2.27)
                    {
                        touchsun += 1;   
                    }
                }
            }
        }
        if(Array.IndexOf(data.quest, 0) == -1 && data.IsQuest == false)
        {
            quest_.text = "히든업적 : 진정한 탐구왕";
            data.IsQuest = true;
        }
        if(touchsun >= 10 && data.IsQuest2 == false)
        {
            quest_.text = "히든업적 : 이카로스";
            data.IsQuest2 = true;
        }
        if(data.hidden == true && data.IsQuest3 == false)
        {
            quest_.text = "재봉틀(축연타)";
            data.IsQuest3 = true;
        }
    }

    public void SetResolution()
    {
        int setWidth = 360; 
        int setHeight = 720;

        int deviceWidth = Screen.width; 
        int deviceHeight = Screen.height; 

        Screen.SetResolution(setWidth, (int)(((float)deviceHeight / deviceWidth) * setWidth), true); 

        if ((float)setWidth / setHeight < (float)deviceWidth / deviceHeight)
        {
            float newWidth = ((float)setWidth / setHeight) / ((float)deviceWidth / deviceHeight); 
            Camera.main.rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f); 
        }
        else 
        {
            float newHeight = ((float)deviceWidth / deviceHeight) / ((float)setWidth / setHeight);
            Camera.main.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight); 
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class message : MonoBehaviour
{
    public Image newimg1;
    public Image newimg2;
    public Image newimg3;
    public Image newimg4;
    public TMP_Text get;
    private bool IsChoose;
    private Touch tempTouchs; 
    public Image messimg; 
    public Sprite messimg0; 
    public Sprite messimg1; 
    public Sprite messimg2; 
    public Sprite messimg3; 
    public Sprite messimg4; 
    private Vector3 touchedPos;
    private bool touchOn; 
    public Image choose;  
    private int messnum;

    public Sprite choose_image1;  
    public Sprite choose_image2;
    int match;

    void Start()
    {
        SetResolution();
        messnum = 0;
        get.text = "";
        IsChoose = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(match);
        touchOn = false;
        if (Input.touchCount > 0) 
        {
            for (int i=0; i<Input.touchCount; i++) 
            {
                tempTouchs = Input.GetTouch (i);
                if (tempTouchs.phase == TouchPhase.Began) 
                {
                    touchedPos = Camera.main.ScreenToWorldPoint (tempTouchs.position);
                    if (touchedPos.x < -2.00 && touchedPos.x > -2.50 && touchedPos.y < 0 && touchedPos.y > -1 && IsChoose == false)
                    {
                        get.text = "";
                        choose.rectTransform.anchoredPosition = new Vector3(-182.5f, -42, 0);
                        choose.sprite = choose_image2;
                        IsChoose = true;
                    }
                    else if (touchedPos.x < 1.22 && touchedPos.x > 0.97 && touchedPos.y < 0 && touchedPos.y > -1 && IsChoose == true)
                    {
                        get.text = "";
                        choose.rectTransform.anchoredPosition = new Vector3(-430f, -42, 0);
                        choose.sprite = choose_image1;
                        IsChoose = false;
                    }
                    else if (touchedPos.x < 2.50 && touchedPos.x > 2.16 && touchedPos.y < 5.00 && touchedPos.y > 4.60 && IsChoose == false)
                    {
                        SceneManager.LoadScene("main");
                    }
                    else if (touchedPos.x < 0.35 && touchedPos.x > -2.50 && touchedPos.y < 4.40 && touchedPos.y > 3.45 && IsChoose == true)
                    {
                        data.newmess1 = false;
                        data.isnewmess = false;
                        if(data.Ismess1 == true)
                        {
                            messnum = 1;
                        }
                        get.text = "";
                        choose.rectTransform.anchoredPosition = new Vector3(-430f, -42, 0);
                        choose.sprite = choose_image1;
                        IsChoose = false;
                    }
                    else if (touchedPos.x < 0.35 && touchedPos.x > -2.50 && touchedPos.y < 3.45 && touchedPos.y > 2.50 && IsChoose == true)
                    {
                        data.newmess2 = false;
                        data.isnewmess = false;
                        if(data.Ismess2 == true)
                        {
                            messnum = 2;
                        }
                        get.text = "";
                        choose.rectTransform.anchoredPosition = new Vector3(-430f, -42, 0);
                        choose.sprite = choose_image1;
                        IsChoose = false;
                    }
                    else if (touchedPos.x < 0.35 && touchedPos.x > -2.50 && touchedPos.y < 2.50 && touchedPos.y > 1.55 && IsChoose == true)
                    {
                        data.newmess3 = false;
                        data.isnewmess = false;
                        if(data.Ismess3 == true)
                        {
                            messnum = 3;
                        }
                        get.text = "";
                        choose.rectTransform.anchoredPosition = new Vector3(-430f, -42, 0);
                        choose.sprite = choose_image1;
                        IsChoose = false;
                    }
                    else if (touchedPos.x < 0.35 && touchedPos.x > -2.50 && touchedPos.y < 1.55 && touchedPos.y > 0.60 && IsChoose == true)
                    {
                        data.newmess4 = false;
                        data.isnewmess = false;
                        if(data.Ismess4 == true)
                        {
                            messnum = 4;
                        }
                        get.text = "";
                        choose.rectTransform.anchoredPosition = new Vector3(-430f, -42, 0);
                        choose.sprite = choose_image1;
                        IsChoose = false;
                    }               
                }
            }
        }
        if(messnum == 0)
        {
            messimg.sprite = messimg0;
        }
        if(messnum == 1)
        {
            if(data.IsFLAT == false)
            {
                get.text = "Flatten 블록을 획득하였습니다!!!";
                data.IsFLAT = true;
            }
            messimg.sprite = messimg1;
        }
        if(messnum == 2)
        {
            messimg.sprite = messimg2;
        }
        if(messnum == 3)
        {
            messimg.sprite = messimg3;
        }
        if(messnum == 4)
        {
            if(data.IsFCON == false)
            {
                get.text = "Fully Connected 블록을 획득하였습니다!!!";
                data.IsFCON = true;
            }
            messimg.sprite = messimg4;
        }
        if(data.newmess1 == true && IsChoose == true)
        {
            newimg1.rectTransform.anchoredPosition = new Vector3(-240, 295, 0);
        }
        else
        {
            newimg1.rectTransform.anchoredPosition = new Vector3(-490, 295, 0);
        }
        if(data.newmess2 == true && IsChoose == true)
        {
            newimg2.rectTransform.anchoredPosition = new Vector3(-240, 226, 0);
        }
        else
        {
            newimg2.rectTransform.anchoredPosition = new Vector3(-490, 226, 0);
        }
        if(data.newmess3 == true && IsChoose == true)
        {
            newimg3.rectTransform.anchoredPosition = new Vector3(-240, 160, 0);
        }
        else
        {
           newimg3.rectTransform.anchoredPosition = new Vector3(-490, 160, 0);
        }
        if(data.newmess4 == true && IsChoose == true)
        {
            newimg4.rectTransform.anchoredPosition = new Vector3(-240, 95, 0);
        }
        else
        {
            newimg4.rectTransform.anchoredPosition = new Vector3(-490, 95, 0);
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

using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class submit : MonoBehaviour
{
    public TMP_Text timer;
    public TMP_Text ans;
    public Canvas canvas;
    public Image obj1; 
    public Image obj2; 
    public Image obj3; 
    public Image obj4; 
    public Image obj5; 
    public Image obj6;
    public Image obj1_; 
    public Image obj2_; 
    public Image obj3_; 
    public Image obj4_; 
    public Image obj5_; 
    public Image obj6_; 
    private Touch tempTouchs; 
    private Vector3 touchedPos;
    private bool touchOn;
    private int subnum;
    private int[] subnumlist = new int[13];
    private int[] checklist = new int[13];
    int match;


    // Start is called before the first frame update
    void Start()
    {
        SetResolution();
        ans.text = "";
        checklist = new int[] {0, 1, 2, 3, 1, 2, 3, 4, 5, 6, 0, 0, 1};
        subnumlist = new int[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1};
        subnum = 0;
        if(data.IsCONV == true)
        {
            Color color = obj1_.color;
            color.a = 0f;
            obj1_.color = color;
        }
        if(data.IsRELU == true)
        {
            Color color = obj2_.color;
            color.a = 0f;
            obj2_.color = color;
        }
        if(data.IsPOOL == true)
        {
            Color color = obj3_.color;
            color.a = 0f;
            obj3_.color = color;
        }
        if(data.IsFLAT == true)
        {
            Color color = obj4_.color;
            color.a = 0f;
            obj4_.color = color;
        }
        if(data.IsFCON == true)
        {
            Color color = obj5_.color;
            color.a = 0f;
            obj5_.color = color;
        }
        if(data.IsSOFT == true)
        {
            Color color = obj6_.color;
            color.a = 0f;
            obj6_.color = color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer.text = $"{string.Format("{0:00}",(int)(data.time/60))}:{string.Format("{0:00}",(int)(data.time%60))}";
        touchOn = false;
        if (Input.touchCount > 0) 
        {
            for (int i=0; i<Input.touchCount; i++) 
            {
                tempTouchs = Input.GetTouch(i);
                if (tempTouchs.phase == TouchPhase.Began) 
                {
                    touchedPos = Camera.main.ScreenToWorldPoint (tempTouchs.position);
                    touchOn = true; 
                    if (touchedPos.x < -1.78 && touchedPos.x > -2.42 && touchedPos.y < -2.42 && touchedPos.y > -4.06 && subnum < 11 && data.IsCONV == true)
                    {
                        Image obj = Instantiate(obj1);
                        obj.transform.SetParent(canvas.transform, false);
                        obj.rectTransform.anchoredPosition = new Vector3 (-180, 245 - (subnum * 40), 0);
                        subnum += 1;
                        subnumlist[subnum] = 1;
                    }
                    if (touchedPos.x < -0.94 && touchedPos.x > -1.61 && touchedPos.y < -2.42 && touchedPos.y > -4.06 && subnum < 11 && data.IsRELU == true)
                    {
                        Image obj = Instantiate(obj2);
                        obj.transform.SetParent(canvas.transform, false);
                        obj.rectTransform.anchoredPosition = new Vector3 (-180, 245 - (subnum * 40), 0);
                        subnum += 1;
                        subnumlist[subnum] = 2;
                    }
                    if (touchedPos.x < -0.10 && touchedPos.x > -0.75 && touchedPos.y < -2.42 && touchedPos.y > -4.06 && subnum < 11 && data.IsPOOL == true)
                    {
                        Image obj = Instantiate(obj3);
                        obj.transform.SetParent(canvas.transform, false);
                        obj.rectTransform.anchoredPosition = new Vector3 (-180, 245 - (subnum * 40), 0);
                        subnum += 1;
                        subnumlist[subnum] = 3;
                    }
                    if (touchedPos.x < 0.74 && touchedPos.x > 0.11 && touchedPos.y < -2.42 && touchedPos.y > -4.06 && subnum < 11 && data.IsFLAT == true)
                    {
                        Image obj = Instantiate(obj4);
                        obj.transform.SetParent(canvas.transform, false);
                        obj.rectTransform.anchoredPosition = new Vector3 (-180, 245 - (subnum * 40), 0);
                        subnum += 1;
                        subnumlist[subnum] = 4;
                    }
                    if (touchedPos.x < 1.56 && touchedPos.x > 0.93 && touchedPos.y < -2.42 && touchedPos.y > -4.06 && subnum < 11 && data.IsFCON == true)
                    {
                        Image obj = Instantiate(obj5);
                        obj.transform.SetParent(canvas.transform, false);
                        obj.rectTransform.anchoredPosition = new Vector3 (-180, 245 - (subnum * 40), 0);
                        subnum += 1;
                        subnumlist[subnum] = 5;
                    }
                    if (touchedPos.x < 2.44 && touchedPos.x > 1.78 && touchedPos.y < -2.42 && touchedPos.y > -4.06 && subnum < 11 && data.IsSOFT == true)
                    {
                        Image obj = Instantiate(obj6);
                        obj.transform.SetParent(canvas.transform, false);
                        obj.rectTransform.anchoredPosition = new Vector3 (-180, 245 - (subnum * 40), 0);
                        subnum += 1;
                        subnumlist[subnum] = 6;
                    }
                    if (touchedPos.x < 2.50 && touchedPos.x > 2.16 && touchedPos.y < 5.00 && touchedPos.y > 4.60)
                    {
                        SceneManager.LoadScene("main");
                    }
                    if (touchedPos.x < 1.80 && touchedPos.x > -1.80 && touchedPos.y < -4.24 && touchedPos.y > -4.76)
                    {
                        if(subnumlist.SequenceEqual(checklist))
                        {
                            SceneManager.LoadScene("ending");
                        }
                        else
                        {
                            ans.text = "틀렸습니다(앱 종료 후 다시 키면 초기화)";
                        }
                    }
                }
            }
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

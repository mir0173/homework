using UnityEngine;
using UnityEngine.SceneManagement;

public class call : MonoBehaviour
{
    private Touch tempTouchs; 
    private Vector3 touchedPos;
    private bool touchOn;
    public static int call_num;

    // Start is called before the first frame update
    void Start()
    {
        SetResolution();
    }

    // Update is called once per frame
    void Update()
    {
        touchOn = false;
        if (Input.touchCount > 0) 
        {
            for (int i=0; i<Input.touchCount; i++) 
            {
                tempTouchs = Input.GetTouch (i);
                if (tempTouchs.phase == TouchPhase.Began) 
                {
                    touchedPos = Camera.main.ScreenToWorldPoint (tempTouchs.position);
                    if (touchedPos.x < 2.36 && touchedPos.x > 2.14 && touchedPos.y < 4.87 && touchedPos.y > 4.65)
                    {
                        SceneManager.LoadScene("main");
                    }
                    for(int j = 0; j < 10; j++)
                    {
                        if (touchedPos.x < 0 && touchedPos.x > -2.5 && touchedPos.y < 1.38 - j * 0.64 && touchedPos.y > 1.38 - (j + 1) * 0.64)
                        {
                            call_num = j;
                            SceneManager.LoadScene("calling");
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

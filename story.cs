using UnityEngine;
using UnityEngine.SceneManagement;

public class story : MonoBehaviour
{
    public GameObject room;
    public GameObject room2;
    public GameObject classroom;
    public GameObject date;
    public GameObject black1;
    public GameObject black2;
    public GameObject hand;
    public GameObject text1;
    public GameObject text2;
    public GameObject black;
    public float time;
    public int key;
    private Touch tempTouchs; 
    private Vector3 touchedPos;
    private bool touchOn;
    // Start is called before the first frame update

    void Awake()
    {
        
    }

    void Start()
    {
        SetResolution();
        time = 0;
        key = -1;
        Color color = room2.GetComponentInChildren<SpriteRenderer>().material.color;
        color.a = 1f;
        room2.GetComponentInChildren<SpriteRenderer>().material.color = color;
        Color color1 = classroom.GetComponentInChildren<SpriteRenderer>().material.color;
        color1.a = 0f;
        classroom.GetComponentInChildren<SpriteRenderer>().material.color = color1;
        Color color2 = date.GetComponentInChildren<SpriteRenderer>().material.color;
        color2.a = 0f;
        date.GetComponentInChildren<SpriteRenderer>().material.color = color2;
        Color color3 = black.GetComponentInChildren<SpriteRenderer>().material.color;
        color3.a = 0f;
        black.GetComponentInChildren<SpriteRenderer>().material.color = color3;
        
    }

    // Update is called once per frame
    void FixedUpdate()
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
                    if (touchedPos.x < 2.5 && touchedPos.x > 1 && touchedPos.y < 5 && touchedPos.y > 4.4)
                    {
                        SceneManager.LoadScene("main");
                    }
                }
            }
        }
        if(key == -1)
        {
            time += Time.deltaTime;
            if(time > 2)
            {
                key = 0;
            }
        }
        if(key == 0)
        {
            Vector3 vec1 = new Vector3 (0, -5.4f, -1);
            Vector3 speed = Vector3.zero;
            black1.transform.position = Vector3.SmoothDamp(black1.transform.position, vec1, ref speed, 0.15f);
            Vector3 vec2 = new Vector3 (0, 10.8f, -1);
            Vector3 speed2 = Vector3.zero;
            black2.transform.position = Vector3.SmoothDamp(black2.transform.position, vec2, ref speed2, 0.15f);
        }
        if(key == 0 && black1.transform.position.y < -5.39)
        {
            key = 1;
        }
        if(key == 1)
        {
            Vector3 vec1 = new Vector3 (0, 0f, -1);
            black1.transform.position = Vector3.MoveTowards(black1.transform.position, vec1, 0.07f);
            Vector3 vec2 = new Vector3 (0, 5.4f, -1);
            black2.transform.position = Vector3.MoveTowards(black2.transform.position, vec2, 0.07f);
        }
        if(key == 1 && black1.transform.position.y > -0.01)
        {
            if (room.GetComponentInChildren<SpriteRenderer>().material.color.a > 0)
            {
                Color color = room2.GetComponentInChildren<SpriteRenderer>().material.color;
                color.a = 0.9f;
                room2.GetComponentInChildren<SpriteRenderer>().material.color = color;
            }
            time += Time.deltaTime;
            if(time > 2.5)
            {
                key = 2;
            }
        }
        if(key == 2)
        {
            Vector3 vec1 = new Vector3 (0, -5.4f, -1);
            black1.transform.position = Vector3.MoveTowards(black1.transform.position, vec1, 0.07f);
            Vector3 vec2 = new Vector3 (0, 10.8f, -1);
            black2.transform.position = Vector3.MoveTowards(black2.transform.position, vec2, 0.07f);
        }
        if(key == 2 && black1.transform.position.y < -5.39)
        {
            key = 3;
        }
        if(key == 3)
        {
            Vector3 vec1 = new Vector3 (0, 0f, -1);
            black1.transform.position = Vector3.MoveTowards(black1.transform.position, vec1, 0.05f);
            Vector3 vec2 = new Vector3 (0, 5.4f, -1);
            black2.transform.position = Vector3.MoveTowards(black2.transform.position, vec2, 0.05f);
        }
        if(key == 3 && black1.transform.position.y > -0.001)
        {
            if (room.GetComponentInChildren<SpriteRenderer>().material.color.a > 0)
            {
                Color color = room2.GetComponentInChildren<SpriteRenderer>().material.color;
                color.a = 0.8f;
                room2.GetComponentInChildren<SpriteRenderer>().material.color = color;
            }
            key = 4;
        }
        if(key == 4)
        {
            Vector3 vec1 = new Vector3 (0, -5.4f, -1);
            Vector3 speed = Vector3.zero;
            black1.transform.position = Vector3.SmoothDamp(black1.transform.position, vec1, ref speed, 0.17f);
            Vector3 vec2 = new Vector3 (0, 10.8f, -1);
            Vector3 speed2 = Vector3.zero;
            black2.transform.position = Vector3.SmoothDamp(black2.transform.position, vec2, ref speed2, 0.17f);
            if (room2.GetComponentInChildren<SpriteRenderer>().material.color.a > 0)
            {
                Color color = room2.GetComponentInChildren<SpriteRenderer>().material.color;
                color.a -= Time.deltaTime * 0.2f;
                room2.GetComponentInChildren<SpriteRenderer>().material.color = color;
            }
        }
        if(key == 4 && room2.GetComponentInChildren<SpriteRenderer>().material.color.a < 0.1)
        {
            time += Time.deltaTime;
            if(time > 3.5)
            {
                key = 5;
            }
        }
        if(key == 5)
        {
            Vector3 vec1 = new Vector3 (2.5f, 0f, -0.2f);
            room.transform.position = Vector3.MoveTowards(room.transform.position, vec1, 0.05f);
            float a = 1.5f + room.transform.position.x * 1.5f / 2.5f;
            room.transform.localScale = new Vector3(a, a, a);
        }
        if(key == 5 && room.transform.position.x > 2.49f)
        {
            time += Time.deltaTime;
            if(time > 4.5f)
            {
                key = 6;
            } 
        }
        if(key == 6 && time < 6.5f)
        {
            time += Time.deltaTime;
            Color color = date.GetComponentInChildren<SpriteRenderer>().material.color;
            color.a = (time - 4.5f) * 0.5f;
            date.GetComponentInChildren<SpriteRenderer>().material.color = color;
        }
        if(key == 6 && date.GetComponentInChildren<SpriteRenderer>().material.color.a > 0.99)
        {
            time += Time.deltaTime;
            if(time > 7.5f)
            {
                key = 7;
            }
        }
        if(key == 7)
        {
            Vector3 vec1 = new Vector3 (0, -0.5f, -0.6f);
            Vector3 speed = Vector3.zero;
            classroom.transform.position = Vector3.SmoothDamp(classroom.transform.position, vec1, ref speed, 0.1f);
            Color color = classroom.GetComponentInChildren<SpriteRenderer>().material.color;
            color.a = (classroom.transform.position.x + 3f) * 0.33f;
            classroom.GetComponentInChildren<SpriteRenderer>().material.color = color;
        }
        if(key == 7 && classroom.transform.position.y > -0.51f)
        {
            time += Time.deltaTime;
            if(time > 9.5f)
            {
                key = 8;
            }
        }
        if(key == 8 && time < 11.5f)
        {
            time += Time.deltaTime;
            Color color = date.GetComponentInChildren<SpriteRenderer>().material.color;
            color.a = 1 - ((time - 9.5f) * 0.5f);
            date.GetComponentInChildren<SpriteRenderer>().material.color = color;
            Color color1 = classroom.GetComponentInChildren<SpriteRenderer>().material.color;
            color1.a = 1 - ((time - 9.5f) * 0.5f);
            classroom.GetComponentInChildren<SpriteRenderer>().material.color = color1;
        }
        if(key == 8 && classroom.GetComponentInChildren<SpriteRenderer>().material.color.a < 0.01f)
        {
            key = 9;
        }
        if(key == 9)
        {
            Vector3 vec1 = new Vector3 (0f, 0f, -0.2f);
            room.transform.position = Vector3.MoveTowards(room.transform.position, vec1, 0.025f);
            float a = 1.5f + room.transform.position.x * 1.5f / 2.5f;
            room.transform.localScale = new Vector3(a, a, a);
        }
        if(key == 9 && room.transform.position.x < 0.01f)
        {
            key = 10;
        }
        if(key == 10)
        {
            Vector3 vec1 = new Vector3 (0f, 0f, -1.2f);
            Vector3 speed = Vector3.zero;
            hand.transform.position = Vector3.SmoothDamp(hand.transform.position, vec1, ref speed, 0.17f);
        }
        if(key == 10 && hand.transform.position.y > -0.1f)
        {
            key = 11;
        }
        if(key == 11)
        {
            Vector3 vec1 = new Vector3 (-5f, -2f, -1.4f);
            text1.transform.position = Vector3.MoveTowards(text1.transform.position, vec1, 0.1f);
        }
        if(key == 11 && text1.transform.position.x < -4.9f)
        {
            key = 12;
        }
        if(key == 12)
        {
            Vector3 vec1 = new Vector3 (-5f, 2f, -1.46f);
            text2.transform.position = Vector3.MoveTowards(text2.transform.position, vec1, 0.1f);
        }
        if(key == 12 && text2.transform.position.x < -4.9f)
        {
            key = 13;
        }
        if(key == 13)
        {
            Vector3 vec1 = new Vector3 (0f, -7f, -1.2f);
            Vector3 speed = Vector3.zero;
            hand.transform.position = Vector3.SmoothDamp(hand.transform.position, vec1, ref speed, 0.13f);
        }
        if(key == 13 && hand.transform.position.y < -6.9f)
        {
            time += Time.deltaTime;
            if(time > 12.5f)
            {
                key = 14;
            }
        }
        if(key == 14)
        {
            time += Time.deltaTime;
            Color color = black.GetComponentInChildren<SpriteRenderer>().material.color;
            color.a = ((time - 12.5f) * 0.5f);
            black.GetComponentInChildren<SpriteRenderer>().material.color = color;
        }
        if (time >= 15.5)
        {
            SceneManager.LoadScene("main");
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

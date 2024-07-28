using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class calling : MonoBehaviour
{
    public AudioClip num1;
    public AudioClip num2;
    public AudioClip num3;
    public AudioClip num4;
    public AudioClip num5;
    public AudioClip num6;
    public AudioClip num7;
    public AudioClip num8;
    public AudioClip num9;
    public AudioClip num10;
    public AudioClip num11;
    public AudioClip num12;
    public TMP_Text timer;
    public TMP_Text name;
    private float time;
    public int state;
    public int call_num;
    private int click_num;
    private Touch tempTouchs; 
    private Vector3 touchedPos;
    private bool touchOn;
    private bool IsEndcall;
    public AudioSource none;
    public AudioSource teacher;
    public AudioSource lock_;
    public AudioSource sun;
    public AudioSource sun1;
    public AudioSource sun2;
    public AudioSource sun3;
    public AudioSource hint;
    public AudioSource soda;
    public AudioSource seojun;
    public AudioSource hyunmin;
    public AudioSource main;
    public AudioSource dual;
    public AudioSource hnzn;
    public AudioSource conv;
    public AudioSource pool;
    public AudioSource sec_hnzn;
    public AudioSource junono;
    public AudioSource tetris;
    public AudioSource junho;
    private string[] calllist = {"이윤호", "강준호", "이서준", "이한진", "김현민", "???", "나태양 선배", "임석영 선생님", "김현철 선생님", "김영희 선생님"};
    // Start is called before the first frame update

    void Start()
    {
        SetResolution();
        IsEndcall = false;
        call_num = call.call_num;
        name.text = calllist[call_num];
        time = 0;
        state = 0;
        if (call_num == 0){
            teacher.Play();
        }
        if (call_num == 1){
            junho.Play();
        }
        else if (call_num == 2){
            seojun.Play();
        }
        else if (call_num == 3){
            hnzn.Play();
        }
        else if (call_num == 4){
            hyunmin.Play();
        }
        else if (call_num == 5){
            lock_.Play();    
        }
        else if (call_num == 6){
            sun.Play();    
        }
        else if (call_num >= 7){
            if(call_num == 8)
            {
                data.Ismess1 = true;
                data.isnewmess = true;
                data.newmess1 = true;
            }
            teacher.Play();    
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timer.text = $"{string.Format("{0:00}",(int)(time/60))}:{string.Format("{0:00}",(int)(time%60))}";
        touchOn = false;
        if (Input.touchCount > 0) 
        {
            for (int i=0; i<Input.touchCount; i++) 
            {
                tempTouchs = Input.GetTouch (i);
                if (tempTouchs.phase == TouchPhase.Began) 
                {
                    touchedPos = Camera.main.ScreenToWorldPoint (tempTouchs.position);
                    if (touchedPos.x < 0.43 && touchedPos.x > -0.43 && touchedPos.y < -3.45 && touchedPos.y > -4.28 && IsEndcall == true)
                    {
                        SceneManager.LoadScene("call");
                    }
                    if (touchedPos.x < -0.79 && touchedPos.x > -1.74 && touchedPos.y < 2.28 && touchedPos.y > 1.32 && none.isPlaying)
                    {
                        none.PlayOneShot(num1);
                        Invoke("funtcion1", 0.5f);
                    }
                    if (touchedPos.x < 0.39 && touchedPos.x > -0.43 && touchedPos.y < 2.28 && touchedPos.y > 1.32 && none.isPlaying)
                    {
                        none.PlayOneShot(num2);
                        Invoke("funtcion2", 0.5f);
                    }
                    if (touchedPos.x < 1.58 && touchedPos.x > 0.82 && touchedPos.y < 2.28 && touchedPos.y > 1.32 && none.isPlaying)
                    {
                        none.PlayOneShot(num3);
                        Invoke("funtcion3", 0.5f);
                    }
                    if (touchedPos.x < -0.79 && touchedPos.x > -1.74 && touchedPos.y < 0.76 && touchedPos.y > -0.11 && none.isPlaying)
                    {
                        none.PlayOneShot(num4);
                        Invoke("funtcion4", 0.5f);
                    }
                    if (touchedPos.x < 0.39 && touchedPos.x > -0.43 && touchedPos.y < 0.76 && touchedPos.y > -0.11 && none.isPlaying)
                    {
                        none.PlayOneShot(num5);
                        Invoke("funtcion5", 0.5f);
                    }
                    if (touchedPos.x < 1.58 && touchedPos.x > 0.82 && touchedPos.y < 0.76 && touchedPos.y > -0.11 && none.isPlaying)
                    {
                        none.PlayOneShot(num6);
                        Invoke("funtcion6", 0.5f);
                    }
                    if (touchedPos.x < -0.79 && touchedPos.x > -1.74 && touchedPos.y < -0.76 && touchedPos.y > -1.74 && none.isPlaying)
                    {
                        none.PlayOneShot(num7);
                        Invoke("funtcion7", 0.5f);
                    }
                    if (touchedPos.x < 0.39 && touchedPos.x > -0.43 && touchedPos.y < -0.76 && touchedPos.y > -1.74 && none.isPlaying)
                    {
                        none.PlayOneShot(num8);
                        Invoke("funtcion8", 0.5f);
                    }
                    if (touchedPos.x < 1.58 && touchedPos.x > 0.82 && touchedPos.y < -0.76 && touchedPos.y > -1.74 && none.isPlaying)
                    {
                        none.PlayOneShot(num9);
                        Invoke("funtcion9", 0.5f);
                    }
                    if (touchedPos.x < -0.79 && touchedPos.x > -1.74 && touchedPos.y < -2.21 && touchedPos.y > -3.078 && none.isPlaying)
                    {
                        none.PlayOneShot(num11);
                        Invoke("funtcion11", 0.5f);
                    }
                    if (touchedPos.x < 0.39 && touchedPos.x > -0.43 && touchedPos.y < -2.21 && touchedPos.y > -3.078 && none.isPlaying)
                    {
                        none.PlayOneShot(num10);
                        Invoke("funtcion10", 0.5f);
                    }
                    if (touchedPos.x < 1.58 && touchedPos.x > 0.82 && touchedPos.y < -2.21 && touchedPos.y > -3.078 && none.isPlaying)
                    {
                        none.PlayOneShot(num12);
                        Invoke("funtcion12", 0.5f);
                    }
                    if ((call_num >= 7 && !teacher.isPlaying) || (call_num == 6 && state == 1 && !sun1.isPlaying && !sun2.isPlaying && !sun3.isPlaying) || (call_num == 5 && !lock_.isPlaying) || (call_num == 4 && state == 1 && !main.isPlaying && !dual.isPlaying) || (call_num == 3 && !hnzn.isPlaying && !lock_.isPlaying && !conv.isPlaying && !pool.isPlaying && !sec_hnzn.isPlaying) || (call_num == 2 && state == 1 && !soda.isPlaying && !seojun.isPlaying) || (call_num == 1 && state == 1 && !junono.isPlaying && !tetris.isPlaying) || (call_num == 0 && !teacher.isPlaying) || time > 20)
                    {
                        IsEndcall = true;
                    }
                    else
                    {
                        IsEndcall = false;
                    }
                    if((call_num == 6 && !sun.isPlaying && !sun1.isPlaying && !sun2.isPlaying && !sun3.isPlaying) || (call_num == 5 && !lock_.isPlaying && !hint.isPlaying) || (call_num == 4 && !hyunmin.isPlaying && !main.isPlaying && !dual.isPlaying) || (call_num == 3 && !hnzn.isPlaying && !lock_.isPlaying && !conv.isPlaying && !pool.isPlaying && !sec_hnzn.isPlaying) || (call_num == 2 && !seojun.isPlaying && !soda.isPlaying) || (call_num == 1 && !junho.isPlaying && !junono.isPlaying && !tetris.isPlaying) || (call_num == 0 && !teacher.isPlaying))
                    {
                        none.Play();
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

    void funtcion1()
    {
        if(state == 0 && call_num == 6)
        {
            sun1.Play();
            none.Stop();
            state = 1;
        }
        if(state != 0 && call_num == 5)
        {
            state = 0;
        }
        if(state == 0 && call_num == 4)
        {
            main.Play();
            none.Stop();
            state = 1;
        }
        if(state == 3 && call_num == 3)
        {
            state = 4;
        }
        else if(state == 13 && call_num == 3)
        {
            state = 14;
        }
        else if(state < 19 && state > 11 && call_num == 3)
        {
            state = 11;
        }
        else if(state < 9 && state > 1 && call_num == 3)
        {
            state = 1;
        }
        if(state == 0 && call_num == 3)
        {
            lock_.Play();
            none.Stop();
            state = 1;
        }
        if(state == 0 && call_num == 1)
        {
            junono.Play();
            none.Stop();
            state = 1;
        }
    }

    void funtcion2()
    {
        if(state == 0 && call_num == 6)
        {
            sun2.Play();
            none.Stop();
            state = 1;
        }
        if(state == 2 && call_num == 5)
        {
            state = 3;
        }
        else if(state != 2 && call_num == 5)
        {
            state = 0;
        }
        if(state == 0 && call_num == 4)
        {
            dual.Play();
            none.Stop();
            state = 1;
        }
        if(state == 0 && call_num == 3)
        {
            lock_.Play();
            none.Stop();
            state = 11;
        }
        if(state < 19 && state > 11 && call_num == 3)
        {
            state = 11;
        }
        if(state < 9 && state > 1 && call_num == 3)
        {
            state = 1;
        }
        if(state == 0 && call_num == 1)
        {
            tetris.Play();
            none.Stop();
            state = 1;
        }
    }
    void funtcion3()
    {
        if(state == 0 && call_num == 6)
        {
            sun3.Play();
            none.Stop();
            state = 1;
        }
        if(state != 0 && call_num == 5)
        {
            state = 0;
        }
        if(state == 1 && call_num == 3)
        {
            state = 2;
        }
        else if(state == 2 && call_num == 3)
        {
            state = 3;
        }
        else if(state == 4 && call_num == 3)
        {
            state = 5;
            conv.Play();
            none.Stop();
        }
        else if(state == 11 && call_num == 3)
        {
            state = 12;
        }
        else if(state == 12 && call_num == 3)
        {
            state = 13;
        }
        else if(state == 14 && call_num == 3)
        {
            state = 15;
            pool.Play();
            none.Stop();
        }
        else if(state < 19 && state > 11 && call_num == 3)
        {
            state = 11;
        }
        else if(state < 9 && state > 1 && call_num == 3)
        {
            state = 1;
        }
        if(state == 0 && call_num == 3)
        {
            sec_hnzn.Play();
            none.Stop();
            state = 21;
        }

    }
    
    void funtcion4()
    {
        if(state != 0 && call_num == 5)
        {
            state = 0;
        }
        if(state < 19 && state > 11 && call_num == 3)
        {
            state = 11;
        }
        if(state < 9 && state > 1 && call_num == 3)
        {
            state = 1;
        }
    }

    void funtcion5()
    {
        if(state == 3 && call_num == 5)
        {
            state = 4;
            hint.Play();
            none.Stop();
        }
        else if(state != 3 && call_num == 5)
        {
            state = 0;
        }
        if(state < 19 && state > 11 && call_num == 3)
        {
            state = 11;
        }
        if(state < 9 && state > 1 && call_num == 3)
        {
            state = 1;
        }
    }

    void funtcion6()
    {
        if(state == 1 && call_num == 5)
        {
            state = 2;
        }
        else if(state != 1 && call_num == 5)
        {
            state = 0;
        }
        if(state < 19 && state > 11 && call_num == 3)
        {
            state = 11;
        }
        if(state < 9 && state > 1 && call_num == 3)
        {
            state = 1;
        }
    }

    void funtcion7()
    {
        if(state != 0 && call_num == 5)
        {
            state = 0;
        }
        if(state < 19 && state > 11 && call_num == 3)
        {
            state = 11;
        }
        if(state < 9 && state > 1 && call_num == 3)
        {
            state = 1;
        }
    }

    void funtcion8()
    {
        if(state != 0 && call_num == 5)
        {
            state = 0;
        }
        if(state < 19 && state > 11 && call_num == 3)
        {
            state = 11;
        }
        if(state < 9 && state > 1 && call_num == 3)
        {
            state = 1;
        }
    }

    void funtcion9()
    {
        if(state != 0 && call_num == 5)
        {
            state = 0;
        }
        if(state < 19 && state > 11 && call_num == 3)
        {
            state = 11;
        }
        if(state < 9 && state > 1 && call_num == 3)
        {
            state = 1;
        }
    }

    void funtcion10()
    {
        if(state == 0 && call_num == 5)
        {
            state = 1;
        }
        else if(state != 0 && call_num == 5)
        {
            state = 0;
        }
        if(state < 19 && state > 11 && call_num == 3)
        {
            state = 11;
        }
        if(state < 9 && state > 1 && call_num == 3)
        {
            state = 1;
        }
    }

    void funtcion11()
    {
        if(state != 0 && call_num == 5)
        {
            state = 0;
        }
        if(state < 19 && state > 11 && call_num == 3)
        {
            state = 11;
        }
        if(state < 9 && state > 1 && call_num == 3)
        {
            state = 1;
        }
        if(state == 0 && call_num == 2)
        {
            state = 1;
            none.Stop();
        }
        
    }

    void funtcion12()
    {
        if(state != 0 && call_num == 5)
        {
            state = 0;
        }
        if(state < 19 && state > 11 && call_num == 3)
        {
            state = 11;
        }
        if(state < 9 && state > 1 && call_num == 3)
        {
            state = 1;
        }
        if(state == 0 && call_num == 2)
        {
            state = 1;
            soda.Play();
            none.Stop();
        }
    }
}

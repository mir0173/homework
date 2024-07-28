using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class data : MonoBehaviour
{
    public static bool cnn;
    public static bool newmess1;
    public static bool newmess2;
    public static bool newmess3;
    public static bool newmess4;
    public static bool isplaying;
    public static bool isnewmess;
    public static bool IsCONV;
    public static bool IsRELU;
    public static bool IsPOOL;
    public static bool IsFLAT;
    public static bool IsFCON;
    public static bool IsSOFT;
    public static bool IsQuest;
    public static bool IsQuest2;
    public static bool IsQuest3;
    public static bool Ismess1;
    public static bool Ismess2;
    public static bool Ismess3;
    public static bool Ismess4;
    public static bool hidden;
    public static bool endgame;
    public static float time;
    public static int[] quest = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
    
    // Start is called before the first frame update
    private void Awake()
    {
        
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        time = 0;
        cnn = false;
        newmess1 = false;
        newmess2 = false;
        newmess3 = false;
        newmess4 = false;
        isplaying = false;
        isnewmess = false;
        IsCONV = false;
        IsRELU = false;
        IsPOOL = false;
        IsFLAT = false;
        IsFCON = false;
        IsSOFT = false;
        IsQuest = false;
        IsQuest2 = false;
        IsQuest3 = false;
        Ismess1 = false;
        Ismess2 = false;
        Ismess3 = false;
        Ismess4 = false;
        hidden = false;
        endgame = false;
        endgame = true;
        quest = new int[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Main")
        {
            isplaying = true;
        }
        if(isplaying == true)
        {
            time += Time.deltaTime;
        }
        if(time > 30 && Ismess3 == false)
        {
            Ismess3 = true;
            isnewmess = true;
            newmess3 = true;
        }
        if(time > 60 && Ismess4 == false)
        {
            Ismess4 = true;
            isnewmess = true;
            newmess4 = true;
        }
        if(SceneManager.GetActiveScene().name == "Login")
        {
            Destroy(gameObject);
        }
    }
}

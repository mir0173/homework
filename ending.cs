using UnityEngine;
using Firebase.Database;
using Firebase.Extensions;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class ending : MonoBehaviour
{
    public TMP_Text text1;
    public TMP_Text text4;
    public TMP_Text text5;
    public TMP_Text text6;
    public TMP_Text text7;
    public int timepoint;
    public int questpoint;
    public int point;
    private Touch tempTouchs; 
    private Vector3 touchedPos;
    int leaderboardData1;
    string namedata1;
    string namedata2;
    int rank;

    public class User
	{
        public User()
		{
		}

		public User(string point)
		{
            this.point = point;
		}
        public string point;
	}
    // Start is called before the first frame update
    void Start()
    {
        SetResolution();
        rank = 1;
        timepoint = (int)(10000 - (((data.time - 100) < 0 ? 0 : (data.time - 100)) * 5.88)) > 0 ? (int)(10000 - (((data.time - 100) < 0 ? 0 : (data.time - 100)) * 5.88)) : 0;
        questpoint = 0;
        if(data.IsQuest == true)
        {
            questpoint += 1750;
        }
        if(data.IsQuest2 == true)
        {
            questpoint += 1500;
        }
        if(data.IsQuest3 == true)
        {
            questpoint += 1750;
        }
        point = timepoint + questpoint;
        FirebaseDatabase.DefaultInstance.GetReference("users").GetValueAsync().ContinueWithOnMainThread(task =>
		{
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                leaderboardData1 = point;
                namedata1 = "";
                foreach (DataSnapshot data in snapshot.Children)
                {
                    IDictionary dic = (IDictionary)data.Value;
                    if(data.Key.ToString() == $"{login.uid_pre}")
                    {
                        namedata1 = dic["name"].ToString();
                        namedata2 = dic["grade"].ToString();
                        FirebaseDatabase.DefaultInstance.RootReference.Child("users").Child(login.uid_pre).Child("point").SetValueAsync(point);                        
                    }
                    else if(point < int.Parse(dic["point"].ToString()))
                    {
                        rank++;
                    }
                }
            }
		});
        text4.text = $"시간 점수 :  {timepoint}";
        text5.text = $"업적 점수 :  {questpoint}";
        text6.text = $"총 점수 :  {point}";
        if(point >= 10000)
        {
            text7.text = "당신은 최고의 학생!";
        }
        else if(point >= 5000)
        {
            text7.text = "당신은 평범한 학생";
        }
        else
        {
            text7.text = "당신은 불량한 학생..";
        }
    }

    // Update is called once per frame
    void Update()
    {
        text1.text = $"{rank}.{namedata2} {namedata1}  {leaderboardData1}";
        if (Input.touchCount > 0) 
        {
            for (int i=0; i<Input.touchCount; i++) 
            {
                tempTouchs = Input.GetTouch (i);
                if (tempTouchs.phase == TouchPhase.Began) 
                {
                    touchedPos = Camera.main.ScreenToWorldPoint (tempTouchs.position);
                    if (touchedPos.x < 1.8 && touchedPos.x > -1.8 && touchedPos.y < -3.6 && touchedPos.y > -4.1)
                    {
                        data.endgame = true;
                        SceneManager.LoadScene("login");
                    }
                    if (touchedPos.x < 1.8 && touchedPos.x > -1.8 && touchedPos.y < -4.26 && touchedPos.y > -4.76)
                    {
                        #if UNITY_EDITOR
                            UnityEditor.EditorApplication.isPlaying = false;
                        #else
                            UnityEngine.Application.Quit();
                        #endif

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

        Screen.SetResolution(setWidth, (int)((float)deviceHeight / deviceWidth * setWidth), true); 

        if ((float)setWidth / setHeight < (float)deviceWidth / deviceHeight)
        {
            float newWidth = (float)setWidth / setHeight / ((float)deviceWidth / deviceHeight); 
            Camera.main.rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f); 
        }
        else 
        {
            float newHeight = (float)deviceWidth / deviceHeight / ((float)setWidth / setHeight);
            Camera.main.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight); 
        }
    }
}

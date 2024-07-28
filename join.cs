using System;
using System.Collections;
using System.Collections.Generic;
using Firebase.Database;
using Firebase.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class join : MonoBehaviour
{
    public TMP_InputField nick;
    public TMP_Text mess;
    public TMP_InputField pin;
    public TMP_Dropdown dropdown;

    private Touch tempTouchs; 
    private Vector3 touchedPos;
    private bool touchOn;

    private string uid_pre;
    private string nick_pre;
    private int pin_pre;
    private int val;
    string[] a = new string[]{"18기", "19기", "20기", "기타"};

	public class User
	{
        public User()
		{
		}

		public User(string name, string pin, string grade, string point)
		{
			this.name = name;
			this.pin = pin;
            this.grade = grade;
            this.point = point;
		}

		public string name;
		public string pin;
        public string grade;
        public string point;
	}

    void Awake()
    {

        dropdown.onValueChanged.AddListener(OnDropdownEvent);
        dropdown.ClearOptions();

        List<TMP_Dropdown.OptionData> optionList = new List<TMP_Dropdown.OptionData>();

        foreach(string str in a)
        {
            optionList.Add(new TMP_Dropdown.OptionData(str));
        }

        dropdown.AddOptions(optionList);
        val = 0;
        dropdown.value = 0;
    }    

    public void OnDropdownEvent(int index) 
    {
        val = index;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetResolution();
        mess.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(Application.platform == RuntimePlatform.Android)
		{
			if(Input.GetKey(KeyCode.Escape))
			{
				SceneManager.LoadScene("login");
			}
		}
        touchOn = false;
        if (Input.touchCount > 0) 
        {
            for (int i=0; i<Input.touchCount; i++) 
            {
                tempTouchs = Input.GetTouch (i);
                if (tempTouchs.phase == TouchPhase.Began) 
                {
                    touchedPos = Camera.main.ScreenToWorldPoint (tempTouchs.position);
                    touchOn = true; 
                    if (touchedPos.x < 1.96 && touchedPos.x > -1.96 && touchedPos.y < -0.65 && touchedPos.y > -1.16 && pin.text.Length == 4 && nick.text.Length != 0)
                    {
                        writeNewUser();
                    }
                    break;
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
    private void writeNewUser()
	{
        FirebaseDatabase.DefaultInstance.GetReference("users").GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                foreach (DataSnapshot data in snapshot.Children)
                {
                    if(data.Key.ToString() == "uid")
                    uid_pre = data.GetValue(true).ToString();
                }
            }
        });
		FirebaseDatabase.DefaultInstance.GetReference("users").GetValueAsync().ContinueWithOnMainThread(task =>
		{
			if (task.IsCompleted)
			{
				DataSnapshot snapshot = task.Result;
				foreach (DataSnapshot data in snapshot.Children)
				{
                    if(data.Key.ToString() != "uid")
                    {
                        IDictionary dic = (IDictionary)data.Value;
                        if(dic["pin"].ToString() == pin.text.ToString())
                        {
                            mess.text = "이미 존재하는 pin";
                            return;
                        }
                        mess.text = "";
                    }
				}
				string rawJsonValueAsync = JsonUtility.ToJson(new User(nick.text, pin.text, a[val], "0"));
				FirebaseDatabase.DefaultInstance.RootReference.Child("users").Child(uid_pre).SetRawJsonValueAsync(rawJsonValueAsync);
                FirebaseDatabase.DefaultInstance.RootReference.Child("users").Child("uid").SetRawJsonValueAsync($"{Convert.ToInt32(uid_pre) + 1}");
                // 계정 추가 안내
                SceneManager.LoadScene("login");
			}
		});
	}
}

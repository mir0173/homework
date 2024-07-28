using System;
using System.Collections;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class login : MonoBehaviour
{
    private FirebaseApp app;
	private Touch tempTouchs; 
    private Vector3 touchedPos;
    private bool touchOn;
    public TMP_Text mess;

    public TMP_InputField nick;
    public TMP_InputField pin;

    public static string uid_pre;
    public static string nick_pre;
    public static string pin_pre;
    public static int point_pre;
    public static string val;

	// Token: 0x0400002C RID: 44
	// Token: 0x06000015 RID: 21 RVA: 0x00002680 File Offset: 0x00000880
	private void Start()
	{
        SetResolution();
        mess.text = "";
		Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
  			var dependencyStatus = task.Result;
  			if (dependencyStatus == Firebase.DependencyStatus.Available) {
    			// Create and hold a reference to your FirebaseApp,
    			// where app is a Firebase.FirebaseApp property of your application class.
    			   app = Firebase.FirebaseApp.DefaultInstance;
    			// Set a flag here to indicate whether Firebase is ready to use by your app.
  			} else {
    			UnityEngine.Debug.LogError(System.String.Format(
      			"Could not resolve all Firebase dependencies: {0}", dependencyStatus));
    			// Firebase Unity SDK is not safe to use here.
  			}
		});
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
                    touchOn = true; 
                    if (touchedPos.x < 1.94 && touchedPos.x > 1.31 && touchedPos.y < -0.27 && touchedPos.y > -0.45)
                    {
                        SceneManager.LoadScene("join");
                    }
                    if (touchedPos.x < 1.95 && touchedPos.x > -1.95 && touchedPos.y < -0.66 && touchedPos.y > -1.16 && pin.text.Length == 4 && nick.text.Length != 0)
                    {
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
                                        if(dic["pin"].ToString() == pin.text.ToString() && dic["name"].ToString() == nick.text.ToString() )
                                        {
                                            uid_pre = data.Key.ToString();
                                            nick_pre = dic["name"].ToString();
                                            pin_pre = dic["pin"].ToString();
                                            point_pre = Convert.ToInt32(dic["point"]);
                                            mess.text = "";
                                            SceneManager.LoadScene("story");
                                        }
                                        else
                                        {
                                            mess.text = "이름 혹은 pin을 다시 확인해주세요";
                                        }
                                    }
                                }
                            }
                        });
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

}

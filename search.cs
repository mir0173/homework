using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class search : MonoBehaviour
{
    public TMP_InputField search_word;
    public TMP_Text search__word;
    public TMP_Text search__text;
    public TMP_Text getword;
    private Touch tempTouchs; 
    private Vector3 touchedPos;
    private bool touchOn;
    private string[] searchlist = {"CNN", "LAYER", "UNREVR", "다중 분류", "SIGMOID", "최종 활성화 함수", "POOLING", "CONVOLUTION", "활성화 함수", "CNN의 모든 것"};
    private string[] textlist = {"CNN은 Convolutional Neural Networks의 약자로 딥러닝에서 주로 이미지나 영상 데이터를 처리할 때 쓰이며 이름에서 알수있다시피 Convolution이라는 전처리 작업이 들어가는 Neural Network 모델입니다."
    ,"핵심 데이터 구조는 모델이고, 이 모델을 구성하는 것이 Layer이다."
    ,"경기북과학고의 융합과학 동아리"
    ,"이진 분류는 타깃의 값이 어떤 기준에 대하여 참 또는 거짓의 값을 가졌습니다. 다중 분류의 경우 타깃이 가질 수 있는 값이 3개 이상이다. "
    ,"기울어진 S자 형태의 곡선이다. sigmoid라는 말 자체가 S자 모양을 뜻한다. 딥러닝에서는 sig(t) = 1 / (1 + e ^ -t) 형태로 통용되고는 한다."
    ,"softmax 함수는 출력값들의 합이 1이 되도록 하는 함수입니다. 따라서 다중 분류의 최종 활성화 함수로 사용된다."
    ,"풀링 레이어는 컨볼루션 레이어 다음에 주로 배치되는 레이어다. 풀링 레이어는 범위 내의 픽셀 중 대표값을 추출하는 방식으로 특징을 추출한다. 풀링 레이어에서 Max Pooling, Average Pooing, Min Pooling 세 가지 방식으로 대표값을 추출할 수 있다."
    ,"컨볼루션 레이어는 입력 이미지를 특정 Filter(Kernel)를 이용하여 탐색하면서 이미지의 특징들을 추출하고, 추출한 특징들을 Feature Map으로 생성한다. 피처맵은 필터가 전체 이미지를 Stride하며 모든 픽셀과 연산을 거쳐 나온 결과값이며, 필터의 크기와 같다."
    ,"ReLU(Rectified Linear Unit, 경사함수)는 가장 많이 사용되는 활성화 함수 중 하나이다. Sigmoid와 tanh가 갖는 Gradient Vanishing 문제를 해결하기 위한 함수이다."
    ,@"CNN 모델 구조의 일부는 아래와 같아 

    - ???????????
    - ReLu
    - ???????
    - Convolution
    - ????
    - Pooling
    - Flatten
    - Fully Connected
    - Softmax

    숙제를 하는데에 도움이 되기를 바래~"};
    // Start is called before the first frame update

    void Awake()
    {

    }
    void Start()
    {
        SetResolution();
        search__word.text = "";
        search__text.text = "";
        getword.text = "";
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
                    if (touchedPos.x < 2.50 && touchedPos.x > 2.16 && touchedPos.y < 5.00 && touchedPos.y > 4.60)
                    {
                        SceneManager.LoadScene("main");
                    }
                    if (touchedPos.x < 2.31 && touchedPos.x > 1.97 && touchedPos.y < 4.17 && touchedPos.y > 3.82)
                    {
                        if(Array.IndexOf(searchlist, search_word.text.ToUpper()) != -1)
                        {
                            if(search_word.text.ToUpper() != "CNN의 모든 것")
                            {
                                if(search_word.text == "활성화 함수" && data.IsRELU == false)
                                {
                                    getword.text = "ReLU 블록을 획득하였습니다!!!";
                                    data.IsRELU = true;
                                    data.quest[8] = 1;
                                }
                                if(search_word.text.ToUpper() == "CONVOLUTION" && data.IsCONV == false)
                                {
                                    getword.text = "Convolution 블록을 획득하였습니다!!!";
                                    data.IsCONV = true;
                                    data.quest[7] = 1;
                                }
                                if(search_word.text.ToUpper() == "POOLING" && data.IsPOOL == false)
                                {
                                    getword.text = "Pooling 블록을 획득하였습니다!!!";
                                    data.IsPOOL = true;
                                    data.quest[6] = 1;
                                }
                                if(search_word.text.ToUpper() == "최종 활성화 함수" && data.IsSOFT == false)
                                {
                                    getword.text = "Softmax 블록을 획득하였습니다!!!";
                                    data.IsSOFT = true;
                                    data.quest[5] = 1;
                                }
                                if(search_word.text.ToUpper() == "SIGMOID")
                                {
                                    data.quest[4] = 1;
                                }
                                if(search_word.text.ToUpper() == "다중 분류")
                                {
                                    data.quest[3] = 1;
                                }
                                if(search_word.text.ToUpper() == "UNREVR")
                                {
                                    data.quest[2] = 1;
                                }
                                if(search_word.text.ToUpper() == "LAYER")
                                {
                                    data.quest[1] = 1;
                                }
                                if(search_word.text.ToUpper() == "CNN")
                                {
                                    data.quest[0] = 1;
                                }
                                search__word.text = search_word.text;
                                search__text.text = "  " + textlist[Array.IndexOf(searchlist, search_word.text.ToUpper())];
                            }
                            else if (search_word.text.ToUpper() == "CNN의 모든 것" && data.cnn == false)
                            {
                                search__word.text = search_word.text;
                                search__text.text = "  " + textlist[Array.IndexOf(searchlist, search_word.text.ToUpper())];
                                data.cnn = true;
                                data.quest[9] = 1;
                            }
                            else if (search_word.text.ToUpper() == "CNN의 모든 것" && data.cnn == true)
                            {
                                search__word.text = search_word.text;
                                search__text.text = "금지된 검색어 입니다.";
                                data.quest[10] = 1;
                            }
                        }
                        else if(search_word.text.ToUpper() == "프로세카" || search_word.text.ToUpper() == "DJMAX" || search_word.text.ToUpper() == "CLASSICAL" || search_word.text.ToUpper() == "디시인사이드" || search_word.text.ToUpper() == "EQ" || search_word.text.ToUpper() == "근친")
                        {
                            search__word.text = "히든 메세지 개방";
                            search__text.text = "";
                            data.Ismess2 = true;
                            data.isnewmess = true;
                            data.newmess2 = true;
                            data.hidden = true;
                        }
                        else
                        {
                            search__word.text = "검색결과를 찾을 수 없음";
                            search__text.text = "";
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

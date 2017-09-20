using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    //单例
    public static GameManager intance;
    public GameObject brid; 
    private void Awake()
    {
        //单例
        intance = this;
        //控制小鸟的重力
        brid = GameObject.FindGameObjectWithTag("Player");
    }

    //可以使用枚举
    public static int GAME_MENU = 0;      //游戏菜单
    public static int GAME_PLAYING = 1;   //游戏开始
    public static int GAME_END = 2;       //游戏结束
 
    public int GameState = GAME_MENU;

    public Transform firstBg;  //第三张背景
 
    public int score = 0;   //分数

    public Text tishi;

    void Start()
    {
        tishi =GameObject.FindGameObjectWithTag("tishi").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update () {
        //单击，变化游戏状态，，开始游戏
        if (GameState == GAME_MENU)
        {
            GameMenu._instance.gameObject.SetActive(false);
           
            if (Input.GetMouseButtonDown(0))
            {
                GameState = GAME_PLAYING;
                brid.SendMessage("getLife");
            }
        }

        if(GameState == GAME_END)
        {
            //Debug.Log("GAMEEND");
            GameMenu._instance.gameObject.SetActive(true);
            GameMenu._instance.UpdateScore(score);
        }

        if (GameState == GAME_PLAYING)
        {

            tishi.gameObject.SetActive(false);

        }
    }

    
}

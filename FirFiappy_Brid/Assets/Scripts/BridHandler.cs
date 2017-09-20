using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridHandler : MonoBehaviour {

    public float timer;   //计时器，

    public int frameNum =10;   //  每秒显示几帧
    public int frameCount;     //  帧的计数器

    private float x = 3; //小鸟运行速度

    public AudioSource Jumpaudio;  //跳跃音效
	// Use this for initialization
	void Start () {
        Jumpaudio = this.GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {

        if (GameManager.intance.GameState == GameManager.GAME_PLAYING)  //可以跳的状态
        {
            Vector3 vel = this.GetComponent<Rigidbody>().velocity;
            //跳
            if (Input.GetMouseButtonDown(0))
            {
                Jumpaudio.Play();
                this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(vel.x, 5, vel.z);
                x += 0.5f;
                Debug.Log(x);
            }
            //this.gameObject.GetComponent<Rigidbody>().velocity = vel;
        }
        
        //通过游戏状态控制，是否播放此动画
        if (GameManager.intance.GameState == GameManager.GAME_PLAYING)
        {
            timer += Time.deltaTime;  //加上一帧的时间
            if (timer >= 1.0f / frameNum)  //大于1帧所用的时间
            {
                frameCount++;   //帧数增加
                timer -= 1.0f / frameNum;

                //三帧  （0,1,2显示每一帧画面）
                int frameIndex = frameCount % 3;

                //更新offset x 属性   
                //this.renderer.material   已过时   着色器的主材质（“_MainTex”）
                this.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0.33333f * frameIndex, 0));
            }
        }
  	}
    public void getLife()
    {
    
        this.GetComponent<Rigidbody>().useGravity = true;
        this.GetComponent<Rigidbody>().velocity = new Vector3(x, 0, 0);
     
    }
}

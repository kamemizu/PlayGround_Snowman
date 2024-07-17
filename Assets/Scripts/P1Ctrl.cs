using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class P1Ctrl : MonoBehaviour
{
    //雪玉のスケール
    Vector3 snowball_scale;
    //肥大化度
    float add_scale;
    //スクロール背景を2つ取得
    [SerializeField] GameObject ground1, ground2;
    //背景スクロールの速度
    public float scrollSpeed = 0;
    //カメラの表示エリア
    Vector2 cameraArea;

    // Start is called before the first frame update
    void Start()
    {
        //カメラの右下の座標を取得
        cameraArea = Camera.main.ViewportToWorldPoint(Vector2.zero);
        snowball_scale = this.transform.localScale;
        add_scale = 0; 
        scrollSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //スクロール速度を減速
        //scrollSpeed--;

        ground1.transform.Translate(Vector2.down * scrollSpeed * Time.deltaTime);
        if (ground1.transform.position.y < cameraArea.y * 2)
        {
            ground1.transform.position = new Vector2(ground1.transform.position.x, (Camera.main.transform.position.y - cameraArea.y) * 2);
        }

        ground2.transform.Translate(Vector2.down * scrollSpeed * Time.deltaTime);
        if (ground2.transform.position.y < cameraArea.y * 2)
        {
            ground2.transform.position = new Vector2(ground2.transform.position.x, (Camera.main.transform.position.y - cameraArea.y) * 2);
        }

        //ボタンを押した時に前進
        if (Input.GetKeyDown(KeyCode.A))
        {
            if(this.gameObject.name == "1P")
            {
                Move();
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (this.gameObject.name == "2P")
            {
                Move();
            }
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (this.gameObject.name == "3P")
            {
                Move();
            }
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (this.gameObject.name == "4P")
            {
                Move();
            }
        }
        add_scale = scrollSpeed * Time.deltaTime * 0.001f;
        //移動距離で大きさ変更
        snowball_scale += new Vector3(add_scale, add_scale, 0);
        transform.localScale = snowball_scale;
    }

    private void Move()
    {
        scrollSpeed += 0.5f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_PCtrl : MonoBehaviour
{
    private Animator animator;
    private const string rollspeed = "rollspeed";
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
        scrollSpeed = 0;
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("ball_a_1");
            if (this.gameObject.name == "ball_a_1")
            {
                Move();
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (this.gameObject.name == "ball_b_1")
            {
                Move();
            }
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            if (this.gameObject.name == "ball_x_1")
            {
                Move();
            }
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (this.gameObject.name == "ball_y_1")
            {
                Move();
            }
        }

        animator.SetFloat(rollspeed, scrollSpeed * 0.2f);
        if(scrollSpeed > 0)
        {
            scrollSpeed -= Time.deltaTime;
        }

    }

    private void Move()
    {
        scrollSpeed += 0.5f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //背景スクロールの速度
    private float scrollSpeed = 2;
    //カメラの表示エリア
    Vector2 cameraArea;
    // Start is called before the first frame update
    void Start()
    {
        cameraArea = Camera.main.ViewportToWorldPoint(Vector2.zero);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(Vector2.down * scrollSpeed * Time.deltaTime);
        if (transform.position.y < cameraArea.y * 2)
        {
            transform.position = new Vector2(transform.position.x, (Camera.main.transform.position.y - cameraArea.y) * 2);
        }
    }
}

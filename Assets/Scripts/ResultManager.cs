using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    //カメラの表示エリア
    Vector2 cameraArea;
    float timer = 4;

    [SerializeField] GameObject camera;
    float cameraY;
    [SerializeField] GameObject p1;
    [SerializeField] GameObject p2;
    [SerializeField] GameObject p3;
    [SerializeField] GameObject p4;
    Vector3 p1Size;
    Vector3 p2Size;
    Vector3 p3Size;
    Vector3 p4Size;

    // Start is called before the first frame update
    void Start()
    {
        p1Size = GameManager.getP1Size();
        p2Size = GameManager.getP2Size();
        p3Size = GameManager.getP3Size();
        p4Size = GameManager.getP4Size();
        p1.transform.localScale = p1Size;
        p2.transform.localScale = p2Size;
        p3.transform.localScale = p3Size;
        p4.transform.localScale = p4Size;
        cameraY = camera.transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        cameraArea = camera.GetComponent<Camera>().ViewportToWorldPoint(Vector2.one);
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer < 0)
        {
            if(p1.transform.position.y + p1.transform.localScale.y * 10 > cameraArea.y)
            {
                cameraY += Time.deltaTime;
                camera.transform.localPosition = new Vector3 (0, cameraY, 0);
                camera.GetComponent<Camera>().orthographicSize += Time.deltaTime;
            }
        }

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class P1Ctrl : MonoBehaviour
{
    //��ʂ̃X�P�[��
    Vector3 snowball_scale;
    //��剻�x
    float add_scale;
    //�X�N���[���w�i��2�擾
    [SerializeField] GameObject ground1, ground2;
    //�w�i�X�N���[���̑��x
    public float scrollSpeed = 0;
    //�J�����̕\���G���A
    Vector2 cameraArea;

    // Start is called before the first frame update
    void Start()
    {
        //�J�����̉E���̍��W���擾
        cameraArea = Camera.main.ViewportToWorldPoint(Vector2.zero);
        snowball_scale = this.transform.localScale;
        add_scale = 0; 
        scrollSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameManager.state)
        {
            case GameManager.State.Ready:
                break;
            case GameManager.State.InGame:
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
                    Debug.Log("1P");
                    if (this.gameObject.name == "1P")
                    {
                        Debug.Log("1P");
                        Move();
                    }
                }
                if (Input.GetKeyDown(KeyCode.R))
                {
                    if (this.gameObject.name == "2P")
                    {
                        Move();
                    }
                }
                if (Input.GetKeyDown(KeyCode.U))
                {
                    if (this.gameObject.name == "3P")
                    {
                        Move();
                    }
                }
                if (Input.GetKeyDown(KeyCode.P))
                {
                    if (this.gameObject.name == "4P")
                    {
                        Move();
                    }
                }
                add_scale = scrollSpeed * Time.deltaTime * 0.001f;
                //�ړ������ő傫���ύX
                snowball_scale += new Vector3(add_scale, add_scale, 0);
                transform.localScale = snowball_scale;
                break;
            case GameManager.State.Result:
                transform.Translate(Vector2.up * Time.deltaTime * scrollSpeed);
                break;
        }

    }

    private void Move()
    {
        scrollSpeed += 0.5f;
    }

}

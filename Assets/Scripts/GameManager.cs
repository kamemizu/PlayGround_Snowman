using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject P1;
    [SerializeField] GameObject P2;
    [SerializeField] GameObject P3;
    [SerializeField] GameObject P4;
    [SerializeField] GameObject CountDownTimer;
    [SerializeField] GameObject Count3;
    [SerializeField] GameObject Count2;
    [SerializeField] GameObject Count1;
    [SerializeField] GameObject Go;
    [SerializeField] GameObject Fin;
    [SerializeField] GameObject FinCount5;
    [SerializeField] GameObject FinCount4; 
    [SerializeField] GameObject FinCount3;
    [SerializeField] GameObject FinCount2;
    [SerializeField] GameObject FinCount1;
    public enum State
    {
        Ready,
        InGame,
        Result
    }
    public static State state;
    public float timer = 20.0f;
    private float startTimer;
    private float endTimer;

    public static Vector3 p1Size;
    public static Vector3 p2Size;
    public static Vector3 p3Size;
    public static Vector3 p4Size;

    private AudioSource bgm;
    void Start()
    {
        endTimer = 3;
        state = State.Ready;
        startTimer = 4;
        CountDownTimer.SetActive(false);
        Count3.SetActive(false);
        Count2.SetActive(false);
        Count1.SetActive(false);
        Go.SetActive(false);
        FinCount5.SetActive(false);
        FinCount4.SetActive(false);
        FinCount3.SetActive(false);
        FinCount2.SetActive(false);
        FinCount1.SetActive(false);
        Fin.SetActive(false);
        bgm = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Ready:
                Debug.Log("Ready");
                bgm.pitch = 0;
                Count();
                break;
            case State.InGame:
                Debug.Log("InGame");
                if(timer > 5)
                {
                    CountDownTimer.SetActive(true);
                }
                if(timer < 5 && timer > 4)
                {
                    CountDownTimer.SetActive(false);
                    FinCount5.SetActive(true);
                }
                if (timer < 4 && timer > 3)
                {
                    FinCount5.SetActive(false);
                    FinCount4.SetActive(true);
                }
                if (timer < 3 && timer > 2)
                {
                    FinCount4.SetActive(false);
                    FinCount3.SetActive(true);
                }
                if (timer < 2 && timer > 1)
                {
                    FinCount3.SetActive(false);
                    FinCount2.SetActive(true);
                }
                if (timer < 1 && timer > 0)
                {
                    FinCount2.SetActive(false);
                    FinCount1.SetActive(true);
                }

                TimerCount();
                break;
            case State.Result:
                Debug.Log("Result");
                Finish();
                break;
        }
    }

    void TimerCount()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            if(timer > 10)
            {
                bgm.pitch = 1.0f;
            }
            else if(timer > 5)
            {
                bgm.pitch = 1.1f;
            }
            else
            {
                bgm.pitch = 1.2f;
            }
        }
        if(timer <= 0)
        {
            state = State.Result;
        }
        CountDownTimer.GetComponent<Text>().text = String.Format("{0:00.0}", timer);
    }
    void Count()
    {
        if (startTimer > -1)
        {
            startTimer -= Time.deltaTime;
        }
        if(startTimer < 3 && startTimer > 2)
        {
            Count3.SetActive(true);
        }
        if (startTimer < 2 && startTimer > 1)
        {
            Count3.SetActive(false);
            Count2.SetActive(true);
        }
        if (startTimer < 1 && startTimer > 0)
        {
            Count2.SetActive(false);
            Count1.SetActive(true);
        }
        if (startTimer < 0 && startTimer > -1)
        {
            Count1.SetActive(false);
            Go.SetActive(true);
        }
        if (startTimer <= -1)
        {
            Go.SetActive(false);
            state = State.InGame;
        }
    }

    void Finish()
    {
        FinCount1.SetActive(false);
        Fin.SetActive(true);
        bgm.pitch = 0;
        endTimer -= Time.deltaTime;
        if(endTimer < 0)
        {
            p1Size = P1.transform.localScale;
            p2Size = P2.transform.localScale;
            p3Size = P3.transform.localScale;
            p4Size = P4.transform.localScale;
            SceneManager.LoadScene("Result");
        }
    }

    public static Vector3 getP1Size()
    {
        return p1Size;
    }
    public static Vector3 getP2Size()
    {
        return p2Size;
    }
    public static Vector3 getP3Size()
    {
        return p3Size;
    }
    public static Vector3 getP4Size()
    {
        return p4Size;
    }
}

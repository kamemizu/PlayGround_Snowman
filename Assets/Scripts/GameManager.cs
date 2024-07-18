using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using Unity.VisualScripting;

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
    public enum State
    {
        Ready,
        InGame,
        Result
    }
    public static State state;
    public float timer;
    private float startTimer;
    void Start()
    {
        state = State.Ready;
        timer = 20.0f;
        startTimer = 4;
        CountDownTimer.SetActive(false);
        Count3.SetActive(false);
        Count2.SetActive(false);
        Count1.SetActive(false);
        Go.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Ready:
                Count();
                break;
            case State.InGame:
                CountDownTimer.SetActive(true);
                TimerCount();
                break;
            case State.Result:
                Finish();
                break;
        }
    }

    void TimerCount()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
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
    }
}

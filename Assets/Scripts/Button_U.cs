using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_U : MonoBehaviour
{
    float timer;
    [SerializeField] Sprite button_down;
    [SerializeField] Sprite button_up;
    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U) && GameManager.state == GameManager.State.InGame)
        {
            // ‰æ‘œ‚ğØ‚è‘Ö‚¦‚Ü‚·
            image.sprite = button_down;
            timer = 10;
        }
        else if (timer <= 0)
        {
            image.sprite = button_up;
        }
        else
        {
            timer--;
        }
    }
}
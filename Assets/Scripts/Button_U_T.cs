using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_U_T : MonoBehaviour
{
    float timer;
    [SerializeField] Sprite button_down;
    [SerializeField] Sprite button_up;
    private Image image; bool up;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            // âÊëúÇêÿÇËë÷Ç¶Ç‹Ç∑
            image.sprite = button_down;
            up = false;
            timer = 10;
        }
        else if (up)
        {
            image.sprite = button_up;
        }

        if (Input.GetKeyUp(KeyCode.U))
        {
            up = true;
        }
    }
}
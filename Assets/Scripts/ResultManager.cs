using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    //�G�t�F�N�g�^�C�}�[
    float effectTimer = 0;
    //�G�t�F�N�g�I�u�W�F�N�g
    [SerializeField] GameObject effect1;
    [SerializeField] GameObject effect2;
    [SerializeField] GameObject effect3;
    [SerializeField] GameObject effect4;
    //�Ⴞ��ܑ���
    [SerializeField] Sprite head;
    [SerializeField] Sprite body;
    [SerializeField] Sprite hip;
    [SerializeField] Sprite foot;


    //�J�����̕\���G���A
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
        effect1.SetActive(false);
        effect2.SetActive(false);
        effect3.SetActive(false);
        effect4.SetActive(false);
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
            else
            {
                effectTimer += Time.deltaTime;
                if(effectTimer > 0)
                {
                    // �ύX�Ώۂ̃I�u�W�F�N�g������ SpriteRenderer ���擾
                    var spriteRenderer = p1.GetComponent<SpriteRenderer>();
                    effect1.SetActive(true);
                    spriteRenderer.sprite = head;
                }
                if(effectTimer > 1)
                {
                    // �ύX�Ώۂ̃I�u�W�F�N�g������ SpriteRenderer ���擾
                    var spriteRenderer = p2.GetComponent<SpriteRenderer>();
                    effect2.SetActive(true);
                    spriteRenderer.sprite = body;
                }
                if (effectTimer > 2)
                {
                    // �ύX�Ώۂ̃I�u�W�F�N�g������ SpriteRenderer ���擾
                    var spriteRenderer = p3.GetComponent<SpriteRenderer>();
                    effect3.SetActive(true);
                    spriteRenderer.sprite = hip;
                }
                if (effectTimer > 3)
                {
                    // �ύX�Ώۂ̃I�u�W�F�N�g������ SpriteRenderer ���擾
                    var spriteRenderer = p4.GetComponent<SpriteRenderer>();
                    effect4.SetActive(true);
                    spriteRenderer.sprite = foot;
                }
            }
        }

    }

    public void GoTitle()
    {
        SceneManager.LoadScene("Title");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public int maxSaglik, gecerliSaglik;

    UIController uiController;

    public float yenilmezlikSuresi;
    float yenilmezlikSayaci;


    SpriteRenderer spriteRenderer;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        uiController = Object.FindObjectOfType<UIController>();
    }

    private void Start()
    {
        gecerliSaglik = maxSaglik;
    }

    private void Update()
    {
        yenilmezlikSayaci -= Time.deltaTime;

        if (yenilmezlikSayaci <= 0)
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.5f);
        }
    }

    public void HasarAl()
    {
        if (yenilmezlikSayaci <= 0)
        {
            gecerliSaglik--;

            if (gecerliSaglik <= 0)
            {
                gecerliSaglik = 0;
                gameObject.SetActive(false);
            }
            else
            {
                yenilmezlikSayaci = yenilmezlikSuresi;
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.5f);
            }

            uiController.SaglikDurumunuGuncelle();
        }
      
    }



}

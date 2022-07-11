using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public int maxSaglik, gecerliSaglik;

    [SerializeField]
    GameObject yokOlmaEfekti;

    UIController uiController;

    public float yenilmezlikSuresi;
    float yenilmezlikSayaci;


    SpriteRenderer spriteRenderer;


    PlayerController playerController;


    private void Awake()
    {
        playerController = Object.FindObjectOfType<PlayerController>();

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
                Instantiate(yokOlmaEfekti, transform.position, transform.rotation);
                SesController.instance.SesEfektiCikar(2);
            }
            else
            {
                yenilmezlikSayaci = yenilmezlikSuresi;
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.5f);

                playerController.GeriTepmeFNC();
                SesController.instance.SesEfektiCikar(1);
            }

            uiController.SaglikDurumunuGuncelle();
        }
      
    }

    public void CaniArtýrFNC()
    {
        gecerliSaglik++;

        if (gecerliSaglik >= maxSaglik)
        {
            gecerliSaglik = maxSaglik;
        }

        uiController.SaglikDurumunuGuncelle();
    }



}

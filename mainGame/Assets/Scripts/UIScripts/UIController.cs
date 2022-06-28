using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    Image kalp1_Img, kalp2_Img, kalp3_Img;

    [SerializeField]
    Sprite doluKalp, yarimKalp, bosKalp;

    PlayerHealthController playerHealthController;

    private void Awake()
    {
        playerHealthController = Object.FindObjectOfType<PlayerHealthController>();
    }

    public void SaglikDurumunuGuncelle()
    {
        switch (playerHealthController.gecerliSaglik)
        {
            case 6:
                kalp1_Img.sprite = doluKalp;
                kalp2_Img.sprite = doluKalp;
                kalp3_Img.sprite = doluKalp;
                break;

            case 5:
                kalp1_Img.sprite = doluKalp;
                kalp2_Img.sprite = doluKalp;
                kalp3_Img.sprite = yarimKalp;
                break;

            case 4:
                kalp1_Img.sprite = doluKalp;
                kalp2_Img.sprite = doluKalp;
                kalp3_Img.sprite = bosKalp;
                break;



            case 3:
                kalp1_Img.sprite = yarimKalp;
                kalp2_Img.sprite = doluKalp;
                kalp3_Img.sprite = bosKalp;
                break;

            case 2:
                kalp1_Img.sprite = bosKalp;
                kalp2_Img.sprite = doluKalp;
                kalp3_Img.sprite = bosKalp;
                break;

            case 1:
                kalp1_Img.sprite = bosKalp;
                kalp2_Img.sprite = yarimKalp;
                kalp3_Img.sprite = bosKalp;
                break;

            case 0:
                kalp1_Img.sprite = bosKalp;
                kalp2_Img.sprite = bosKalp;
                kalp3_Img.sprite = bosKalp;
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;

    PlayerController playerController;
    UIController uiController;

    public string sahneAdi;


    private void Awake()
    {
        instance = this;

        playerController = Object.FindObjectOfType<PlayerController>();
        uiController = Object.FindObjectOfType<UIController>();
    }


    public int toplananMucevherSayisi;

    

    public void SahneyiBitir()
    {
        StartCoroutine(SahneyiBitirRoutine());
    }

    IEnumerator SahneyiBitirRoutine()
    {
        yield return new WaitForSeconds(.1f);
        playerController.hareketEtsinmi = false;

        yield return new WaitForSeconds(1f);
        uiController.FadeEkraniAc();

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sahneAdi);
    }
}

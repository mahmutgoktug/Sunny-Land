using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MainMenuController : MonoBehaviour
{
    public string sahneAdi;

    public GameObject resimObje;
    public GameObject baslaBtn, cikisBtn;


    private void Start()
    {
        StartCoroutine(SiraylaAcRoutine());
    }

    IEnumerator SiraylaAcRoutine()
    {
        yield return new WaitForSeconds(.1f);

        resimObje.GetComponent<CanvasGroup>().DOFade(1, 0.5f);

        yield return new WaitForSeconds(.4f);

        baslaBtn.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
        baslaBtn.GetComponent<RectTransform>().DOScale(1, .5f).SetEase(Ease.OutBack);

        yield return new WaitForSeconds(.4f);

        cikisBtn.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
        cikisBtn.GetComponent<RectTransform>().DOScale(1, .5f).SetEase(Ease.OutBack);
    }


    public void OyunaBasla()
    {
        SceneManager.LoadScene(sahneAdi);
    }

    public void OyundanCikis()
    {
        Application.Quit();
    }
}

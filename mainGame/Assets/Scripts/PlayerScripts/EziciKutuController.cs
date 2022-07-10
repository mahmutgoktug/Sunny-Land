using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EziciKutuController : MonoBehaviour
{
    [SerializeField]
    GameObject yokOlmaEfekti;

    PlayerController playerController;

    public float kirazinCikmaSansi;

    public GameObject kirazObje;

    private void Awake()
    {
        playerController = Object.FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Kurbaga"))
        {
            other.transform.parent.gameObject.SetActive(false);
            Instantiate(yokOlmaEfekti, transform.position, transform.rotation);

            playerController.ZiplaZiplaFNC();

            float cikmaAraligi = Random.Range(0, 100f);



            SesController.instance.SesEfektiCikar(0);

            if (cikmaAraligi <= kirazinCikmaSansi)
            {
                Instantiate(kirazObje, other.transform.position, other.transform.rotation);
            }
        }
    }
}

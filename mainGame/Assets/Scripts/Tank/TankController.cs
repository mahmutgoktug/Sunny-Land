using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public enum tankDurumlari { atesEtme,darbeAlma,hareketEtme,sonaErdi};
    public tankDurumlari gecerliDurum;


    [SerializeField]
    Transform tankObje;
    public Animator anim;

    [Header("Hareket")]
    public float hareketHizi;
    public Transform solHedef, sagHedef;
    bool yonuSagmi;
    public GameObject mayinObje;
    public Transform mayinMerkezNoktasi;
    public float mayinBirakmaSuresi;
    float mayinBirakmaSayac;

    [Header("AtesEtme")]
    public GameObject mermi;
    public Transform mermiMerkezi;
    public float mermiAtmaSuresi;
    float mermiAtmaSayac;

    [Header("Darbe")]
    public float darbeSuresi;
    float darbeSayaci;

    [Header("CanDurumu")]
    public int canDurumu = 5;
    public GameObject tankPatlamaEfekti;
    bool yenildimi;
    public float mermiSuresiArtýr, mayinBirakmaSuresiArtir;


    public GameObject tankEziciKutu;

    private void Start()
    {
        gecerliDurum = tankDurumlari.atesEtme;
    }

    private void Update()
    {
        switch (gecerliDurum)
        {
            case tankDurumlari.atesEtme:
                //ates edildiginde olacak durumlar
                mermiAtmaSayac -= Time.deltaTime;

                if (mermiAtmaSayac < 0)
                {
                    mermiAtmaSayac = mermiAtmaSuresi;

                    var yeniMermi= Instantiate(mermi, mermiMerkezi.position, mermiMerkezi.rotation);
                    yeniMermi.transform.localScale = tankObje.localScale;
                }

                break;

            case tankDurumlari.darbeAlma:
                //tank darbe aldýðýnda olacak durumlar
                if (darbeSayaci > 0)
                {
                    darbeSayaci -= Time.deltaTime;

                    if (darbeSayaci <= 0)
                    {
                        gecerliDurum = tankDurumlari.hareketEtme;
                        mayinBirakmaSayac = 0;

                        if (yenildimi)
                        {
                            tankObje.gameObject.SetActive(false);
                            Instantiate(tankPatlamaEfekti, transform.position, transform.rotation);

                            gecerliDurum = tankDurumlari.sonaErdi;
                        }
                    }
                }

                break;

            case tankDurumlari.hareketEtme:
                //tank hareket ettiðinde olacak durumlar

                if (yonuSagmi)
                {
                    tankObje.position += new Vector3(hareketHizi * Time.deltaTime, 0f, 0f);

                    if (tankObje.position.x > sagHedef.position.x)
                    {
                        tankObje.localScale = Vector3.one;
                        yonuSagmi = false;

                        HareketiDurdurFNC();
                    }
                }
                else
                {
                    tankObje.position -= new Vector3(hareketHizi * Time.deltaTime, 0f, 0f);

                    if (tankObje.position.x <  solHedef.position.x)
                    {
                        tankObje.localScale = new Vector3(-1, 1, 1);
                        yonuSagmi = true;

                        HareketiDurdurFNC();
                    }
                }

                mayinBirakmaSayac -= Time.deltaTime;

                if (mayinBirakmaSayac <= 0)
                {
                    mayinBirakmaSayac = mayinBirakmaSuresi;

                    Instantiate(mayinObje, mayinMerkezNoktasi.position, mayinMerkezNoktasi.rotation);
                }

                break;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            DarbeAlFNC();
        }
    }

    public void DarbeAlFNC()
    {
        

        gecerliDurum = tankDurumlari.darbeAlma;
        darbeSayaci = darbeSuresi;

        anim.SetTrigger("Vur");


        MayinController[] mayinlar = FindObjectsOfType<MayinController>();

        if (mayinlar.Length > 0)
        {
            foreach (MayinController bulunanMayin in mayinlar)
            {
                bulunanMayin.PatlamaFNC();
            }
        }

        canDurumu--;

        if (canDurumu <= 0)
        {
            yenildimi = true;
        }
        else
        {
            mermiAtmaSuresi /= mermiSuresiArtýr;
            mayinBirakmaSuresi /= mayinBirakmaSuresiArtir;
        }

    }

    void HareketiDurdurFNC()
    {
        tankEziciKutu.SetActive(true);

        gecerliDurum = tankDurumlari.atesEtme;
        mermiAtmaSayac = mermiAtmaSuresi;
        anim.SetTrigger("HareketiDurdur");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public enum tankDurumlari { atesEtme,darbeAlma,hareketEtme};
    public tankDurumlari gecerliDurum;


    [SerializeField]
    Transform tankObje;
    public Animator anim;

    [Header("Hareket")]
    public float hareketHizi;
    public Transform solHedef, sagHedef;
    bool yonuSagmi;

    [Header("AtesEtme")]
    public GameObject mermi;
    public Transform mermiMerkezi;
    public float mermiAtmaSuresi;
    float mermiAtmaSayac;

    [Header("Darbe")]
    public float darbeSuresi;
    float darbeSayaci;

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

                break;

            case tankDurumlari.darbeAlma:
                //tank darbe aldýðýnda olacak durumlar
                if (darbeSayaci > 0)
                {
                    darbeSayaci -= Time.deltaTime;

                    if (darbeSayaci <= 0)
                    {
                        gecerliDurum = tankDurumlari.hareketEtme;
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
    }

    void HareketiDurdurFNC()
    {
        gecerliDurum = tankDurumlari.atesEtme;
        mermiAtmaSayac = mermiAtmaSuresi;

        anim.SetTrigger("HareketiDurdur");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float hareketHizi;

    [SerializeField]
    float ziplamaGucu;


    bool yerdemi;
    public Transform zeminKontrolNoktasi;
    public LayerMask zeminLayer;
    bool ikiKezZiplayabilirmi;




    Rigidbody2D rb;

    Animator anim;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        HareketEttir();
        ZiplaFNC();
        YonuDegistir();
    }


    void HareketEttir()
    {
        float h = Input.GetAxis("Horizontal");
        float hiz = h * hareketHizi;

        rb.velocity = new Vector2(hiz, rb.velocity.y);
    }


    void ZiplaFNC()
    {
        yerdemi = Physics2D.OverlapCircle(zeminKontrolNoktasi.position, .2f, zeminLayer);

        if (yerdemi)
        {
            ikiKezZiplayabilirmi = true;
        }
        

        if (Input.GetButtonDown("Jump"))
        {
            if (yerdemi)
            {
                rb.velocity = new Vector2(rb.velocity.x, ziplamaGucu);
            }
            else
            {
                if (ikiKezZiplayabilirmi)
                {
                    rb.velocity = new Vector2(rb.velocity.x, ziplamaGucu);
                    ikiKezZiplayabilirmi = false;
                }

               
            }
            
        }

        anim.SetFloat("hareketHizi", Mathf.Abs(rb.velocity.x));
        anim.SetBool("yerdemi", yerdemi);
    }

    void YonuDegistir()
    {
        Vector2 geciciScale = transform.localScale;

        if (rb.velocity.x > 0)
        {
            geciciScale.x = 1f;
        } else if (rb.velocity.x<0)
        {
            geciciScale.x = -1f;
        }

        transform.localScale = geciciScale;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balon : MonoBehaviour
{
    float hiz = 5.0f;

    Color[] renkler;

    yonetici yonet;
    MeshRenderer gorunurluk;
    public bool patlatildi = false;
    public GameObject patlama_efekti;

    

    private void OnEnable()
    {
        yonet= GameObject.Find("yonetici").GetComponent<yonetici>();
        gorunurluk=gameObject.GetComponent<MeshRenderer>();
        renk_degisimi();

        CancelInvoke("sil");
        Invoke("sil", 3.0f);
    }

    private void OnDisable()
    {
        if (patlatildi == true)
        {
            GameObject y_efekt= Instantiate(patlama_efekti, transform.position,Quaternion.identity);
            y_efekt.GetComponent<ParticleSystem>().startColor=gorunurluk.material.color;
            Destroy(y_efekt,0.5f);

            if (gorunurluk.material.color == renkler[0])
            {
                yonet.saniyeyi_degistir(-1);
                yonet.skoru_degistir(-10);
            }
            else
            {

                yonet.saniyeyi_degistir(1);
                yonet.skoru_degistir(10);

            }
            patlatildi=false;
        }
    }

    void renk_degisimi()
    {
        renkler = new Color[4];
        renkler[0] = Color.red;
        renkler[1] = Color.blue;
        renkler[2] = Color.green;
        renkler[3] = Color.yellow;

        int rast = Random.Range(0, renkler.Length);
        gorunurluk.material.color = renkler[rast];

    }

    void sil()
    {

        gameObject.SetActive(false);

    }

    private void Update()
    {
        transform.Translate(0, -hiz * Time.deltaTime, 0);
    }

}

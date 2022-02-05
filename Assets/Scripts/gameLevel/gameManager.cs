using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject puanSurePaneli;

    [SerializeField]
    private GameObject pausePaneli, sonucPaneli;

    [SerializeField]
    private GameObject puaniKapYazisi, buyukOlanSayiSecYazisi;

    [SerializeField]
    private GameObject ustDikdortgen, altDikdortgen;

    [SerializeField]
    private Text ustText, altText, puanText;

    [SerializeField]
    private GameObject koyuYesilDaireler, acikYesilDaireler;

    sureTextManager sureTextManager;
    dairelerManager dairelerManager;
    trueFalseManager trueFalseManager;
    sonucManager sonucManager;
    

    int oyunSayac, kacinciOyun;
    int ustDeger, altDeger;
    int buyukDeger;
    int butonDegeri;
    int toplamPuan, artisPuan;
    int dogruAdet, yanlisAdet;

    bool butonaBasilsinmi;

    private AudioSource audioSource;

    [SerializeField]
    private AudioClip baslangicSesi, dogruSesi, yanlisSesi, bitisSesi;
   
    private void Awake()
    {
        sureTextManager = Object.FindObjectOfType<sureTextManager>();
        dairelerManager = Object.FindObjectOfType<dairelerManager>();
        trueFalseManager = Object.FindObjectOfType<trueFalseManager>();
        

        audioSource = GetComponent<AudioSource>();

    }


    void Start()
    {
        kacinciOyun = 0;
        oyunSayac = 0;
        toplamPuan = 0;
        
        
        ustText.text = "?";
        altText.text = "?";
        puanText.text = "0";

        
        
        
        SahneEkraniniGuncelle();
    }

    void SahneEkraniniGuncelle()
    {
        puanSurePaneli.GetComponent<CanvasGroup>().DOFade(1, 1f);
        puaniKapYazisi.GetComponent<CanvasGroup>().DOFade(1, 1f);

        ustDikdortgen.GetComponent<RectTransform>().DOLocalMoveX(0, 1.5f).SetEase(Ease.OutBack);
        altDikdortgen.GetComponent<RectTransform>().DOLocalMoveX(0, 1.5f).SetEase(Ease.OutBack);

        koyuYesilDaireler.GetComponent<CanvasGroup>().DOFade(1, 1f);
        acikYesilDaireler.GetComponent<CanvasGroup>().DOFade(1, 1f);

        butonaBasilsinmi = false;
    }

    public void OyunaBasla()
    {
        audioSource.PlayOneShot(baslangicSesi);

        puaniKapYazisi.GetComponent<CanvasGroup>().DOFade(0, 0.2f);
        buyukOlanSayiSecYazisi.GetComponent<CanvasGroup>().DOFade(1, 0.2f);

        KacinciOyun();

        Invoke("ButonDegeriniBelirle", 3f);

        sureTextManager.SureyiBaslat();

        butonaBasilsinmi = true;
    }

    void KacinciOyun()
    {
        if (oyunSayac < 5)
        {
            kacinciOyun = 1;
            artisPuan = 25;
        } else if(oyunSayac>=5 && oyunSayac<10)
        {
            kacinciOyun = 2;
            artisPuan = 50;
        }
        else if (oyunSayac>=10 && oyunSayac<15)
        {
            kacinciOyun = 3;
            artisPuan = 75;
        }
        else if (oyunSayac >= 15 && oyunSayac < 20)
        {
            kacinciOyun = 4;
            artisPuan = 100;
        }
        else if (oyunSayac >= 20 && oyunSayac < 25)
        {
            kacinciOyun = 5;
            artisPuan = 125;
        }
        else
        {
            kacinciOyun = Random.Range(1, 6);
            artisPuan = 150;
        }

        switch (kacinciOyun)
        {
            case 1:
                BirinciFonksiyon();
                break;
            
            case 2:
                IkinciFonksiyon();
                break;
            
            case 3:
                UcuncuFonksiyon();
                break;
            
            case 4:
                DorduncuFonksiyon();
                break;
            
            case 5:
                BesinciFonksiyon();
                break;
        }
    }
        
    void BirinciFonksiyon()
    {
        int rastgeleDeger = Random.Range(1, 50);

        if (rastgeleDeger <= 25)
        {
            ustDeger = Random.Range(2, 50);
            altDeger = ustDeger + Random.Range(1, 15);
        }
        else
        {
            ustDeger = Random.Range(16, 50);
            altDeger = Mathf.Abs(ustDeger - Random.Range(1, 15));
        }

        if (ustDeger > altDeger)
        {
            buyukDeger = ustDeger;
        }
        else if(ustDeger<altDeger)
        {
            buyukDeger = altDeger;
        }

        if (ustDeger==altDeger)
        {
            BirinciFonksiyon();
            return;
        }
        

        ustText.text = ustDeger.ToString();
        altText.text = altDeger.ToString();

    }

    void IkinciFonksiyon()
    {
        int birinciSayi = Random.Range(1, 10);
        int ikinciSayi = Random.Range(1, 20);
        int ucuncuSayi = Random.Range(1, 10);
        int dortduncuSayi = Random.Range(1, 20);

        ustDeger = birinciSayi + ikinciSayi;
        altDeger = ucuncuSayi + dortduncuSayi;

        if (ustDeger>altDeger)
        {
            buyukDeger = ustDeger;
        }
        else if (altDeger>ustDeger)
        {
            buyukDeger = altDeger;
        }

        if (altDeger==ustDeger)
        {
            IkinciFonksiyon();
            return;
        }

        ustText.text = birinciSayi + " + " + ikinciSayi;
        altText.text = ucuncuSayi + " + " + dortduncuSayi;
    }

    void UcuncuFonksiyon()
    {
        int birinciSayi = Random.Range(11, 30);
        int ikinciSayi = Random.Range(1, 11);
        int ucuncuSayi = Random.Range(11, 40);
        int dortduncuSayi = Random.Range(1, 11);

        ustDeger = birinciSayi - ikinciSayi;
        altDeger = ucuncuSayi - dortduncuSayi;

        if (ustDeger > altDeger)
        {
            buyukDeger = ustDeger;
        }
        else if (altDeger > ustDeger)
        {
            buyukDeger = altDeger;
        }

        if (altDeger == ustDeger)
        {
            UcuncuFonksiyon();
            return;
        }

        ustText.text = birinciSayi + " - " + ikinciSayi;
        altText.text = ucuncuSayi + " - " + dortduncuSayi;
    }

    void DorduncuFonksiyon()
    {
        int birinciSayi = Random.Range(2, 10);
        int ikinciSayi = Random.Range(2, 10);
        int ucuncuSayi = Random.Range(2, 10);
        int dortduncuSayi = Random.Range(2, 10);

        ustDeger = birinciSayi * ikinciSayi;
        altDeger = ucuncuSayi * dortduncuSayi;

        if (ustDeger > altDeger)
        {
            buyukDeger = ustDeger;
        }
        else if (altDeger > ustDeger)
        {
            buyukDeger = altDeger;
        }

        if (altDeger == ustDeger)
        {
            DorduncuFonksiyon();
            return;
        }

        ustText.text = birinciSayi + " x " + ikinciSayi;
        altText.text = ucuncuSayi + " x " + dortduncuSayi;
    }

    void BesinciFonksiyon()
    {
        int bolen1 = Random.Range(2, 10);
        ustDeger = Random.Range(2, 10);

        int bolunen1 = bolen1 * ustDeger;

        int bolen2 = Random.Range(2, 10);
        altDeger = Random.Range(2, 10);

        int bolunen2 = bolen2 * altDeger;

        if (ustDeger > altDeger)
        {
            buyukDeger = ustDeger;
        }
        else if (altDeger > ustDeger)
        {
            buyukDeger = altDeger;
        }

        if (altDeger == ustDeger)
        {
            BesinciFonksiyon();
            return;
        }

        ustText.text = bolunen1 + " / " + bolen1;
        altText.text = bolunen2 + " / " + bolen2;
    }

    public void ButonDegeriniBelirle(string butonAdi)
    {
        if (butonaBasilsinmi)
        {
            if (butonAdi == "ustButon")
            {
                butonDegeri = ustDeger;
            }
            else if (butonAdi == "altButon")
            {
                butonDegeri = altDeger;
            }

            if (butonDegeri == buyukDeger)
            {

                dairelerManager.DairelerScaleAc(oyunSayac % 5);
                oyunSayac++;

                trueFalseManager.TrueFalseScaleAc(true);

                toplamPuan += artisPuan;

                puanText.text = toplamPuan.ToString();

                dogruAdet++;

                audioSource.PlayOneShot(dogruSesi);

                KacinciOyun();
            }
            else
            {
                HatayaGoreSayacAzalt();

                trueFalseManager.TrueFalseScaleAc(false);

                yanlisAdet++;

                audioSource.PlayOneShot(yanlisSesi);

                KacinciOyun();
            }
        }
    }

    void HatayaGoreSayacAzalt()
    {
        oyunSayac -= (oyunSayac % 5 + 5);

        if (oyunSayac<0)
        {
            oyunSayac = 0;
        }

        dairelerManager.DairelerScaleKapat();
    }

    public void PausePaneliniAc()
    {
        pausePaneli.SetActive(true);
    }

    public void OyunuBitir()
    {
        audioSource.PlayOneShot(bitisSesi);

        sonucPaneli.SetActive(true);

        sonucManager = Object.FindObjectOfType<sonucManager>();

        sonucManager.SonuclariGoster(dogruAdet, yanlisAdet, toplamPuan);
    }
}

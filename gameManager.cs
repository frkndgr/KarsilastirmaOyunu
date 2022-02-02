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
    private GameObject puaniKapYazisi;

    [SerializeField]
    private GameObject ustDikdortgen, altDikdortgen;

    [SerializeField]
    private Text ustText, altText;


    void Start()
    {
        ustText.text = "";
        altText.text = "";
        
        
        SahneEkraniniGuncelle();
    }

    void SahneEkraniniGuncelle()
    {
        puanSurePaneli.GetComponent<CanvasGroup>().DOFade(1, 1f);
        puaniKapYazisi.GetComponent<CanvasGroup>().DOFade(1, 1f);

        ustDikdortgen.GetComponent<RectTransform>().DOLocalMoveX(0, 1.5f).SetEase(Ease.OutBack);
        altDikdortgen.GetComponent<RectTransform>().DOLocalMoveX(0, 1.5f).SetEase(Ease.OutBack);
    }

    public void OyunaBasla()
    {
        ustText.text = "(30+20)-63";
        altText.text = "(30+20)-63";
        
        
        Debug.Log("oyun basladi");
    }

    
}

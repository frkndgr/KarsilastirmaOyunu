using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class geriSayimManager : MonoBehaviour
{
    [SerializeField]
    private GameObject GeriSayimObje;

    [SerializeField]
    private Text geriSayimText;

    gameManager gameManager;

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<gameManager>();
    }




    void Start()
    {
        StartCoroutine(GeriSayRoutune());
    }

    IEnumerator GeriSayRoutune()
    {
        geriSayimText.text = "3";
        yield return new WaitForSeconds(0.5f);

        GeriSayimObje.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(1f);
        GeriSayimObje.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.6f);

        geriSayimText.text = "2";
        yield return new WaitForSeconds(0.5f);

        GeriSayimObje.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(1f);
        GeriSayimObje.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.6f);

        geriSayimText.text = "1";
        yield return new WaitForSeconds(0.5f);

        GeriSayimObje.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(1f);
        GeriSayimObje.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.6f);

        StopAllCoroutines();

        gameManager.OyunaBasla();
    }

    
}

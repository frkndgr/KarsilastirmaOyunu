using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sureTextManager : MonoBehaviour
{
    [SerializeField]
    private Text sureText;

    int kalanSure;

    bool sureSaysinmi = true;

    gameManager gameManager;

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<gameManager>();
    }


    void Start()
    {
        kalanSure = 90;

        sureSaysinmi = true;
        
        
        
        
    }

    public void SureyiBaslat()
    {
        StartCoroutine(SureTimerRoutine());
    }

    IEnumerator SureTimerRoutine()
    {
        while (sureSaysinmi)
        {
            yield return new WaitForSeconds(1f);

            if (kalanSure<10)
            {
                sureText.text = "0" + kalanSure.ToString();
            }
            else
            {
                sureText.text = kalanSure.ToString();
            }

            if (kalanSure <= 0)
            {
                sureSaysinmi = false;
                sureText.text = "00";
                gameManager.OyunuBitir();
            }

            kalanSure--;
        }
    }

    
}

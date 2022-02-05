using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    [SerializeField]
    public Transform kafa;

    [SerializeField]
    public Transform startBtn;
    

    void Start()
    {
        kafa.transform.GetComponent<RectTransform>().DOLocalMoveX(0f, 1f).SetEase(Ease.OutBack);
        startBtn.transform.GetComponent<RectTransform>().DOLocalMoveY(-280f, 1f).SetEase(Ease.OutBack);
    }
    
    public void OyunaBasla()
    {
        SceneManager.LoadScene("GameLevel");
    }
    
}

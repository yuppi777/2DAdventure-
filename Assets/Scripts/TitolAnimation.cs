using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitolAnimation : MonoBehaviour
{
    [SerializeField] Text titolText;
    [SerializeField] Text pleaseClickText;
    void Start()
    {
       
        pleaseClickText.transform.DOScale(new Vector3(0f, 0f, 0), 0f);
        DOTitolText();
        DOFadeText();
    }

    private void DOTitolText()
    {
        titolText.transform.DOMoveY(920, 5f).SetEase(Ease.Linear).OnComplete(() => { DOGoTOClickText(); }).SetLink(gameObject); 
       
    }
    private void DOGoTOClickText()
    {
       pleaseClickText.transform.DOScale(new Vector3(1f, 1f, 0),1f);
    }
    private void DOFadeText()
    {
        pleaseClickText.DOFade(0, 1f)
        .SetLoops(-1, LoopType.Yoyo)
        .SetLink(gameObject)
        .SetEase(Ease.Linear);
    }
    public void OnclickScene()
    {
        SceneManager.LoadScene("ClubStage");
    }
}

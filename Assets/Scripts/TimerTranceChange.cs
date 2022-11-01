using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TimerTranceChange : MonoBehaviour
{
    [SerializeField] GameObject Timer;
    [SerializeField] SpriteRenderer PatLampFlash;
    [SerializeField] AudioClip PatLompSound;
    [SerializeField] MainControrrer mainControrrer;
    private AudioSource audioSource;

    private bool isClose = false;
    public bool isFlash = false; 

    private void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }
    public void TranceFormChange()
    {
        if (isClose==false)
        {
            Timer.transform.DOLocalMoveY(-545, 1f).SetLink(gameObject);
            
            isClose = true;
        }
       else
        {
            Timer.transform.DOLocalMoveY(-294, 1f).SetLink(gameObject);
            isClose = false;

        }
    }
   
    
    public void FlashPatLamp()
    {
        if (isFlash == true)
        {
            if (isClose == false)
            {
                PatLampFlash.gameObject.SetActive(false);

            }
            if(isClose == true)
            {
                PatLampFlash.gameObject.SetActive(true);
                audioSource.PlayOneShot(PatLompSound);
                Debug.Log("呼ばれた");
            }
        }
        
    }


}

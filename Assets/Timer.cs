using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text min;
    public Text sec;
    public AudioSource time;
    public AudioSource fifsec;
    public AudioSource fstmin;
    public AudioSource secmin;
    public AudioSource trdmin;
    public AudioSource fthmin;
    public GameObject startButton;
    public GameObject stopButton;

    public void onStartClick()
    {
        startButton.SetActive(false);
        stopButton.SetActive(true);
        StartCoroutine(onStart());
    }
    IEnumerator onStart()
    {
        for (int i = 0; i < 240; i++)
        {
            yield return new WaitForSeconds(1f);
            sec.text = (Int32.Parse(sec.text) - 1).ToString();
            if(sec.text.Equals("15"))
            {
                fifsec.Play();
            }
            if (sec.text.Equals("0"))
            {
                min.text = (Int32.Parse(min.text) + 1).ToString();
                sec.text = "60";
                if (min.text.Equals("1"))
                {
                    fstmin.Play();
                }
                else if (min.text.Equals("2"))
                {
                    secmin.Play();
                }
                else if (min.text.Equals("2"))
                {
                    secmin.Play();
                }
                else if (min.text.Equals("3"))
                {
                    trdmin.Play();
                }
                else if (min.text.Equals("4"))
                {
                    fthmin.Play();
                }
            }
        }
        min.text = "1";
        time.Play();
        startButton.SetActive(true);
        stopButton.SetActive(false);
    }
    public void stopTimer()
    {
        StopAllCoroutines();
        min.text = "1";
        sec.text = "60";
        startButton.SetActive(true);
        stopButton.SetActive(false);
    }
}

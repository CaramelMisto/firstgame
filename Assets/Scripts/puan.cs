using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class puan : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private AudioSource audio;

    public void Awake()
    {
        audio = GetComponent<AudioSource>();
        text.text= score.totalScore.ToString(); 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("elmas"))
        {
            audio.Play();
            Destroy(collision.gameObject);

            score.totalScore = score.totalScore + 10;
            text.text = score.totalScore.ToString();
        }
    }



}


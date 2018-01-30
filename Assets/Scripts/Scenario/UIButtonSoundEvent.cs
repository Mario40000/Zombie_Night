using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class UIButtonSoundEvent : MonoBehaviour
{
    public GameObject hover;
    public GameObject click;

    //Hacemos sonar los botones a traves de un event trigger
    public void HoverSound()
    {
        hover.GetComponent<AudioSource>().Play();
    }

    public void ClickSound()
    {
        click.GetComponent<AudioSource>().Play();
    }
}
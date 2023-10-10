using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleController : MonoBehaviour
{
    private Toggle toggleButton;
    private Image background;
    private Image checkMark;
    private int toggle = 0; //audio is on
    public GameObject player;
    private AudioSource[] sounds;

    // Start is called before the first frame update
    void Start()
    {
        toggleButton = GetComponent<Toggle>();
        background = toggleButton.transform.Find("Background").GetComponent<Image>();
        checkMark = background.transform.Find("Checkmark").GetComponent<Image>();
        sounds = player.GetComponents<AudioSource>();   //array of player sounds
    }

    public void OnValueChanged()
    {
        if (toggleButton.isOn)
        {
            toggle = 1; //audio is off
            background.enabled = false; //disable volume on
            checkMark.enabled = true;   //enable volume off
            foreach (AudioSource sound in sounds) sound.mute = true;    //mute each sound
        }
        else
        {
            toggle = 0; //audio back on
            background.enabled = true; //enable volume on
            checkMark.enabled = false; //disabled volume off
            foreach (AudioSource sound in sounds) sound.mute = false;   //unmute each sound
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class volControl : MonoBehaviour
{
    public AudioMixer mixer;

    public void SetLevel (float volume)
    {
        mixer.SetFloat("BGM", 20.0f * Mathf.Log10(volume));
    }
}

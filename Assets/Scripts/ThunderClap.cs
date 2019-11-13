using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderClap : MonoBehaviour
{
    new Light light;
    new public AudioClip audioClip;
    AudioSource source;
    bool canFlicker = true;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        if (canFlicker)
        {
            canFlicker = false;
            source.PlayOneShot(audioClip, .7f);
            light.enabled = true;
            yield return new WaitForSeconds(Random.Range(.1f, .4f));
            light.enabled = false;
            yield return new WaitForSeconds(Random.Range(.1f, 5f));
            canFlicker = true;
        }
    }
}

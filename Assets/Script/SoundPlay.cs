using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlay : MonoBehaviour
{
    public AudioSource source;
    // Start is called before the first frame update
    public void PlaySound(Collider other)
    {
        source.Play();
        Destroy(other.gameObject);
    }
}

/** ShrinkingPlatformBehaviour - Jake Treleaven - 101186632 - 2020/12/16 **/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkingPlatformBehaviour : MonoBehaviour
{
    public bool isActive;
    public float shrinkSpeed;
    public AudioSource shrinkAudio;
    public AudioSource growAudio;

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            _Shrink();
        }
        else
        {
            _UnShrink();
        }
    }


    private void _Shrink()
    {
        if (transform.localScale != Vector3.zero)
        {
            //Sound
            if (!shrinkAudio.isPlaying) { shrinkAudio.Play(); }
            //Shrink
            float size = shrinkSpeed * Time.deltaTime;
            transform.localScale -= new Vector3(size, size, size);
            //Reached Min Size
            if (transform.localScale.x < 0)
            {
                transform.localScale = Vector3.zero;
                shrinkAudio.Stop();
            }
        }
    }

    private void _UnShrink()
    {
        if (transform.localScale != Vector3.one)
        {
            //Sound
            if (!growAudio.isPlaying) { growAudio.Play(); }
            //Shrink
            float size = shrinkSpeed * Time.deltaTime;
            transform.localScale += new Vector3(size, size, size);
            //Reach Max Size
            if (transform.localScale.x > 1)
            {
                transform.localScale = Vector3.one;
                growAudio.Stop();
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isActive = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isActive = false;
        }
    }
}

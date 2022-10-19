using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSound : MonoBehaviour
{
    

    private void Start()
    {
        AudioManager.Instance.PlayMusic("Music");
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioManager.Instance.PlaySFX("Jump");
        }
    }
}

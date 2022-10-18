using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
	public bool playerJoined;
	public GameObject pressAny;
	
    // Start is called before the first frame update
    void Start()
    {
		playerJoined = false;
        Time.timeScale = 0f;
		pressAny.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerJoined){Time.timeScale = 1f;
		pressAny.SetActive(false);}
    }
}

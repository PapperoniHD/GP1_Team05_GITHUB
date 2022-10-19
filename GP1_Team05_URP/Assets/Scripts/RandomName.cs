using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomName : MonoBehaviour
{

    public string[] firstNames;
    public string[] lastNames;

    private string _firstName;
    private string _lastName;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _firstName = firstNames[Random.Range(0, firstNames.Length)];
        _lastName = lastNames[Random.Range(0, lastNames.Length)];
        
        print(_firstName + " " + _lastName);
    }
}

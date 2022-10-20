using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionScript : MonoBehaviour
{
    [SerializeField] private ParticleSystem death;
    // Start is called before the first frame update
    void Start()
    {
        death.Play();
    }
}

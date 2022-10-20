using System.Collections;
using System.Collections.Generic;
using ElliotsSpawnerAndShader.ElliotsSpawnerAndShader.SpawnerProto;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundSlider : MonoBehaviour
{
    private Slider _slider;
    private Score score;

    public Material p1Material;
    
    public Material p2Material;

    private DeathManager _deathManager;
    
    // Start is called before the first frame update
    void Start()
    {
        _deathManager = FindObjectOfType<DeathManager>().GetComponent<DeathManager>();
        //Reset mat to base in case of bug
        p1Material.SetTextureOffset("_BaseMap", new Vector2(0, 0));
        
        _slider = GetComponentInChildren<Slider>();
        score = FindObjectOfType<Score>().GetComponent<Score>();
        
        _slider.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (_deathManager.playerAlive > 1)
        {
            _slider.gameObject.SetActive(true);
        }
        
        
        _slider.minValue = -score.playerOneScore;
        _slider.maxValue = score.playerTwoScore;
        
        _slider.value = 0;

        //Calculate the score into a variable between 0 and 1 and then multiply by 0.5 to get a value between 0 and 0.5
        var percent = 0.6f;
        var playerOneOffset = percent*(score.playerOneScore / (score.playerOneScore + score.playerTwoScore));
        var playerTwoOffset = percent*(score.playerTwoScore / (score.playerOneScore + score.playerTwoScore));
        //Apply new offset to material
        p1Material.SetTextureOffset("_BaseMap", new Vector2(0, playerOneOffset));
        p2Material.SetTextureOffset("_BaseMap", new Vector2(0, playerTwoOffset));
    }
}

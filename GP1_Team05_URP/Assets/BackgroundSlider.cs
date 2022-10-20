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
        
    // Start is called before the first frame update
    void Start()
    {
        //Reset mat to base in case of bug
        p1Material.SetTextureOffset("_BaseMap", new Vector2(0, 0));
        
        _slider = GetComponent<Slider>();
        score = FindObjectOfType<Score>().GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
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

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
        _slider = GetComponent<Slider>();
        score = FindObjectOfType<Score>().GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        _slider.minValue = -score.playerOneScore;
        _slider.maxValue = score.playerTwoScore;
        
        _slider.value = 0;

        var p1Offset = 0.5f*(score.playerOneScore / (score.playerOneScore + score.playerTwoScore));
        p1Material.SetTextureOffset("_BaseMap", new Vector2(0, p1Offset));
    }
}

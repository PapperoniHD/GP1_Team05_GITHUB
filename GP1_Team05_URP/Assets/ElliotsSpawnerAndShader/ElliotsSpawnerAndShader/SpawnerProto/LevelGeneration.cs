
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGeneration : MonoBehaviour
{
    [SerializeField] private GameObject[] _waterPlanePrefab;

    [SerializeField] private float _waterHeight;
    [SerializeField] private float _tiles;
    [SerializeField] private float _emptyPlanes = 2f;

    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _speedIncrease;
    [SerializeField] private float _startSpeeed;
    private GameObject _currentPlane;
    private float _planeLength;
    private Rigidbody _planeRigid;

    public float globalSpeed;

    private void Awake()
    {
        globalSpeed += _startSpeeed;
        _planeLength = (_waterPlanePrefab[0].transform.GetChild(0).GetComponent<Renderer>().bounds.size.z)-5;

        for (int i = 0; i < _tiles; i++)
        {
            if (i <= _emptyPlanes-1)
            {
                GeneratePlane(-_planeLength*(_tiles-i),0,0);
            } else {
                GeneratePlane(-_planeLength*(_tiles-i),1,_waterPlanePrefab.Length);
            }
        }
    }

    private void Update()
    {
        if (_currentPlane.transform.position.z <= 0+_planeLength*(_tiles-1))
        {
            GeneratePlane(0,1,_waterPlanePrefab.Length);
        }
        if (globalSpeed <= _maxSpeed) globalSpeed += _speedIncrease * Time.deltaTime;
        globalSpeed = Mathf.Clamp(globalSpeed, 0, _maxSpeed);
    }

    private void GeneratePlane(float offset,int range1, int range2)
    {
        _currentPlane = Instantiate(_waterPlanePrefab[Random.Range(range1,range2)],
            new Vector3(0, _waterHeight, 0+(_planeLength*_tiles)+offset),
            Quaternion.identity);
    }
}
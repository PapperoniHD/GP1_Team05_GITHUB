using UnityEngine;
public class PlaneBehaviour : MonoBehaviour
{

    private LevelGeneration _generation;

    private Rigidbody _rigidbody;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _generation = FindObjectOfType<LevelGeneration>().GetComponent<LevelGeneration>();
    }

    void Update()
    {
        if (transform.position.z <= -150)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (_generation != null)
        {
            var speed = _generation.globalSpeed;
            _rigidbody.velocity = new Vector3(0, 0, -speed);
        }
    }
}

using UnityEngine;

namespace ElliotsSpawnerAndShader.ElliotsSpawnerAndShader.SpawnerProto
{
    public class PlaneBehaviour : MonoBehaviour
    {
    
        private LevelGeneration _generation;
    
        private Rigidbody _rigidbody;
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _generation = FindObjectOfType<LevelGeneration>().GetComponent<LevelGeneration>();
            
            //Set speed on awake to avoid issues from fixed update
            var speed = _generation.globalSpeed;
            _rigidbody.velocity = new Vector3(0, 0, -speed);
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
            var speed = _generation.globalSpeed;
            _rigidbody.velocity = new Vector3(0, 0, -speed);
        }
    }
}

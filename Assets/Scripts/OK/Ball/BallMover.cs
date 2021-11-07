
    using UnityEngine;

    public class BallMover : MonoBehaviour
    {
        private float _speed;

        public void Init(float speed)
        {
            _speed = speed;
        }
        
        private void Update()
        {
            Move();
        }

        private void Move()
        {
            transform.Translate(Vector3.down * (_speed * Time.deltaTime));
        }
    }

using UnityEngine;
using Random = UnityEngine.Random;

public class BallRotating : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private Vector3 _rotateAmount;
    [SerializeField] private float _randomAngle = 25f;
    
    private void Start()
    {
        InitRandomAngle();
    }

    private void InitRandomAngle()
    {
        var randomAngle = Random.Range(-_randomAngle, _randomAngle);
        transform.eulerAngles = new Vector3(0f, 0f, randomAngle);
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(_rotateAmount * (_rotateSpeed * Time.deltaTime));
    }

}
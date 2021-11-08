using UnityEngine;

public class BallRotater : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private Vector3 _rotateAmount;

    public void Init(Vector3 angle)
    {
        transform.eulerAngles = angle;
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
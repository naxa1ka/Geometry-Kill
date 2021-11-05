using UnityEngine;

public class EdgeDetector
{
    private readonly Camera _camera;
    
    public EdgeDetector(Camera camera)
    {
        _camera = camera;
    }

    public bool IsOutsideEdge(Vector3 position)
    {
        Vector3 pos = _camera.WorldToViewportPoint(position);

        return (pos.y < 0f || pos.y > 1f || pos.x > 1f || pos.x < 0f);
    }
}
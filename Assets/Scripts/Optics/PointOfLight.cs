using UnityEngine;

public class PointOfLight : MonoBehaviour
{
    [SerializeField] private Transform _ray, _lens;
    [SerializeField] private float _maxLength, _distance;

    private void Start() =>_ray.localScale = new Vector2(_maxLength, _ray.localScale.y);

    private void FixedUpdate() => _ray.localScale = new Vector2(Vector2.Distance(transform.position, _lens.position), _ray.localScale.y);
}

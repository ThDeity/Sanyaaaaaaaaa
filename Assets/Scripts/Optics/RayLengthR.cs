using UnityEngine;

public class RayLengthR : MonoBehaviour
{
    [SerializeField] private Transform _parent, _focusPosit, _focusNegat, _secondRay, _endPoint;
    [SerializeField] private float _k, _f, _offset;
    Transform _transform;

    private void Start() => _transform = transform;

    private void FixedUpdate()
    {
        _transform.localScale = new Vector2((float)(Mathf.Abs(_transform.position.x) / Mathf.Abs(Mathf.Cos(_parent.eulerAngles.z * Mathf.Deg2Rad)) * _k),
                                            _transform.localScale.y);


    }
}

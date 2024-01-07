using UnityEngine;

public class RotatingBody : MonoBehaviour
{
    [SerializeField] private float _offset;
    private Transform _transform;
    private Vector3 difference;
    private float roatZ;

    private void Start() => _transform = transform;

    private void FixedUpdate()
    {
        difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - _transform.position;
        roatZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        _transform.rotation = Quaternion.Euler(0f, 0f, roatZ + _offset);
    }
}

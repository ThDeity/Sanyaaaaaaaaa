using UnityEngine;

public class RayLength : MonoBehaviour
{
    [SerializeField] private Transform _parent, _focusPosit, _focusNegat, _secondRay, _endPoint;
    [SerializeField] private float _k, _f, _offset;
    Transform _transform;
    private Lens _lens;

    private void Start()
    {
        _transform = transform;
        _lens = FindObjectOfType<Lens>();
    }

    private void FixedUpdate()
    {
        _transform.localScale = new Vector2((float) (Mathf.Abs(_transform.position.x) / Mathf.Abs(Mathf.Cos(_parent.eulerAngles.z * Mathf.Deg2Rad)) * _k),
                                            _transform.localScale.y);

        if (_lens.isÑollecting)
        {
            _secondRay.position = new Vector2(_focusPosit.position.x,
                                 _focusPosit.position.x * Mathf.Tan(_parent.eulerAngles.z * Mathf.Deg2Rad));
        }
        else
        {
            _secondRay.position = new Vector2(_focusPosit.position.x, _focusPosit.position.x / Mathf.Cos(_parent.eulerAngles.z * Mathf.Deg2Rad));
        }

        Vector2 dif = _endPoint.position - _secondRay.position;
        dif.Normalize();
        float rotZ = Mathf.Atan2(dif.y, dif.x) * Mathf.Rad2Deg;
        _secondRay.rotation = Quaternion.Euler(0, 0, rotZ - _offset);
        _secondRay.localScale = new Vector2((float)(Mathf.Abs(_focusNegat.position.x) / Mathf.Abs(Mathf.Cos(_secondRay.eulerAngles.z * Mathf.Deg2Rad))) * _f,
                                            _secondRay.localScale.y);

        bool isActive = _parent.rotation.z > -90 ? true : false;
        _secondRay.gameObject.SetActive(isActive);
    }
}

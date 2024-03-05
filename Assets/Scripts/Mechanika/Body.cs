using UnityEngine;

public class Body : MonoBehaviour
{
    public bool isSelected = false, isImpulsed;
    private Rigidbody2D _body2D;
    private Vector3 _position;
    [SerializeField] private float _force, _offset;
    [SerializeField] private Transform _arrow;
    bool _isCursor = false;

    private void Start()
    {
        _body2D = GetComponent<Rigidbody2D>();
        if (isImpulsed)
            _arrow.gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        StaticVariables.ChooseBody(gameObject, true);
        isSelected = true;
    }

    private void FixedUpdate()
    {
        if (isImpulsed)
        {
            if (isSelected && Input.GetMouseButtonDown(1))
            {
                _isCursor = true;
                _arrow.gameObject.SetActive(true);
            }

            if (_isCursor)
            {
                _position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var difference = _position - transform.position;
                float roatZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
                _arrow.rotation = Quaternion.Euler(0f, 0f, roatZ + _offset);
                Debug.DrawRay(transform.position, difference, Color.red);
            }

            if (isSelected && Input.GetMouseButtonUp(1))
            {
                _arrow.gameObject.SetActive(false);
                _body2D.bodyType = RigidbodyType2D.Dynamic;
                var difference = _position - transform.position;
                _body2D.AddForce(difference.normalized * _force, ForceMode2D.Impulse);
                isSelected = false;
                StaticVariables.ChooseBody(null, false);
                _isCursor = false;
            }
        }
    }
}

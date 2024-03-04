using UnityEngine;

public class Focus : MonoBehaviour
{
    [SerializeField] private Transform _focus2, _lens;
    [SerializeField] private bool isFocusXNegative = false;
    private Transform _transform;
    private bool _isDragging = false;

    private void OnMouseDown()
    {
        _isDragging = true;
        _transform = transform;
    }

    private void OnMouseUp() => _isDragging = false;

    private void Update()
    {
        if (_isDragging)
        {
            Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if ((isFocusXNegative && mouse.x < _lens.position.x) || (!isFocusXNegative && mouse.x > _lens.position.x))
            {
                _transform.position = new Vector2(mouse.x, _transform.position.y);
                _focus2.position = new Vector2(-mouse.x, _transform.position.y);
            }
        }
    }
}

using UnityEngine;

public class TransforManager : MonoBehaviour
{
    private Camera _myCam;

    private float _startXPos;
    private float _startYPos;

    private bool _isDragging = false;

    private void Start() => _myCam = Camera.main;

    private void Update()
    {
        if (_isDragging)
            DragObject();
    }

    private void OnMouseDown()
    {
        Vector3 mousePos = Input.mousePosition;

        if (!_myCam.orthographic)
            mousePos.z = 10;

        mousePos = _myCam.ScreenToWorldPoint(mousePos);

        _startXPos = mousePos.x - transform.localPosition.x;
        _startYPos = mousePos.y - transform.localPosition.y;

        _isDragging = true;
    }

    private void OnMouseUp()
    {
        _isDragging = false;
    }

    public void DragObject()
    {
        Vector3 mousePos = Input.mousePosition;

        if (!_myCam.orthographic)
            mousePos.z = 10;

        mousePos = _myCam.ScreenToWorldPoint(mousePos);
        transform.localPosition = new Vector3(mousePos.x - _startXPos, mousePos.y - _startYPos, transform.localPosition.z);
    }
}

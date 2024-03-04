using UnityEngine;
using UnityEngine.UI;

public class Lens : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    private Dropdown _field;
    public bool is—ollecting = true;

    private void Start()
    {
        _panel.SetActive(false);
        _field = _panel.GetComponentInChildren<Dropdown>();
    }

    private void OnMouseDown() =>_panel.SetActive(true);

    public void Close() => _panel.SetActive(false);

    public void Change() => is—ollecting = _field.value == 0 ? true : false;
}

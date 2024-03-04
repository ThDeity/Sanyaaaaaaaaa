using UnityEngine;
using UnityEngine.UI;

public class CheckE : MonoBehaviour
{
    [SerializeField] private GameObject _checkPanel;
    private Text _text;
    private ChargedBody _body;
    private Transform _electricField;

    private void Start()
    {
        _checkPanel.SetActive(false);
        _text = _checkPanel.GetComponentInChildren<Text>();
        _body = FindObjectOfType<ChargedBody>();
        _electricField = ElectricFieldInfo.ElectricField.transform;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _checkPanel.transform.position = new Vector3(pos.x, pos.y, 0);
            _text.text = StaticVariables.IsEConst ? StaticVariables.EValue.ToString() : (_body.Charge * _body.k / Vector2.Distance(_electricField.position, pos)).ToString();
            _checkPanel.SetActive(!_checkPanel.activeSelf);
        }
    }
}

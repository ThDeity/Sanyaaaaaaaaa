using UnityEngine;

public class WriteText : MonoBehaviour
{
    [SerializeField] private GameObject _inputField;

    private void Start() => _inputField.SetActive(false);

    public void OpenCloseText() => _inputField.SetActive(!_inputField.activeInHierarchy);
}

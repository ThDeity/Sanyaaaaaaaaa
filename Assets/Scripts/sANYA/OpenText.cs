using UnityEngine;

public class OpenText : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    private void Start() => _panel.SetActive(false);

    public void OpenAndzClose() => _panel.SetActive(!_panel.activeInHierarchy);
}

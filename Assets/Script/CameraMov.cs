using UnityEngine;

public class CameraMov : MonoBehaviour
{
    [SerializeField]
    private Transform _playerTransform;
    [SerializeField]
    private Transform _cameraTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        _cameraTransform.position = _playerTransform.position;
    }
}

using TopDownShooter;
using UnityEngine;
using Zenject;

[RequireComponent (typeof(LineRenderer))]
public class LaserPointerComponent : MonoBehaviour
{
    [Inject]
    private InputManager _inputManager;
    private LineRenderer _lineRenderer;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }
    private void Update()
    {
        Vector3 targetPosition = _inputManager.GetRaycastHit().point;
        _lineRenderer.SetPosition(0, transform.position);
        _lineRenderer.SetPosition(1, targetPosition);
    }
}

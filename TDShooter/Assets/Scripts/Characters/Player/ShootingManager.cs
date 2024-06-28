using TopDownShooter;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootingManager
{
    private InputManager _inputManager;
    private InventoryComponent _inventoryComponent;
    private LineRenderer _lineRenderer;
    private Transform _transform;
    private Ray _ray;

    public ShootingManager(InputManager inputManager, InventoryComponent inventoryComponent, LineRenderer lineRenderer, Transform transform) 
    {
        _inputManager = inputManager;
        _inventoryComponent = inventoryComponent;
        _lineRenderer = lineRenderer;
        _transform = transform;
        _ray = new();
    }

    private void Shoot()
    {
        if (_inputManager.FireAction.IsPressed())
        {
            _inventoryComponent.CurrentWeapon.Shoot();
        }
    }

    public void Update()
    {
        DrawLaserPointer();
        DrawDetectionRay();
        Shoot();
    }

    private void DrawLaserPointer()
    {
        float distance;

        if (Physics.Raycast(_ray, out RaycastHit hitInfo))
        {
            distance = hitInfo.distance;
        }
        else
        {
            distance = Vector3.Distance(_ray.origin, _ray.direction * 20f);
        }

        Vector3 direction = _inventoryComponent.CurrentWeapon.Muzzle.position + _inventoryComponent.CurrentWeapon.Muzzle.forward * distance;
        _lineRenderer.SetPosition(0, _inventoryComponent.CurrentWeapon.Muzzle.position);
        _lineRenderer.SetPosition(1, direction);
    }

    private void DrawDetectionRay()
    {
        _ray.origin = _inventoryComponent.CurrentWeapon.Muzzle.position;
        _ray.direction = _inventoryComponent.CurrentWeapon.Muzzle.forward;
    }


}

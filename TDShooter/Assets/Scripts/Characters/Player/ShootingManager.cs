using System.Collections;
using System.Collections.Generic;
using TopDownShooter;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootingManager
{
    private InputManager _inputManager;
    private InventoryComponent _inventoryComponent;
    private LineRenderer _lineRenderer;
    private Transform _transform;
    //private Ray _ray;

    public ShootingManager(InputManager inputManager, InventoryComponent inventoryComponent, LineRenderer lineRenderer, Transform transform) 
    {
        _inputManager = inputManager;
        _inputManager.FireAction.performed += Shoot;
        _inventoryComponent = inventoryComponent;
        _lineRenderer = lineRenderer;
        _transform = transform;
        //_ray = new();
    }

    private void Shoot(InputAction.CallbackContext obj)
    {
        if (_inputManager.FireAction.IsPressed())
        {
            //var target = _inputManager.GetRaycastHit();
            //if (target.transform.TryGetComponent<IDamageable>(out IDamageable DamageableEntity))
            //{
            //    DamageableEntity.TakeDamage(1);
            //    Debug.Log("TakeDamege");
            //}
        }
    }

    public void Update()
    {
        DrawLaserPointer();
        
    }

    private void DrawLaserPointer()
    {
        _lineRenderer.SetPosition(0, _inventoryComponent.CurrentWeapon.Muzzle.position);
        Vector3 direction = _inventoryComponent.CurrentWeapon.Muzzle.position + _inventoryComponent.CurrentWeapon.Muzzle.forward * 10;
        _lineRenderer.SetPosition(1, direction);


        //_ray.origin = _inventoryComponent.CurrentWeapon.Muzzle.position;
        //_ray.direction = _inventoryComponent.CurrentWeapon.Muzzle.forward;
        //Debug.DrawRay(_ray.origin, _ray.direction, Color.magenta);
    }


}

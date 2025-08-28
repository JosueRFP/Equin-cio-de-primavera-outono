using System.Collections;
using UnityEngine;

public enum ChangeWeapon
{
    None, Knife, Gun
}

public class WaponManeger : MonoBehaviour
{
    [SerializeField] ChangeWeapon _changeWeapon;

    Transform rayCastOrigin;
    IHitable target;
    float distance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rayCastOrigin = Camera.main.transform;
        ChangeWealdingWeapon(ChangeWeapon.None);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(rayCastOrigin.position, rayCastOrigin.forward * 10, Color.red);

        if (Input.GetButtonDown("Fire1"))
            target?.Hit();
    }

    private void FixedUpdate()
    {
        if(Physics.Raycast(rayCastOrigin.position, rayCastOrigin.forward, out RaycastHit hit, distance))
        {
            if (hit.collider.TryGetComponent(out IHitable target))
            {
                this.target = target;
            }
            else 
            { 
                this.target = null;
            }
        }
    }

    private void ChangeWealdingWeapon(ChangeWeapon mode)
    {
        switch (mode) 
        {
            case ChangeWeapon.None:
                break;
            case ChangeWeapon.Gun:
                break; 
            case ChangeWeapon.Knife:
                break;
        }
    }
}

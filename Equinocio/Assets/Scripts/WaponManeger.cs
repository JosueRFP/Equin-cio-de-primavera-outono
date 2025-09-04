using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public enum ChangeWeapon
{
    None, Knife, Gun
}

public class WaponManeger : MonoBehaviour
{
    [SerializeField] UnityEvent OnSniperSound;
    [SerializeField] ChangeWeapon _changeWeapon;
    [SerializeField] float weaponDistance;
    [SerializeField] float knifeDistance;
    [SerializeField] float distance;

    Transform rayCastOrigin;
    IHitable target;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rayCastOrigin = Camera.main.transform;
        ChangeWealdingWeapon(ChangeWeapon.None);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(rayCastOrigin.position, rayCastOrigin.forward * 100, Color.red);

        if (Input.GetButtonDown("Fire1"))
        {
            target?.Hit();
            OnSniperSound.Invoke();
            
            

        }

        if (Input.GetKeyDown(KeyCode.E)) 
        {
            ChangeWealdingWeapon(ChangeWeapon.Gun);
        }
            

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeWealdingWeapon(ChangeWeapon.Gun);

        }
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
                distance = weaponDistance *10;
                break; 
            case ChangeWeapon.Knife:
                distance = knifeDistance;
                break;
        }
    }
}

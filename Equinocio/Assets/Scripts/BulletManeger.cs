using TMPro;
using UnityEngine;



public class BulletManeger : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _bulletText;
    [SerializeField] int _bulletQtdMax;
    [SerializeField] int _bulletQtd = 15;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _bulletQtd = _bulletQtdMax;
    }

    public void FireBullet()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _bulletQtd--;
            UpdateBulletCount();
        }        
    }
    
    // Update is called once per frame
    void UpdateBulletCount()
    {
        _bulletText.text = "Munição" + _bulletQtd;
        _bulletText.color = Color.black;

        if(_bulletQtd == 0)
            return;
        
    }
}

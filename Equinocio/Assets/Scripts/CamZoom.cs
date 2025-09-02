using Cinemachine;
using System.Collections;
using UnityEngine;

public class CamZoom : MonoBehaviour
{
    CinemachineVirtualCamera virtualCam;
    [SerializeField] float gunFov;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        virtualCam = GetComponent<CinemachineVirtualCamera>();
        GameController.instance.OnZoom.AddListener(delegate
        {
            StartCoroutine(ZoomIn());

        });

        GameController.instance.OnZoom.AddListener(delegate
        {
            StartCoroutine(ZoomOut());

        });
        
        
        
        
        
        
    }

    IEnumerator ZoomIn()
    {
        while (virtualCam.m_Lens.FieldOfView > gunFov)
        {
           virtualCam.m_Lens.FieldOfView -= 0.5f;
           yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator ZoomOut() 
    {
        while (virtualCam.m_Lens.FieldOfView < gunFov)
        {
            virtualCam.m_Lens.FieldOfView += 1f;
            yield return new WaitForSeconds(0.01f);
        }


    }
    
}

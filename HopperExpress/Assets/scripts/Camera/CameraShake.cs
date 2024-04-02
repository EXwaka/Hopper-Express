using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEditorInternal;

public class CameraShake : MonoBehaviour
{
    private CinemachineVirtualCamera m_camera;
    private float ShakeIntensity = 1f;
    private float ShakeTime = 1f;

    private float timer = 0;
    private CinemachineBasicMultiChannelPerlin m_cbmcp;
    // Start is called before the first frame update

    void Awake()
    {
        m_camera=GetComponent<CinemachineVirtualCamera>();
    }
    public void ShakeCamera()
    {
        CinemachineBasicMultiChannelPerlin m_cbmcp = m_camera.GetComponent<CinemachineBasicMultiChannelPerlin>();
        m_cbmcp.m_AmplitudeGain = ShakeIntensity;
        timer = ShakeTime;
    }
    void StopShake()
    {
        CinemachineBasicMultiChannelPerlin m_cbmcp = m_camera.GetComponent<CinemachineBasicMultiChannelPerlin>();
        m_cbmcp.m_AmplitudeGain = 0;
        timer = 0;
    }
    void Update()
    {
        //ShakeCamera();
        if(FinishPoint.LevelComplete==true) 
        {
            StopShake();
        
        }
        else
        {
            ShakeCamera();
        }
    }
}

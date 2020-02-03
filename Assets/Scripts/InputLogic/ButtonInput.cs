using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ButtonInput : MonoBehaviour
{
    [SerializeField] private Camera _Cam;
    [SerializeField] private AudioSource _AudioSource;
    [SerializeField] private RadioController _RadioController;
    private SphereCollider _ButtonCollider;
    private bool _IsPlaying = true;

    private void Awake()
    {
        _ButtonCollider = GetComponent<SphereCollider>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        
        var ray = _Cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit) == false) return;
        if (hit.transform.GetComponent<SphereCollider>() != _ButtonCollider || Input.GetMouseButtonDown(0) == false) return;
        _AudioSource.Play();
        if (_IsPlaying == true)
        {
            _IsPlaying = false;
            _RadioController.gameObject.SetActive(false);
        }
        else
        {
            _IsPlaying = true;
            _RadioController.gameObject.SetActive(true);
        }
        
    }


}

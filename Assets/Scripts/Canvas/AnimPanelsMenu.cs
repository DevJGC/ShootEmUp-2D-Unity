using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPanelsMenu : MonoBehaviour
{
    // reference anim panel logo
    [SerializeField] Animator panelLogo;
    // reference anim panel menu
    [SerializeField] Animator panelMenu;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // exit panel menu trigger Exit
    public void ExitAnimMenu()
    {
        // play anim panel logo
        panelLogo.SetTrigger("Exit");
        // play anim panel menu
        panelMenu.SetTrigger("Exit");

    }
}

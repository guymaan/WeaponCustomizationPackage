using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [Header("Weapons")]
    [SerializeField] 
    private GameObject weapon1;
    [SerializeField] 
    private GameObject weapon2;
    [SerializeField]
    private GameObject weapon3;

    private GameObject mainMenuObject;
    private GameObject statBox;
    private CustomizationManager customizationManager;
    private GameObject canvas;

    public void Start()
    {
        customizationManager = this.GetComponent<CustomizationManager>();
        canvas = GameObject.FindGameObjectWithTag("WeaponCustomizationCanvas");
        mainMenuObject = canvas.transform.Find("MainMenu").gameObject;
        statBox = canvas.transform.Find("StatBG").gameObject;
    }

    public void SelectWeapon1()
    {
        customizationManager.currentWeapon = weapon1.GetComponent<WeaponScript>();
        Instantiate(weapon1, new Vector3(), Quaternion.identity);
        mainMenuObject.SetActive(false);
        statBox.SetActive(true);
        EventController.Instance.onChosenWeapon.Invoke();
    }

    public void SelectWeapon2()
    {
        customizationManager.currentWeapon = weapon2.GetComponent<WeaponScript>();
        Instantiate(weapon2, new Vector3(), Quaternion.identity);
        mainMenuObject.SetActive(false);
        statBox.SetActive(true);
        EventController.Instance.onChosenWeapon.Invoke();
    }

    public void SelectWeapon3()
    {
        customizationManager.currentWeapon = weapon3.GetComponent<WeaponScript>();
        Instantiate(weapon3, new Vector3(), Quaternion.identity);
        mainMenuObject.SetActive(false);
        statBox.SetActive(true);
        EventController.Instance.onChosenWeapon.Invoke();
    }
}

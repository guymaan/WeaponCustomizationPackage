using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CustomizationManager : MonoBehaviour
{

    [Header("Attachment Arrays")]
    public GameObject[] barrelAttachments;
    public GameObject[] magazineAttachments;
    public GameObject[] stockAttachments;
    public GameObject[] sightAttachments;
    public GameObject[] gripAttachments;

    public WeaponScript currentWeapon;

    private Dropdown dropdown;

    private GameObject canvas;

    private TextMeshProUGUI[] tempText;

    private TMP_Dropdown[] tempDrops;

    void Awake()
    {
        barrelAttachments = Resources.LoadAll<GameObject>("attachments/barrelAttachments");
        magazineAttachments = Resources.LoadAll<GameObject>("attachments/MagazineAttachments");
        stockAttachments = Resources.LoadAll<GameObject>("attachments/StockAttachments");
        sightAttachments = Resources.LoadAll<GameObject>("attachments/SightAttachments");
        gripAttachments = Resources.LoadAll<GameObject>("attachments/GripAttachments");

        dropdown = this.gameObject.GetComponent<Dropdown>();

        canvas = GameObject.FindGameObjectWithTag("WeaponCustomizationCanvas");

        EventController.Instance.onStart.AddListener(InitializeDropdowns);
        EventController.Instance.onStart.AddListener(InitializeStatTexts);
    }

    public void InitializeStatTexts()
    {
        tempText = canvas.transform.Find("StatBG/Stats").GetComponentsInChildren<TextMeshProUGUI>();

        foreach (var item in tempText)
        {
            switch (item.gameObject.name)
            {
                case "FireRateText":
                    dropdown.fireRateText = item;
                    break;
                case "AimDownSSText":
                    dropdown.aimDownSightSpeedText = item;
                    break;
                case "HoriRecoilText":
                    dropdown.horizontalRecoilText = item;
                    break;
                case "VertRecoilText":
                    dropdown.verticalRecoilText = item;
                    break;
                case "ReloadSpeedText":
                    dropdown.reloadSpeedText = item;
                    break;
                case "BulletVeloText":
                    dropdown.bulletVelocityText = item;
                    break;
                case "BulletDropText":
                    dropdown.bulletDropText = item;
                    break;
                case "WeightText":
                    dropdown.weightText = item;
                    break;
                default:
                    break;
            }
        }
    }

    public void InitializeDropdowns()
    {
        tempDrops = canvas.transform.Find("Dropdowns").GetComponentsInChildren<TMP_Dropdown>();

        foreach (var item in tempDrops)
        {
            switch (item.gameObject.name)
            {
                case "BarrelDropdown":
                    dropdown.BarrelDrop = item;
                    break;
                case "MagDropdown":
                    dropdown.MagDrop = item;
                    break;
                case "StockDropdown":
                    dropdown.StockDrop = item;
                    break;
                case "SightDropdown":
                    dropdown.SightDrop = item;
                    break;
                case "GripDropdown":
                    dropdown.GripDrop = item;
                    break;
                default:
                    break;
            }
        }
    }

    private void Update()
    {
        if (currentWeapon != null)
        {
            SpawnDropdowns();
        }
    }

    public void SpawnDropdowns()
    {
        if (!currentWeapon.hasBarrelSlot)
        {
            dropdown.BarrelDrop.gameObject.SetActive(false);
        }

        if (!currentWeapon.hasMagSlot)
        {
            dropdown.MagDrop.gameObject.SetActive(false);
        }

        if (!currentWeapon.hasStockSlot)
        {
            dropdown.StockDrop.gameObject.SetActive(false);
        }

        if (!currentWeapon.hasSightSlot)
        {
            dropdown.SightDrop.gameObject.SetActive(false);
        }

        if (!currentWeapon.hasGripSlot)
        {
            dropdown.GripDrop.gameObject.SetActive(false);
        }
    }

}

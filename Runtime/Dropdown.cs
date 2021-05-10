using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor;

public class Dropdown : MonoBehaviour
{
    [Header("Dropdown Menus")]
    public TMP_Dropdown BarrelDrop;
    public TMP_Dropdown MagDrop;
    public TMP_Dropdown StockDrop;
    public TMP_Dropdown SightDrop;
    public TMP_Dropdown GripDrop;

    private GameObject barrelSlot;
    private GameObject magSlot;
    private GameObject stockSlot;
    private GameObject sightSlot;
    private GameObject gripSlot;

    private GameObject activeBarrelAttachment;
    private GameObject activeMagazineAttachment;
    private GameObject activeStockAttachment;
    private GameObject activeSightAttachment;
    private GameObject activeGripAttachment;

    [Header("Attachment Texts")]
    public TextMeshProUGUI fireRateText;
    public TextMeshProUGUI aimDownSightSpeedText;
    public TextMeshProUGUI horizontalRecoilText;
    public TextMeshProUGUI verticalRecoilText;
    public TextMeshProUGUI reloadSpeedText;
    public TextMeshProUGUI bulletVelocityText;
    public TextMeshProUGUI bulletDropText;
    public TextMeshProUGUI weightText;

    private float totalFireRate;
    private float totalADS;
    private float totalHR;
    private float totalVR;
    private float totalRSpeed;
    private float totalBVelo;
    private float totalBDrop;
    private float totalWeight;

    private List<AttachmentScript> currentAttachments;
    private CustomizationManager customizationManager;
    private CameraController camController;

    public void Awake()
    {
        EventController.Instance.onChosenWeapon.AddListener(InitializeSlots);
        EventController.Instance.onAttachmentChange.AddListener(CalculateWeaponStats);

        customizationManager = this.gameObject.GetComponent<CustomizationManager>();
        camController = this.gameObject.GetComponent<CameraController>();
    }

    private void Start()
    {
        currentAttachments = new List<AttachmentScript>();
        EventController.Instance.onStart.Invoke();

        BarrelDrop.options.Clear();
        MagDrop.options.Clear();
        StockDrop.options.Clear();
        SightDrop.options.Clear();
        GripDrop.options.Clear();
        
        for (int i = 0; i < customizationManager.barrelAttachments.Length; i++)
        {
            BarrelDrop.options.Add(new TMP_Dropdown.OptionData() { text = customizationManager.barrelAttachments[i].name });
        }

        for (int i = 0; i < customizationManager.magazineAttachments.Length; i++)
        {
            MagDrop.options.Add(new TMP_Dropdown.OptionData() { text = customizationManager.magazineAttachments[i].name });
        }

        for (int i = 0; i < customizationManager.stockAttachments.Length; i++)
        {
            StockDrop.options.Add(new TMP_Dropdown.OptionData() { text = customizationManager.stockAttachments[i].name });
        }

        for (int i = 0; i < customizationManager.sightAttachments.Length; i++)
        {
            SightDrop.options.Add(new TMP_Dropdown.OptionData() { text = customizationManager.sightAttachments[i].name });
        }

        for (int i = 0; i < customizationManager.gripAttachments.Length; i++)
        {
            GripDrop.options.Add(new TMP_Dropdown.OptionData() { text = customizationManager.gripAttachments[i].name });
        }

        BarrelDrop.RefreshShownValue();
        MagDrop.RefreshShownValue();
        StockDrop.RefreshShownValue();
        SightDrop.RefreshShownValue();
        GripDrop.RefreshShownValue();
    }

    public void InitializeSlots()
    {
        barrelSlot = GameObject.FindGameObjectWithTag("BarrelSlot");
        magSlot = GameObject.FindGameObjectWithTag("MagazineSlot");
        stockSlot = GameObject.FindGameObjectWithTag("StockSlot");
        sightSlot = GameObject.FindGameObjectWithTag("SightSlot");
        gripSlot = GameObject.FindGameObjectWithTag("GripSlot");
    }

    public void CalculateWeaponStats()
    {
        totalFireRate = 0;
        totalADS = 0;
        totalHR = 0;
        totalVR = 0;
        totalRSpeed = 0;
        totalBDrop = 0;
        totalWeight = 0;
        totalBVelo = 0;

        if (BarrelDrop.value != -1)
        {
            AddWeaponStats(customizationManager.barrelAttachments[BarrelDrop.value].GetComponent<AttachmentScript>());
        }

        if (MagDrop.value != -1)
        {
            AddWeaponStats(customizationManager.magazineAttachments[MagDrop.value].GetComponent<AttachmentScript>());
        }

        if (SightDrop.value != -1)
        {
            AddWeaponStats(customizationManager.sightAttachments[SightDrop.value].GetComponent<AttachmentScript>());
        }

        if (StockDrop.value != -1)
        {
            AddWeaponStats(customizationManager.stockAttachments[StockDrop.value].GetComponent<AttachmentScript>());
        }

        if (GripDrop.value != -1)
        {
            AddWeaponStats(customizationManager.gripAttachments[GripDrop.value].GetComponent<AttachmentScript>());
        }
        
        fireRateText.text = "Fire Rate: " + totalFireRate.ToString();
        aimDownSightSpeedText.text = "Aim Down Site Speed: " + totalADS.ToString();
        horizontalRecoilText.text = "Horizontal Recoil: " + totalHR.ToString();
        verticalRecoilText.text = "Vertical Recoil: " + totalVR.ToString();
        reloadSpeedText.text = "Reload Speed: " + totalRSpeed.ToString();
        bulletDropText.text = "Bullet Drop: " + totalBDrop.ToString();
        weightText.text = "Weight: " + totalWeight.ToString();
        bulletVelocityText.text = "Bullet Velocity: " + totalBVelo.ToString();
    }

    private void AddWeaponStats(AttachmentScript attachment)
    {
        totalFireRate += attachment.fireRate;
        totalADS += attachment.aimDownSiteSpeed;
        totalHR += attachment.horizontalRecoil;
        totalVR += attachment.verticalRecoil;
        totalRSpeed += attachment.reloadSpeed;
        totalBDrop += attachment.bulletDrop;
        totalWeight += attachment.weight;
        totalBVelo += attachment.bulletVelocity;
    }

    public void SaveWeapon()
    {
        WeaponScript finalStats = camController.target.GetComponent<WeaponScript>();

        finalStats.finalFireRate = totalFireRate;
        finalStats.finalAimDownSiteSpeed = totalADS;
        finalStats.finalHorizontalRecoil = totalHR;
        finalStats.finalVerticalRecoil = totalVR;
        finalStats.finalReloadSpeed = totalRSpeed;
        finalStats.finalBulletVelocity = totalBVelo;
        finalStats.finalBulletDrop = totalBDrop;
        finalStats.finalWeight = totalWeight;

        string localPath = "Assets/" + camController.target.name + ".prefab";

        localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);

        PrefabUtility.SaveAsPrefabAsset(camController.target,localPath);
    }

    public void BarrelDropdownFunc(int val)
    {
        if (activeBarrelAttachment != null)
        {
            Destroy(activeBarrelAttachment);
            activeBarrelAttachment = Instantiate(customizationManager.barrelAttachments[val], barrelSlot.transform);
        }
        else
        {
            activeBarrelAttachment = Instantiate(customizationManager.barrelAttachments[val], barrelSlot.transform);
        }

        EventController.Instance.onAttachmentChange.Invoke();
    }

    public void MagazineDropDownFunc(int val)
    {
        if (activeMagazineAttachment != null)
        {
            Destroy(activeMagazineAttachment);
            activeMagazineAttachment = Instantiate(customizationManager.magazineAttachments[val], magSlot.transform);
        }
        else
        {
            activeMagazineAttachment = Instantiate(customizationManager.magazineAttachments[val], magSlot.transform);
        }

        EventController.Instance.onAttachmentChange.Invoke();
    }

    public void StockDropDownFunc(int val)
    {
        if (activeStockAttachment != null)
        {
            Destroy(activeStockAttachment);
            activeStockAttachment = Instantiate(customizationManager.stockAttachments[val], stockSlot.transform);
        }
        else
        {
            activeStockAttachment = Instantiate(customizationManager.stockAttachments[val], stockSlot.transform);
        }

        EventController.Instance.onAttachmentChange.Invoke();
    }

    public void SightDropDownFunc(int val)
    {
        if (activeSightAttachment != null)
        {
            Destroy(activeSightAttachment);
            activeSightAttachment = Instantiate(customizationManager.sightAttachments[val], sightSlot.transform);
        }
        else
        {
            activeSightAttachment = Instantiate(customizationManager.sightAttachments[val], sightSlot.transform);
        }

        EventController.Instance.onAttachmentChange.Invoke();
    }

    public void GripDropDownFunc(int val)
    {
        if (activeGripAttachment != null)
        {
            Destroy(activeGripAttachment);
            activeGripAttachment = Instantiate(customizationManager.gripAttachments[val], gripSlot.transform);
        }
        else
        {
            activeGripAttachment = Instantiate(customizationManager.gripAttachments[val], gripSlot.transform);
        }

        EventController.Instance.onAttachmentChange.Invoke();
    }
}

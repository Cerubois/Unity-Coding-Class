using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{

	public WeaponDataManager weaponDataManager;

	public string weaponName = "NotAGun";
	public float weaponDamage = 1.0f;
	public float reloadSpeed = 1.0f;
	public int curAmmo = 10; // Current amount of ammo
	public int maxAmmo = 100; // Max held ammo
	public int clipSize = 10;
	public float fireRate = 1.0f;
	public float range = 30.0f;
	public float accuracy = 1.0f;
	public float swapSpeed = 1.0f;
	public ParticleSystem hitParticle;
	public string statusInflicted = "none";
	public float explosionRadius = 0.0f;

	public List<string> weaponsHeld = new List<string>();
	public int curWeapon = 0;

    // Start is called before the first frame update
    void Start()
    {

		weaponDataManager = transform.GetComponent<WeaponDataManager>();

		UpdateWeaponData();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void UpdateWeaponData() {

		weaponName = weaponDataManager.GetWeaponName();
		weaponDamage = weaponDataManager.GetWeaponDamage();
		curAmmo = weaponDataManager.GetWeaponCurAmmo();

	}

}

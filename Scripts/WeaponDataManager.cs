using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class WeaponDataManager : MonoBehaviour
{

	TextAsset weaponText;
	XmlDocument weaponDoc;

    // Start is called before the first frame update
    void Start()
    {

		weaponText = Resources.Load<TextAsset>("WeaponDatabase");
		weaponDoc = new XmlDocument();
		weaponDoc.LoadXml(weaponText.text);

		print(GetWeaponCurAmmo());

    }

	public string GetWeaponName() {

		string path = "weapons/weapon[@name=\"NotAGun\"]/name";

		string thisWeaponName = weaponDoc.SelectSingleNode(path).InnerText;

		return thisWeaponName;

	}

	public float GetWeaponDamage() {

		string path = "weapons/weapon[@name=\"NotAGun\"]/weaponDamage";

		float thisWeaponDamage = float.Parse(weaponDoc.SelectSingleNode(path).InnerText);

		return thisWeaponDamage;

	}

	public int GetWeaponCurAmmo() {

		string path = "weapons/weapon[@name=\"NotAGun\"]/curAmmo";

		int thisWeaponCurAmmo = int.Parse(weaponDoc.SelectSingleNode(path).InnerText);

		return thisWeaponCurAmmo;

	}

}

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

    }


}

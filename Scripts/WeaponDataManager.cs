using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class WeaponDataManager : MonoBehaviour{

    TextAsset baseGameXML;
    XmlDocument baseGameXMLDoc;

    public void Start(){
        
        baseGameXML = Resources.Load<TextAsset>("WeaponData");
        baseGameXMLDoc = new XmlDocument();
        baseGameXMLDoc.LoadXml(baseGameXML.text);

    }

    public string GetWeaponName(string weaponToSearch) {

        // Set up path to search for in the XMLDoc.
        string path = "weapons/weapon[@name=\"" + weaponToSearch + "\"]/name";

        // In this case, we're searching through WeaponData 'weapon' nodes that have the 'name' attribute which matches the 'weaponToSearch' string,
        // and then getting the 'weaponType' node descending from that weapon.
        string thisWeaponName = baseGameXMLDoc.SelectSingleNode(path).InnerText;

        return thisWeaponName;

    }

    public float GetWeaponDamage(string weaponToSearch) {

        // Set up path to search for in the XMLDoc.
        string path = "weapons/weapon[@name=\"" + weaponToSearch + "\"]/damage";

        // In this case, we're searching through WeaponData 'weapon' nodes that have the 'name' attribute which matches the 'weaponToSearch' string,
        // and then getting the 'costValue' node descending from that weapon.
        float thisWeaponDamage = float.Parse(baseGameXMLDoc.SelectSingleNode(path).InnerText);

        return thisWeaponDamage;

    }

    public int GetWeaponCurAmmo(string weaponToSearch) {

        // Set up path to search for in the XMLDoc.
        string path = "weapons/weapon[@name=\"" + weaponToSearch + "\"]/curAmmo";

        // In this case, we're searching through WeaponData 'weapon' nodes that have the 'name' attribute which matches the 'weaponToSearch' string,
        // and then getting the 'costValue' node descending from that weapon.
        int thisWeaponCurAmmo = int.Parse(baseGameXMLDoc.SelectSingleNode(path).InnerText);

        return thisWeaponCurAmmo;

    }


    public int GetSpecificweaponValue(string weaponToSearch, string valueNodeName) {

        int value;
        string path = "weapons/weapon[@name=\"" + weaponToSearch + "\"]/weaponEffects/" + valueNodeName;

        try {
            int.TryParse(baseGameXMLDoc.SelectSingleNode(path).InnerText, out value);
        }
        catch {
            value = 0;
        }

        return value;

    }


    /// <summary>
    /// Get all the abilities of the named weapon
    /// </summary>
    /// <param name="weaponToSearch"></param>
    /// <returns></returns>
    public Dictionary<string, int> GetAllweaponEffectValues(string weaponToSearch) {

        Dictionary<string, int> effectsAndAmounts = new Dictionary<string, int>();

        // Set up XPath to search for in the XMLDoc.
        string path = "weapons/weapon[@name=\"" + weaponToSearch + "\"]/weaponEffects";
           

        // ----- Get values/amounts of effects (e.g. how much buy power it gives) -----

        int buyPowerValue;
        try {
            int.TryParse(baseGameXMLDoc.SelectSingleNode(path + "/addBuyPower").InnerText, out buyPowerValue);
        }
        catch {
            buyPowerValue = 0;
        }

        int attackPowerValue;
        try {
            int.TryParse(baseGameXMLDoc.SelectSingleNode(path + "/addAttackPower").InnerText, out attackPowerValue);
        }
        catch {
            attackPowerValue = 0;
        }

        int shieldPowerValue;
        try {
            int.TryParse(baseGameXMLDoc.SelectSingleNode(path + "/addShieldPower").InnerText, out shieldPowerValue);
        }
        catch {
            shieldPowerValue = 0;
        }

        int healPowerValue;
        try {
            int.TryParse(baseGameXMLDoc.SelectSingleNode(path + "/addHealPower").InnerText, out healPowerValue);
        }
        catch {
            healPowerValue = 0;
        }

        int drawweaponValue;
        try {
            int.TryParse(baseGameXMLDoc.SelectSingleNode(path + "/drawweapon").InnerText, out drawweaponValue);
        }
        catch {
            drawweaponValue = 0;
        }

        int vsAntagonistsValue;
        try {
            int.TryParse(baseGameXMLDoc.SelectSingleNode(path + "/addAttackPowerVsAnts").InnerText, out vsAntagonistsValue);
        }
        catch {
            vsAntagonistsValue = 0;
        }

        int trashweaponValue;
        try {
            int.TryParse(baseGameXMLDoc.SelectSingleNode(path + "/trashweapon").InnerText, out trashweaponValue);
        }
        catch {
            trashweaponValue = 0;
        }

        int debtBuyValue;
        try {
            int.TryParse(baseGameXMLDoc.SelectSingleNode(path + "/debtBuy").InnerText, out debtBuyValue);
        }
        catch {
            debtBuyValue = 0;
        }

        int debtAttackValue;
        try {
            int.TryParse(baseGameXMLDoc.SelectSingleNode(path + "/debtAttack").InnerText, out debtAttackValue);
        }
        catch {
            debtAttackValue = 0;
        }

        int debtShieldValue;
        try {
            int.TryParse(baseGameXMLDoc.SelectSingleNode(path + "/debtShield").InnerText, out debtShieldValue);
        }
        catch {
            debtShieldValue = 0;
        }

        int debtHealValue;
        try {
            int.TryParse(baseGameXMLDoc.SelectSingleNode(path + "/debtHeal").InnerText, out debtHealValue);
        }
        catch {
            debtHealValue = 0;
        }

        int tropePointsValue;
        try {
            int.TryParse(baseGameXMLDoc.SelectSingleNode(path + "/addTropePoints").InnerText, out tropePointsValue);
        }
        catch {
            tropePointsValue = 0;
        }

        int scryweaponValue;
        try {
            int.TryParse(baseGameXMLDoc.SelectSingleNode(path + "/scry").InnerText, out scryweaponValue);
        }
        catch {
            scryweaponValue = 0;
        }

        // -----  -----


        if (buyPowerValue != 0)
            effectsAndAmounts.Add("addBuyPower", buyPowerValue);
        if (attackPowerValue != 0)
            effectsAndAmounts.Add("addAttackPower", attackPowerValue);
        if (shieldPowerValue != 0)
            effectsAndAmounts.Add("addShieldPower", shieldPowerValue);
        if (healPowerValue != 0)
            effectsAndAmounts.Add("addHealPower", healPowerValue);
        if (drawweaponValue > 0)
            effectsAndAmounts.Add("drawweapon", drawweaponValue);
        if (vsAntagonistsValue != 0)
            effectsAndAmounts.Add("addAttackPowerVsAnts", vsAntagonistsValue);
        if (trashweaponValue > 0)
            effectsAndAmounts.Add("trashweapon", trashweaponValue);
        if (debtBuyValue != 0)
            effectsAndAmounts.Add("debtBuy", debtBuyValue);
        if (debtAttackValue != 0)
            effectsAndAmounts.Add("debtAttack", debtAttackValue);
        if (debtShieldValue != 0)
            effectsAndAmounts.Add("debtShield", debtShieldValue);
        if (debtHealValue != 0)
            effectsAndAmounts.Add("debtHeal", debtHealValue);
        if (tropePointsValue != 0)
            effectsAndAmounts.Add("addTropePoints", tropePointsValue);
        if (scryweaponValue != 0)
            effectsAndAmounts.Add("scry", scryweaponValue);

        return effectsAndAmounts;

    }

}

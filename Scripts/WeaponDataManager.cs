using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using UnityEngine;

public class WeaponDataManager : MonoBehaviour{

    TextAsset baseGameXML;
    XmlDocument baseGameXMLDoc;
    //XElement storedChoiceElement;

    public void Setup(){
        
        baseGameXML = Resources.Load<TextAsset>("Card Data/BaseGameCardData");

        baseGameXMLDoc = new XmlDocument();
        baseGameXMLDoc.LoadXml(baseGameXML.text);

    }

    // Update is called once per frame
    void Update(){


        
    }

    public string GetWeaponName(string weaponToSearch) {

        // Set up XPath to search for in the XMLDoc.
        string path = "weapons/weapon[@name=\"" + weaponToSearch + "\"]/weaponName";

        // In this case, we're searching through BaseGameCardData 'card' nodes that have the 'name' attribute which matches the 'cardToSearch' string,
        // and then getting the 'cardType' node descending from that card.
        string thisCardType = baseGameXMLDoc.SelectSingleNode(path).InnerText;

        return thisCardType;

    }

    public bool IsCardPersistent(string cardToSearch) {

        // Set up XPath to search for in the XMLDoc.
        string path = "cards/card[@name=\"" + cardToSearch + "\"]/persistent";

        // In this case, we're searching through BaseGameCardData 'card' nodes that have the 'name' attribute which matches the 'cardToSearch' string,
        // and then getting the 'persistent' node descending from that card.
        XmlNode persistentNode = baseGameXMLDoc.SelectSingleNode(path);

        if (persistentNode != null)
            return true;
        else
            return false;

    }

    public int GetCardCost(string cardToSearch) {

        // Set up XPath to search for in the XMLDoc.
        string path = "cards/card[@name=\"" + cardToSearch + "\"]/costValue";

        // In this case, we're searching through BaseGameCardData 'card' nodes that have the 'name' attribute which matches the 'cardToSearch' string,
        // and then getting the 'costValue' node descending from that card.
        int thisCardCost = int.Parse(baseGameXMLDoc.SelectSingleNode(path).InnerText);

        return thisCardCost;

    }


    public int GetSpecificCardValue(string cardToSearch, string valueNodeName) {

        int value;
        string path = "cards/card[@name=\"" + cardToSearch + "\"]/cardEffects/" + valueNodeName;

        try {
            int.TryParse(baseGameXMLDoc.SelectSingleNode(path).InnerText, out value);
        }
        catch {
            value = 0;
        }

        return value;

    }


    /// <summary>
    /// Get all the abilities of the named card
    /// </summary>
    /// <param name="cardToSearch"></param>
    /// <returns></returns>
    public Dictionary<string, int> GetAllCardEffectValues(string cardToSearch) {

        Dictionary<string, int> effectsAndAmounts = new Dictionary<string, int>();

        // Set up XPath to search for in the XMLDoc.
        string path = "cards/card[@name=\"" + cardToSearch + "\"]/cardEffects";
           

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

        int drawCardValue;
        try {
            int.TryParse(baseGameXMLDoc.SelectSingleNode(path + "/drawCard").InnerText, out drawCardValue);
        }
        catch {
            drawCardValue = 0;
        }

        int vsAntagonistsValue;
        try {
            int.TryParse(baseGameXMLDoc.SelectSingleNode(path + "/addAttackPowerVsAnts").InnerText, out vsAntagonistsValue);
        }
        catch {
            vsAntagonistsValue = 0;
        }

        int trashCardValue;
        try {
            int.TryParse(baseGameXMLDoc.SelectSingleNode(path + "/trashCard").InnerText, out trashCardValue);
        }
        catch {
            trashCardValue = 0;
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

        int scryCardValue;
        try {
            int.TryParse(baseGameXMLDoc.SelectSingleNode(path + "/scry").InnerText, out scryCardValue);
        }
        catch {
            scryCardValue = 0;
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
        if (drawCardValue > 0)
            effectsAndAmounts.Add("drawCard", drawCardValue);
        if (vsAntagonistsValue != 0)
            effectsAndAmounts.Add("addAttackPowerVsAnts", vsAntagonistsValue);
        if (trashCardValue > 0)
            effectsAndAmounts.Add("trashCard", trashCardValue);
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
        if (scryCardValue != 0)
            effectsAndAmounts.Add("scry", scryCardValue);

        return effectsAndAmounts;

    }

}

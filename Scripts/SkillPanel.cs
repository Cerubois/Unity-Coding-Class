using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPanel : MonoBehaviour
{

	public PlayerMove pMove;
	public PlayerAim pAim;
	public Text pointsText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

		pointsText.text = "Points: " + pAim.skillPoints.ToString();


    }

	public void IncMoveSpeed() {

		if(pAim.skillPoints > 0) {

			pAim.skillPoints -= 1;
			pMove.moveSpeed += 0.1f;

		}

	}

	public void IncDamage() {

		if (pAim.skillPoints > 0) {

			pAim.skillPoints -= 1;
			pAim.bonusDmg += 1;

		}

	}


}

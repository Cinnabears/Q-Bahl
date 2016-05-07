using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Cooldown2Time : MonoBehaviour
{

    GameObject player;

    PlayerTransform currForm;

    PlayerNormalForm normalForm;
    PlayerElementalForm elementalForm;
    PlayerWarpForm warpForm;
    PlayerRangedForm rangedForm;

    float cooldown2Normal;
    float cooldown2Ranged;
    float cooldown2Elemental;
    float cooldown2Warp;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        normalForm = player.GetComponent<PlayerNormalForm>();
        elementalForm = player.GetComponent<PlayerElementalForm>();
        warpForm = player.GetComponent<PlayerWarpForm>();
        rangedForm = player.GetComponent<PlayerRangedForm>();
    }

    // Update is called once per frame
    void Update()
    {
		if (player.GetComponent<PlayerNormalForm> () != null) {
			currForm = player.GetComponent<PlayerTransformManager> ().current_form;
		}
        if (currForm == player.GetComponent<PlayerTransformManager>().transform_dict[1])
        {
            if (!player.GetComponent<PlayerNormalForm>().getCooling2())
            {
                GetComponent<Text>().text =  "Ready";
                cooldown2Normal = 0;
            }
            else
            {
                Invoke("cooldown2NormalStart", 0);
                GetComponent<Text>().text =  "Cooling";
                if (normalForm.getCooling2Time() - cooldown2Normal <= 0)
                {
                    cooldown2Normal = 0;
                }
            }
        }

        if (currForm == player.GetComponent<PlayerTransformManager>().transform_dict[2])
        {
            if (!player.GetComponent<PlayerWarpForm>().getCooling2())
            {
                GetComponent<Text>().text = "Ready";
                cooldown2Warp = 0;
            }
            else
            {
                Invoke("cooldown2WarpStart", 0);
                GetComponent<Text>().text = "Cooling";
                if (warpForm.getCooling2Time() - cooldown2Warp <= 0)
                {
                    cooldown2Warp = 0;
                    CancelInvoke("cooldown2WarpIncrement");
                }
            }
        }

        if (currForm == player.GetComponent<PlayerTransformManager>().transform_dict[3])
        {
            if (!player.GetComponent<PlayerRangedForm>().getCooling2())
            {
                GetComponent<Text>().text = "Ready";
                cooldown2Ranged = 0;
            }
            else
            {
                Invoke("cooldown2RangedStart", 0);
                GetComponent<Text>().text = "Cooling";
                if (rangedForm.getCooling2Time() - cooldown2Ranged <= 0)
                {
                    cooldown2Ranged = 0;
                }
            }
        }

        if (currForm == player.GetComponent<PlayerTransformManager>().transform_dict[4])
        {
            if (!player.GetComponent<PlayerElementalForm>().getCooling2())
            {
                GetComponent<Text>().text = "Ready";
                cooldown2Elemental = 0;
            }
            else
            {
                Invoke("cooldown2ElementalStart", 0);
                GetComponent<Text>().text = "Cooling";
                if (elementalForm.getCooling2Time() - cooldown2Elemental <= 0)
                {
                    cooldown2Elemental = 0;
                    CancelInvoke("cooldown2ElementalIncrement");
                }
            }
        }
    }
    void cooldown2NormalStart()
    {
        InvokeRepeating("cooldown2NormalIncrement", 0, 0.01f);
    }

    void cooldown2NormalIncrement()
    {
        cooldown2Normal += 0.01f;
    }

    void cooldown2WarpStart()
    {
        InvokeRepeating("cooldown2WarpIncrement", 0, 0.01f);
    }

    void cooldown2WarpIncrement()
    {
        cooldown2Warp += 0.01f;
    }

    void cooldown2ElementalStart()
    {
        InvokeRepeating("cooldown2ElementalIncrement", 0, 0.01f);
    }

    void cooldown2ElementalIncrement()
    {
        cooldown2Elemental += 0.01f;
    }

    void cooldown2RangedStart()
    {
        InvokeRepeating("cooldown2RangedIncrement", 0, 0.01f);
    }

    void cooldown2RangedIncrement()
    {
        cooldown2Ranged += 0.01f;
    }

}

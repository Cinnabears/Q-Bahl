﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Cooldown1Time : MonoBehaviour {

    GameObject player;

    PlayerTransform currForm;

    PlayerNormalForm normalForm;
    PlayerElementalForm elementalForm;
    PlayerWarpForm warpForm;
    PlayerRangedForm rangedForm;

    float cooldown1Normal;
    float cooldown1Ranged;
    float cooldown1Elemental;
    float cooldown1Warp;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        normalForm = player.GetComponent<PlayerNormalForm>();
        elementalForm = player.GetComponent<PlayerElementalForm>();
        warpForm = player.GetComponent<PlayerWarpForm>();
        rangedForm = player.GetComponent<PlayerRangedForm>();
	}
	
	// Update is called once per frame
	void Update () {
        currForm = player.GetComponent<PlayerTransformManager>().current_form;

        if (currForm == player.GetComponent<PlayerTransformManager>().transform_dict[1])
        {
            if (!player.GetComponent<PlayerNormalForm>().getCooling1())
            {
                GetComponent<Text>().text = "Ready";
                cooldown1Normal = 0;
            }
            else
            {
                Invoke("cooldown1NormalStart", 0);
                GetComponent<Text>().text = "Cooling";
                if (normalForm.getCooling1Time() - cooldown1Normal <= 0)
                {
                    cooldown1Normal = 0;
                }
            }
        }

        if (currForm == player.GetComponent<PlayerTransformManager>().transform_dict[2])
        {
            if (!player.GetComponent<PlayerWarpForm>().getCooling1())
            {
                GetComponent<Text>().text = "Ready";
                cooldown1Warp = 0;
            }
            else
            {
                Invoke("cooldown1WarpStart", 0);
                GetComponent<Text>().text = "Cooling";
                if (warpForm.getCooling1Time() - cooldown1Warp <= 0)
                {
                    cooldown1Warp = 0;
                    CancelInvoke("cooldown1WarpIncrement");
                }
            }
        }

        if (currForm == player.GetComponent<PlayerTransformManager>().transform_dict[3])
        {
            if (!player.GetComponent<PlayerRangedForm>().getCooling1())
            {
                GetComponent<Text>().text = "Ready";
                cooldown1Ranged = 0;
            }
            else
            {
                Invoke("cooldown1RangedStart", 0);
                GetComponent<Text>().text = "Cooling";
                if (rangedForm.getCooling1Time() - cooldown1Ranged <= 0)
                {
                    cooldown1Ranged = 0;
                }
            }
        }

        if (currForm == player.GetComponent<PlayerTransformManager>().transform_dict[4])
        {
            if (!player.GetComponent<PlayerElementalForm>().getCooling1())
            {
                GetComponent<Text>().text = "Ready";
                cooldown1Elemental = 0;
            }
            else
            {
                Invoke("cooldown1ElementalStart", 0);
                GetComponent<Text>().text = "Cooling";
                if (elementalForm.getCooling1Time() - cooldown1Elemental <= 0)
                {
                    cooldown1Elemental = 0;
                    CancelInvoke("cooldown1ElementalIncrement");
                }
            }
        }
	}

    void cooldown1NormalStart()
    {
        InvokeRepeating("cooldown1NormalIncrement", 0, 0.01f);
    }

    void cooldown1NormalIncrement()
    {
        cooldown1Normal += 0.01f;
    }

    void cooldown1WarpStart()
    {
        InvokeRepeating("cooldown1WarpIncrement", 0, 0.01f);
    }

    void cooldown1WarpIncrement()
    {
        cooldown1Warp += 0.01f;
    }

    void cooldown1ElementalStart()
    {
        InvokeRepeating("cooldown1ElementalIncrement", 0, 0.01f);
    }

    void cooldown1ElementalIncrement()
    {
        cooldown1Elemental += 0.01f;
    }

    void cooldown1RangedStart()
    {
        InvokeRepeating("cooldown1RangedIncrement", 0, 0.01f);
    }

    void cooldown1RangedIncrement()
    {
        cooldown1Ranged += 0.01f;
    }

   
}

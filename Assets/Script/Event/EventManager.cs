using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] private GameObject holderObj;
    [SerializeField] private Transform camObj;

    public void HolderControl(bool isTargetFound) => holderObj?.SetActive(isTargetFound);
}

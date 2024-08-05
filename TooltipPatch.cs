using UnityEngine;
using MelonLoader;
using HarmonyLib;
using Il2CppHabitanks.UI;
using System;
using Il2CppFoundation.Interface;

namespace Hazelnut272.UwuMod
{
    [HarmonyPatch(typeof(TipList), nameof(TipList.ShowTip), new Type[] { typeof(string), typeof(ScreenPosition), typeof(string) })]
    [HarmonyPatch(MethodType.Normal)]
    public static class TooltipPatch
    {

    }
}
using UnityEngine;
using MelonLoader;
using HarmonyLib;
using Il2CppHabitanks.UI;
using System;
using Il2CppFoundation.Interface;
using Il2CppFoundation;

namespace Hazelnut272.UwuMod
{
    [HarmonyPatch(typeof(Tooltip), nameof(Tooltip.ShowText))]
    [HarmonyPatch(MethodType.Normal)]
    public static class TooltipPatch
    {
        public static void Prefix(ref string title, ref string desc)
        {
            byte[] binary = System.Text.Encoding.ASCII.GetBytes(title);
            int seed1 = Convert.ToInt32(binary[0]);
            int seed2;
            seed2 = Convert.ToInt32(binary[1]);

            title = UwuTranslator.TranslateString(title, seed1);
            if(desc != null && desc != "")
            {
                desc = UwuTranslator.TranslateString(desc, seed2);
            }
        }
    }
}
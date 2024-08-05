using HarmonyLib;
using Il2CppHabitanks.UI;
using System;

namespace Hazelnut272.UwuMod
{
    [HarmonyPatch(typeof(TipList), nameof(TipList.ShowTip), new Type[] { typeof(float), typeof(string), typeof(string) })]
    [HarmonyPatch(MethodType.Normal)]
    public static class TipPatch
    {
        public static void Prefix(ref float delay, ref string key, ref string text)
        {
            Main.Log($"Showing tip: key {key}, message {text}");

            text = UwuTranslator.TranslateString(text);
        }
    }
}
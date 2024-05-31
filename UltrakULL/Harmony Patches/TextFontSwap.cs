using HarmonyLib;
using System;
using System.Collections.Generic;
using TMPro;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.UI;

using static UltrakULL.CommonFunctions;
using static UnityEngine.TextAnchor;

namespace UltrakULL.Harmony_Patches
{
	public class TextFontSwap
	{
		public static Font originalFont;

		[HarmonyPatch(typeof(Text), "OnEnable")]
		public static class TextFontSwapper
		{
			static List<IntPtr> objectsFixed = new List<IntPtr>();

			[HarmonyPostfix]
			public static void SwapFont(ref Text __instance, IntPtr ___m_CachedPtr)
			{
				if (objectsFixed.Count > 0)
				{
					if (objectsFixed.Contains(___m_CachedPtr))
					{
						return;
					}
				}

				if (LanguageManager.IsRightToLeft)
				{
					switch (__instance.alignment)
					{
						case UpperLeft:
							__instance.alignment = UpperRight;
							break;
						case MiddleLeft:
							__instance.alignment = MiddleRight;
							break;
						case LowerLeft:
							__instance.alignment = LowerRight;
							break;
						case UpperRight:
							__instance.alignment = UpperLeft;
							break;
						case MiddleRight:
							__instance.alignment = MiddleLeft;
							break;
						case LowerRight:
							__instance.alignment = LowerLeft;
							break;
					}

					__instance.alignByGeometry = true;
				}

				if (Core.GlobalFontReady)
				{
					if (GetCurrentSceneName() == "CreditsMuseum2")
					{
						if (__instance.font.fontNames[0] == "GFS Garaldus")
						{
							__instance.font = Core.MuseumFont;
						}
						else
						{
							__instance.font = Core.GlobalFont;
						}
					}
					else
					{
						originalFont = __instance.font;
						__instance.font = Core.GlobalFont;
					}
				}

				objectsFixed.Add(___m_CachedPtr);
			}
		}
	}

	public class TextMeshProFontSwap
	{
		public static void SwapTMPFont(ref TextMeshProUGUI __instance)
		{
            if (__instance.transform.parent.GetComponent<HealthBar>() != null && __instance.gameObject.name.Equals("HP Text")) { return; }
            string currentLanguage = LanguageManager.CurrentLanguage.metadata.langName.ToLower();
            string currentLanguageCode = currentLanguage.Substring(0, 2);
            bool isUnderlaid = __instance.gameObject.name.Contains("NameText") ||
                __instance.gameObject.name.Contains("LayerText") ||
                __instance.transform.parent.gameObject.name.Contains("Cheats Info");
            bool isOverlay = HudControllerPatch.isOverlaid;
            Vector4 originalUnderlaycolor = __instance.fontMaterial.GetVector("_UnderlayColor");
            switch (currentLanguageCode)
            {
                //Traditional/Simplified Chinese
                case "zh":
                    {

                        //Swap with a Chinese font when it comes in.
                        __instance.font = Core.CJKFontTMP;
                        if (isUnderlaid)
                        {
                            Material underlaid = new Material(__instance.fontMaterial);
                            underlaid.SetVector("_UnderlayColor", originalUnderlaycolor);
                            __instance.fontSharedMaterial = (isOverlay ? Core.CJKFontTMPOverlayMat : Core.CJKFontTMP.material);
                            __instance.fontSharedMaterial.SetFloat("_ZTest", (isOverlay ? 8f : 4f));
                            __instance.fontMaterial = underlaid;
                        }
                        else
                        {
                            __instance.fontSharedMaterial = (isOverlay ? Core.CJKFontTMPOverlayMat : Core.CJKFontTMP.material);
                            __instance.fontSharedMaterial.SetFloat("_ZTest", (isOverlay ? 8f : 4f));
                            __instance.fontSharedMaterial.SetVector("_UnderlayColor", new Vector4(0, 0, 0, 0));
                        }
                        break;
                    }
                //Japanese
                case "ja":
                    {
                        __instance.font = Core.JaFontTMP;
                        if (isUnderlaid)
                        {
                            Material underlaid = new Material(__instance.fontMaterial);
                            underlaid.SetVector("_UnderlayColor", originalUnderlaycolor);
                            __instance.fontSharedMaterial = (isOverlay ? Core.jaFontTMPOverlayMat : Core.JaFontTMP.material);
                            __instance.fontSharedMaterial.SetFloat("_ZTest", (isOverlay ? 8f : 4f));
                            __instance.fontMaterial = underlaid;
                        }
                        else
                        {
                            __instance.fontSharedMaterial = (isOverlay ? Core.jaFontTMPOverlayMat : Core.JaFontTMP.material);
                            __instance.fontSharedMaterial.SetFloat("_ZTest", (isOverlay ? 8f : 4f));
                            __instance.fontSharedMaterial.SetVector("_UnderlayColor", new Vector4(0, 0, 0, 0));
                        }
                        break;
                    }
                //Arabic Persian Urdu
                case "ar":
                case "fa":
                case "ur":
                    {

                        switch (__instance.alignment)
                        {
                            case TextAlignmentOptions.TopLeft:
                                __instance.alignment = TextAlignmentOptions.TopRight;
                                break;
                            case TextAlignmentOptions.Left:
                                __instance.alignment = TextAlignmentOptions.Right;
                                break;
                            case TextAlignmentOptions.BottomLeft:
                                __instance.alignment = TextAlignmentOptions.BottomRight;
                                break;
                            case TextAlignmentOptions.BaselineLeft:
                                __instance.alignment = TextAlignmentOptions.BaselineRight;
                                break;
                        }

                        Core.GlobalFontTMP.fallbackFontAssetTable.Add(Core.ArabicFontTMP);

                        if (GetCurrentSceneName() == "CreditsMuseum2")
                        {
                            if (__instance.font.name == "GFS Garaldus")
                            {
                                __instance.font = Core.MuseumFontTMP;
                            }
                            else
                            {
                                __instance.font = Core.GlobalFontTMP;
                            }
                        }
                        else
                        {
                            __instance.font = Core.GlobalFontTMP;
                            if (isUnderlaid)
                            {
                                Material underlaid = new Material(__instance.fontMaterial);
                                underlaid.SetVector("_UnderlayColor", originalUnderlaycolor);
                                __instance.fontMaterial = underlaid;
                            }
                            else
                            {
                                __instance.fontSharedMaterial.SetVector("_UnderlayColor", new Vector4(0, 0, 0, 0));
                            }
                        }

                        break;
                    }

                //Hebrew Yiddish Ladino Mozarabic Judeo-Arabic
                case "he":
                case "yi":
                case "la":
                case "ro":
                case "jr":
                    {
                        __instance.font = Core.HebrewFontTMP;
                        if (isUnderlaid)
                        {
                            Material underlaid = new Material(__instance.fontMaterial);
                            underlaid.SetVector("_UnderlayColor", originalUnderlaycolor);
                            __instance.fontMaterial = underlaid;
                        }
                        else
                        {
                            __instance.fontSharedMaterial.SetVector("_UnderlayColor", new Vector4(0, 0, 0, 0));
                        }
                        break;
                    }
                default:
                    {
                        if (GetCurrentSceneName() == "CreditsMuseum2")
                        {
                            if (__instance.font.name == "GFS Garaldus")
                            {
                                __instance.font = Core.MuseumFontTMP;
                            }
                            else
                            {
                                __instance.font = Core.GlobalFontTMP;
                            }
                        }
                        else
                        {
                            __instance.font = Core.GlobalFontTMP;
                            if (isUnderlaid)
                            {
                                Material underlaid = new Material(__instance.fontMaterial);
                                underlaid.SetVector("_UnderlayColor", originalUnderlaycolor);
                                __instance.fontSharedMaterial = (isOverlay ? Core.GlobalFontTMPOverlayMat : Core.GlobalFontTMP.material);
                                __instance.fontSharedMaterial.SetFloat("_ZTest", (isOverlay ? 8f : 4f));
                                __instance.fontMaterial = underlaid;
                            }
                            else
                            {
                                __instance.fontSharedMaterial = (isOverlay ? Core.GlobalFontTMPOverlayMat : Core.GlobalFontTMP.material);
                                __instance.fontSharedMaterial.SetFloat("_ZTest", (isOverlay ? 8f : 4f));
                                __instance.fontSharedMaterial.SetVector("_UnderlayColor", new Vector4(0, 0, 0, 0));
                            }
                        }
                        break;
                    }
            }

        }
		[HarmonyPatch(typeof(TextMeshProUGUI), "OnEnable")]
		public static class TextMeshProFontSwapper
		{

			static List<IntPtr> objectsFixed = new List<IntPtr>();

			[HarmonyPostfix]
			public static void SwapFont(ref TextMeshProUGUI __instance, IntPtr ___m_CachedPtr)
			{
				if (objectsFixed.Count > 0)
				{
					if (objectsFixed.Contains(___m_CachedPtr))
					{
						return;
					}
				}


				if (Core.TMPFontReady)
				{
					if (isUsingEnglish())
					{
						if (GetCurrentSceneName() != "Main Menu")
						{
							return;
						}
					}
                    SwapTMPFont(ref __instance);
					objectsFixed.Add(___m_CachedPtr);
				}

			}
		}

        [HarmonyPatch(typeof(HudController))]
        public static class HudControllerPatch
        {
            public static bool isOverlaid = MonoSingleton<PrefsManager>.Instance.GetBool("hudAlwaysOnTop");
            [HarmonyPatch("SetAlwaysOnTop"), HarmonyPrefix]
            public static bool SetAlwaysOnTop_Prefix(ref TMP_Text[] ___textElements, bool onTop)
            {
                if (isUsingEnglish())
                { return true; }
                isOverlaid = onTop;
                if (___textElements.Length > 0)
                {
                    TMP_Text[] array = ___textElements;
                    for (int i = 0; i < array.Length; i++)
                    {
                        TextMeshProUGUI a = array[i].GetComponent<TextMeshProUGUI>();
                        SwapTMPFont(ref a);
                    }
                }
                return false;
            }
        }
        [HarmonyPatch(typeof(SubtitleController))]
		public static class SubtitleFontSwapper
		{
			[HarmonyPatch("DisplaySubtitle", new[] { typeof(string), typeof(AudioSource), typeof(bool) }), HarmonyPrefix]
			public static bool SubtitlePostfix(SubtitleController __instance, string caption, AudioSource audioSource, bool ignoreSetting, Subtitle ___subtitleLine, Transform ___container, Subtitle ___previousSubtitle)
            {
                if (!__instance.SubtitlesEnabled && !ignoreSetting)
                {
                    return false;
                }
                Subtitle subtitle = UnityEngine.Object.Instantiate<Subtitle>(___subtitleLine, ___container, true);
                subtitle.GetComponentInChildren<TMP_Text>().text = caption;
                TextMeshProUGUI subtext = subtitle.GetComponentInChildren<TextMeshProUGUI>();
				if (Core.TMPFontReady)
                {
                    SwapTMPFont(ref subtext);
                }
                if (audioSource != null)
                {
                    subtitle.distanceCheckObject = audioSource;
                }
                subtitle.gameObject.SetActive(true);
                if (!___previousSubtitle)
                {
                    subtitle.ContinueChain();
                }
                else
                {
                    ___previousSubtitle.nextInChain = subtitle;
                }
                ___previousSubtitle = subtitle;
				return false;
            }
		}
	}
}
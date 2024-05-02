using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
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


				if (Core.TMPFontReady && !isUsingEnglish())
				{
					string currentLanguage = LanguageManager.CurrentLanguage.metadata.langName.ToLower();
					string currentLanguageCode = currentLanguage.Substring(0, 2);
					switch (currentLanguageCode)
                    {
						//Traditional/Simplified Chinese
                        case "zh":
                            {
                                //Swap with a Chinese font when it comes in.
                                __instance.font = Core.CJKFontTMP;
                                break;
                            }
						//Japanese
                        case "ja":
                            {
                                //japanese tofu fix
                                __instance.font = Core.jaFontTMP;
                                break;
                            }
						//Arabic Persian Urdu
                        case "ar":
						case "fa":
						case "ur":
							{
								
								switch(__instance.alignment)
								{
									case TextAlignmentOptions.TopLeft:
										__instance.alignment = TextAlignmentOptions.TopRight;
										break;
									case TextAlignmentOptions.Left:
										__instance.alignment	= TextAlignmentOptions.Right;
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
                                    TMP_Text TMPText = __instance.gameObject.GetComponent<TMP_Text>();
									if (__instance.gameObject.name.Contains("NameText") || __instance.gameObject.name.Contains("LayerText"))
                                    {
                                        Material underlaid = new Material(__instance.fontMaterial);
										underlaid.SetVector("_UnderlayColor", new Vector4(0, 0, 0, 1)); 
                                        TMPText.fontMaterial = underlaid;
                                    }
									else
                                    {
                                        TMPText.fontMaterial.SetVector("_UnderlayColor", new Vector4(0, 0, 0, 0));
									}
                                }
                                break;
							}
					}

					objectsFixed.Add(___m_CachedPtr);
				}

			}
		}
	}
}
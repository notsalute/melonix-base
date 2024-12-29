using neeko.WorldHacks;
using System;
using UnityEngine;
using VRC;
using VRC.SDKBase;

namespace neeko.PlayerHacks
{
    internal class PlayerESP
    {
        public static bool PlayerESPEnabled { get; internal set; }
        /*
        internal static void esprefresh(Player player)
        {
            if (!PlayerESP.PlayerESPEnabled || player == null)
            {
                return;
            }
            if (!player.gameObject.transform.Find("SelectRegion"))
            {
                return;
            }
            Renderer component = player.gameObject.transform.Find("SelectRegion").GetComponent<Renderer>();
            HighlightsFX.field_Private_Static_HighlightsFX_0.field_Protected_Material_0.color = Color.red;
            HighlightsFX.field_Private_Static_HighlightsFX_0.gameObject.AddComponent<HighlightsFXStandalone>();
            HighlightsFX.field_Private_Static_HighlightsFX_0.Method_Protected_Boolean_Boolean_Boolean_PDM_0(component, true);
        }*/
        internal static void esprefresh(Player player)
        {
            if (!PlayerESP.PlayerESPEnabled || player == null)
            {
                return;
            }
            if (!player.gameObject.transform.Find("SelectRegion"))
            {
                return;
            }
            Transform transform = player.transform.Find("SelectRegion");
            HighlightsFXStandalone highlightsFXStandalone = HighlightsFX.field_Private_Static_HighlightsFX_0.gameObject.AddComponent<HighlightsFXStandalone>();
            Color highlightColor = new Color(255f, 255f, 253f);
        }
        internal static void espmethod()
        {
            foreach (Player player in PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0.ToArray())
            {
                if (player.transform.Find("SelectRegion"))
                {
                    Transform transform = player.transform.Find("SelectRegion");
                    HighlightsFXStandalone highlightsFXStandalone = HighlightsFX.field_Private_Static_HighlightsFX_0.gameObject.AddComponent<HighlightsFXStandalone>();
                    Color highlightColor = new Color(255f, 255f, 253f);
                }
            }
        }
    }
}

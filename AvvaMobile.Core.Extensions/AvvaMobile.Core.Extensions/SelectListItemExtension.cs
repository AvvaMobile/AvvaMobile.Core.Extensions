using Microsoft.AspNetCore.Mvc.Rendering;

namespace AvvaMobile.Core.Extensions;

public static class SelectListItemExtension
{
    public static List<SelectListItem> AddALLOption(this List<SelectListItem> list, string text)
    {
        list.Insert(0, new SelectListItem { Text = text, Value = "0" });
        return list;
    }
    public static List<SelectListItem> AddALLOption(this List<SelectListItem> list)
    {
        list.Insert(0, new SelectListItem { Text = "-- Tümü --", Value = "0" });
        return list;
    }

    public static List<SelectListItem> AddSELECTOption(this List<SelectListItem> list, string text)
    {
        list.Insert(0, new SelectListItem { Text = text, Value = "-1" });
        return list;
    }
    public static List<SelectListItem> AddSELECTOption(this List<SelectListItem> list)
    {
        list.Insert(0, new SelectListItem { Text = "-- Seçiniz --", Value = "-1" });
        return list;
    }
}
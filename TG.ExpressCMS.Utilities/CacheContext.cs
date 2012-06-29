using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TG.ExpressCMS.DataLayer.Entities;
using TG.ExpressCMS.DataLayer.Data;
using System.Web.Caching;
using System.Globalization;

namespace TG.ExpressCMS.Utilities
{
    public static class CacheContext
    {
        public static Settings _DefaultSettings
        {
            get
            {
                Settings _settings = null;
                _settings = new Settings();
               // if (HttpContext.Current.Session["_DefaultSettings"] == null)
                {
                    _settings = SettingsManager.GetDefault();
                    if (null == _settings)
                    {
                        _settings = new Settings();
                        _settings.Name = "";
                        _settings.DefaultLanguageCode = "en";
                        return _settings;
                    }
                   // HttpContext.Current.Session["_DefaultSettings"] = _settings;
                }
                //else
                {
               //     _settings = (Settings)(HttpContext.Current.Session["_DefaultSettings"]);
                }
                return _settings;
            }
        }

        public static void ClearCache()
        {
            HttpContext.Current.Session["_DefaultSettings"] = null;
        }
        public static CultureInfo PortalCulture
        {
            get
            {
                CultureInfo _cul = new CultureInfo(_DefaultSettings.DefaultLanguageCode);
                return _cul;
            }
        }
    }
}
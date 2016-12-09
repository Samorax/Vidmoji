using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class DeviceSettingsViewModel
    {
        [Display(Name = "Download Vidmojis to device only when connected to Wi-Fi")]
        public bool WifiOnlyDownload { get; set; }

        [Display(Name = "Upload Vidmojis only when connected to Wi-Fi")]
        public bool UploadWifiOnly { get; set; }

        [Display(Name = "Suggest Vidmojis only when connected to Wi-Fi")]
        public bool SuggestWifiOnly { get; set; }
    }
}
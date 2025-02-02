﻿using DGP.Genshin.Data.Helpers;
using Newtonsoft.Json;

namespace DGP.Genshin.Models.MiHoYo.Record.Avatar
{
    internal class Avatar
    {
        [JsonProperty("id")] public int Id { get; set; }
        [JsonProperty("image")] public string Image { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("element")] public string Element { get; set; }
        public string ElementUrl => ElementHelper.FromENGName(this.Element);
        [JsonProperty("fetter")] public int Fetter { get; set; }
        [JsonProperty("level")] public int Level { get; set; }
        [JsonProperty("rarity")] public int Rarity { get; set; }
        [JsonProperty("actived_constellation_num")] public int ActivedConstellationNum { get; set; }
    }
}

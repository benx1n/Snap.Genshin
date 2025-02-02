﻿using Newtonsoft.Json;

namespace DGP.Genshin.Models.MiHoYo.Gacha
{
    public class ConfigType
    {
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("key")] public string Key { get; set; }
        [JsonProperty("name")] public string Name { get; set; }

        public const string PermanentWish = "200";
        public const string NoviceWishes = "100";
        public const string CharacterEventWish = "301";
        public const string WeaponEventWish = "302";
    }
}

﻿using System.Text.Json.Serialization;

namespace LojaDoManoel.Models
{
    public class DimensoesDto
    {
        [JsonPropertyName("altura")]
        public int Altura { get; set; }

        [JsonPropertyName("largura")]
        public int Largura { get; set; }

        [JsonPropertyName("comprimento")]
        public int Comprimento { get; set; }
    }
}

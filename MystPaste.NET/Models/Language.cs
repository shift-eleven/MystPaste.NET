﻿using System.Collections.Generic;
using System.Drawing;
using MystPaste.NET.Extensions;
using Newtonsoft.Json;

namespace MystPaste.NET.Models
{
    /// <summary>
    /// Represents a model to map the response for.
    /// the language data endpoints
    /// </summary>
    public class Language
    {
        /// <summary>
        /// An optional list of strings with the extensions used by the language.
        /// </summary>
        [JsonProperty("ext")]
        public List<string> Extensions { get; set; }
        
        /// <summary>
        /// An optional list of strings with the aliases of the language.
        /// </summary>
        [JsonProperty("alias")]
        public List<string> Aliases { get; set; }
        
        /// <summary>
        /// The name of the language.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The color used to represent the language. 
        /// </summary>
        [JsonProperty("color")]
        public string HexColor { get; set; }

        /// <summary>
        /// The language mode to be used in the editor.
        /// </summary>
        [JsonProperty("mode")]
        public string Mode { get; set; }

        /// <summary>
        /// A list of mimes used by the language.
        /// </summary>
        [JsonProperty("mimes")]
        public List<string> Mimes { get; set; }

        /// <summary>
        /// A <see cref="System.Drawing.Color"/> formed from HexColor.
        /// </summary>
        [JsonIgnore]
        public Color Color => HexColor.ParseColor();
    }
}
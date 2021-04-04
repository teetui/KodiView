﻿/********************************************************************************************************************************************
 * Copyright (C) 2016 Pieter-Uys Fourie
 * This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as 
 * published by the Free Software Foundation, either version 3 of the License, or any later version.
 *
 * This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty 
 * of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License along with this program. If not, see 
 * http://www.gnu.org/licenses/.
 */

using Newtonsoft.Json;

namespace KodiRPC.Responses.Types.Video.Details
{
    public class Item : Media
    {
        [JsonProperty(PropertyName = "dateadded")]
        public string DateAdded { get; set; } = "";

        [JsonProperty(PropertyName = "file")]
        public string File { get; set; } = "";

        [JsonProperty(PropertyName = "lastplayed")]
        public string LastPlayed { get; set; } = "";

        [JsonProperty(PropertyName = "plot")]
        public string Plot { get; set; } = "";
    }
}

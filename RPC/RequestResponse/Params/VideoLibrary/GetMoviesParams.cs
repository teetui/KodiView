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

namespace KodiRPC.RPC.RequestResponse.Params.VideoLibrary
{
    public class GetMoviesParams : KodiProperties
    {
        [JsonProperty("filter", NullValueHandling = NullValueHandling.Ignore)]
        public Filter Filter { get; set; }

        [JsonProperty("limits", NullValueHandling = NullValueHandling.Ignore)]
        public Limits Limits { get; set; }

        [JsonProperty("sort", NullValueHandling = NullValueHandling.Ignore)]
        public Sort Sort { get; set; }
    }
}
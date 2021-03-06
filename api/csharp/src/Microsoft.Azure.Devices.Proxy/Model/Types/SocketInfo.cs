﻿// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

// Keep in sync with native layer, in particular order of members!

namespace Microsoft.Azure.Devices.Proxy {
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Text;

    /// <summary>
    /// Describes the properties of the socket, e.g. what and how it is opened
    /// </summary>
    [DataContract]
    public class SocketInfo : Serializable<SocketInfo> {

        /// <summary>
        /// Address family
        /// </summary>
        [DataMember(Name = "family", Order = 1)]
        public AddressFamily Family { get; set; } = AddressFamily.InterNetworkV6;

        /// <summary>
        /// Type of socket
        /// </summary>
        [DataMember(Name = "sock_type", Order = 2)]
        public SocketType Type { get; set; } = SocketType.Stream;

        /// <summary>
        /// Protocol
        /// </summary>
        [DataMember(Name = "proto_type", Order = 3)]
        public ProtocolType Protocol { get; set; } = ProtocolType.Tcp;

        /// <summary>
        /// Socket flags
        /// </summary>
        [DataMember(Name = "flags", Order = 4)]
        public uint Flags { get; set; }

        /// <summary>
        /// Socket timeout
        /// </summary>
        [DataMember(Name = "timeout", Order = 5)]
        public uint Timeout { get; set; }

        /// <summary>
        /// Address to use to open, if proxy address, will be resolved.
        /// </summary>
        [DataMember(Name = "address", Order = 6)]
        public SocketAddress Address { get; set; }

        /// <summary>
        /// Socket options that apply to the socket
        /// </summary>
        [DataMember(Name = "options", Order = 7)]
        public HashSet<PropertyBase> Options { get; set; } = new HashSet<PropertyBase>();

        /// <summary>
        /// Comparison
        /// </summary>
        /// <param name="that"></param>
        /// <returns></returns>
        public override bool IsEqual(SocketInfo that) {
            if (that == null) {
                return false;
            }
            return
                IsEqual(Family, that.Family) &&
                IsEqual(Type, that.Type) &&
                IsEqual(Protocol, that.Protocol) &&
                IsEqual(Flags, that.Flags) &&
                IsEqual(Address, that.Address) &&
                Options.SetEquals(that.Options);
        }

        /// <summary>
        /// Comparison
        /// </summary>
        /// <param name="that"></param>
        /// <returns></returns>
        protected override void SetHashCode() {
            MixToHash(Family);
            MixToHash(Type);
            MixToHash(Protocol);
            MixToHash(Flags);
            MixToHash(Address);
            MixToHash(Options);
        }

        /// <summary>
        /// As string
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            var str = new StringBuilder();
            str.Append("Type:     "); str.AppendLine(Type.ToString());
            str.Append("Protocol: "); str.AppendLine(Protocol.ToString());
            str.Append("Family:   "); str.AppendLine(Family.ToString());
            str.Append("Address:  "); str.AppendLine(Address.ToString());
            str.Append("Flags:    "); str.AppendLine(Flags.ToString());
            return str.ToString();
        }
    }
}
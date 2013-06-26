/*
* Copyright 2005-2012 ONIX SOLUTIONS LIMITED. All rights reserved. 
* 
* This software owned by ONIX SOLUTIONS LIMITED [ONIXS] and is protected by copyright law 
* and international copyright treaties. 
* 
* Access to and use of the software is governed by the terms of the applicable ONIXS Software
* Services Agreement (the Agreement) and Customer end user license agreements granting 
* a non-assignable, non-transferable and non-exclusive license to use the software 
* for it's own data processing purposes under the terms defined in the Agreement.
* 
* Except as otherwise granted within the terms of the Agreement, copying or reproduction of any part 
* of this source code or associated reference material to any other location for further reproduction
* or redistribution, and any amendments to this copyright notice, are expressly prohibited. 
*
* Any reproduction or redistribution for sale or hiring of the Software not in accordance with 
* the terms of the Agreement is a violation of copyright law. 
*/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;

namespace CmeFastHandlerSample
{
    internal struct ChannelConfiguration
    {
        public string Id;

        public String Lavel;
    }

    internal class CmeChannelConfigurationReader
    {
        public static List<ChannelConfiguration> ReadConfiguration(string channelConfigurationFile, out string environment, out DateTime updateTime)
        {
            var doc = new XmlDocument();
            doc.Load(channelConfigurationFile);

            if ("configuration" != doc.DocumentElement.Name)
            {
                throw new ApplicationException("Invalid name of the root Xml node in '" + channelConfigurationFile +
                                               "' file: expected 'configuration', but found '" + doc.DocumentElement.Name + "'.");
            }

            environment = doc.DocumentElement.Attributes["environment"].Value.Trim();

            updateTime = DateTime.ParseExact(doc.DocumentElement.Attributes["updated"].Value.Trim(), "yyyy/MM/dd-HH:mm:ss",
                                             CultureInfo.InvariantCulture);

            var result = new List<ChannelConfiguration>();
            var channels = doc.SelectNodes("/configuration/channel");
            foreach (XmlNode node in channels)
            {
                var configuration = new ChannelConfiguration();
                configuration.Id = node.Attributes["id"].Value;

                var labelAttribute = node.Attributes["label"];
                if (null == labelAttribute)
                {
                    continue;
                }
                else
                {
                    configuration.Lavel = labelAttribute.Value.Trim();
                }

                result.Add(configuration);
            }

            var comparer = new ChannelConfigurationComparer();
            result.Sort(comparer);

            return result;
        }
    }

    internal class ChannelConfigurationComparer : IComparer<ChannelConfiguration>
    {
        public int Compare(ChannelConfiguration left, ChannelConfiguration right)
        {
            return left.Id.CompareTo(right.Id);
        }
    }
}
﻿using GroupDocs.Metadata.Cloud.Sdk.Api;
using GroupDocs.Metadata.Cloud.Sdk.Client;
using GroupDocs.Metadata.Cloud.Sdk.Model;
using GroupDocs.Metadata.Cloud.Sdk.Model.Requests;
using System;
using System.Collections.Generic;

namespace GroupDocs.Metadata.Cloud.Examples.CSharp.MetadataOperations.AddMetadata
{
    /// <summary>
    /// This example demonstrates how to add metadata by property name.
    /// </summary>
    public class AddMetadataByPropertyName
    {
        public static void Run()
        {
            Console.WriteLine("Running AddMetadataByPropertyName");
            var configuration = new Configuration(Common.MyAppSid, Common.MyAppKey);
            var apiInstance = new MetadataApi(configuration);

            try
            {
                var fileInfo = new FileInfo
                {
                    FilePath = "documents/input.doc",
                    StorageName = Common.MyStorage
                };

                var now = DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss");
                var options = new AddOptions
                {
                    FileInfo = fileInfo,
                    Properties = new List<AddProperty>
                    {
                        new AddProperty
                        {
                            Value = now,
                            Type = "DateTime",
                            SearchCriteria = new SearchCriteria
                            {
                                NameOptions = new NameOptions
                                {
                                    Value = "print"
                                }
                            },
                        }
                    }
                };

                var request = new AddRequest(options);

                var response = apiInstance.Add(request);
                Console.WriteLine($"Count of changes: {response.AddedCount}");
                Console.WriteLine("Resultant file path: " + response.Path);
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception while calling MetadataApi: " + e.Message + "\n");
            }
        }
    }
}
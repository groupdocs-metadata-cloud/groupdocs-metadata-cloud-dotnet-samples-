﻿using GroupDocs.Metadata.Cloud.Sdk.Api;
using GroupDocs.Metadata.Cloud.Sdk.Client;
using GroupDocs.Metadata.Cloud.Sdk.Model;
using GroupDocs.Metadata.Cloud.Sdk.Model.Requests;
using System;

namespace GroupDocs.Metadata.Cloud.Examples.CSharp.MetadataOperations.ExtractMetadata
{
    /// <summary>
    /// This example demonstrates how to extract metadata by match property name regex.
    /// </summary>
    public class ExtractMetadataByPropertyNameMatchRegex
    {
        public static void Run()
        {
            Console.WriteLine("Running ExtractMetadataByPropertyNameMatchRegex");
            var configuration = new Configuration(Common.MyAppSid, Common.MyAppKey);
            var apiInstance = new MetadataApi(configuration);

            try
            {
                var fileInfo = new FileInfo
                {
                    FilePath = "documents/input.docx",
                    StorageName = Common.MyStorage
                };

                var options = new ExtractOptions
                {
                    FileInfo = fileInfo,
                    SearchCriteria = new SearchCriteria
                    {
                        NameOptions = new NameOptions
                        {
                            Value = "^dc:.*",
                            MatchOptions = new MatchOptions
                            {
                                IsRegex = true
                            }
                        }
                    }
                };

                var request = new ExtractRequest(options);

                var response = apiInstance.Extract(request);
                foreach (var property in response.Properties)
                {
                    Console.WriteLine($"Property: {property.Name}. Value: {property.Value}");
                    if (property.Tags == null) continue;

                    foreach (var tag in property.Tags)
                    {
                        Console.WriteLine($"Property tag: {tag.Category} {tag.Name} ");
                    }
                }
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception while calling MetadataApi: " + e.Message + "\n");
            }
        }
    }
}
﻿using GroupDocs.Metadata.Cloud.Sdk.Api;
using GroupDocs.Metadata.Cloud.Sdk.Client;
using GroupDocs.Metadata.Cloud.Sdk.Model;
using GroupDocs.Metadata.Cloud.Sdk.Model.Requests;
using System;

namespace GroupDocs.Metadata.Cloud.Examples.CSharp.MetadataOperations.RemoveMetadata
{
    /// <summary>
    /// This example demonstrates how to remove metadata by match property name exact word (ignorecase).
    /// </summary>
    public class RemoveMetadataByPropertyNameMatchExactPhrase
    {
        public static void Run()
        {
            Console.WriteLine("Running RemoveMetadataByPropertyNameMatchExactPhrase");
            var configuration = new Configuration(Common.MyAppSid, Common.MyAppKey);
            var apiInstance = new MetadataApi(configuration);

            try
            {
                var fileInfo = new FileInfo
                {
                    FilePath = "documents/input.docx",
                    StorageName = Common.MyStorage
                };

                var options = new RemoveOptions
                {
                    FileInfo = fileInfo,
                    SearchCriteria = new SearchCriteria
                    {
                        NameOptions = new NameOptions
                        {
                            Value = "NameOfApplication"
                        }
                    }
                };

                var request = new RemoveRequest(options);

                var response = apiInstance.Remove(request);
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
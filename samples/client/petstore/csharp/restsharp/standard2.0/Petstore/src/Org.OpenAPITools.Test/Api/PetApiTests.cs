/* 
 * OpenAPI Petstore
 *
 * This spec is mainly for testing Petstore server and contains fake endpoints, models. Please do not use this for any other purpose. Special characters: \" \\
 *
 * OpenAPI spec version: 1.0.0
 * 
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using RestSharp;
using Xunit;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Org.OpenAPITools.Client;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Model;

namespace Org.OpenAPITools.Test
{
    /// <summary>
    /// Class for testing PetApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    public class PetApiTests : IDisposable
    {
        private PetApi instance;

        private long petId = 11088;

        /// <summary>
        /// Create a Pet object
        /// </summary>
        private Pet createPet()
        {
            // create pet
            Pet p = new Pet(name: "Csharp test", photoUrls: new List<string> { "http://petstore.com/csharp_test" });
            p.Id = petId;
            //p.Name = "Csharp test";
            p.Status = Pet.StatusEnum.Available;
            // create Category object
            Category category = new Category();
            category.Id = 56;
            category.Name = "sample category name2";
            List<String> photoUrls = new List<String>(new String[] { "sample photoUrls" });
            // create Tag object
            Tag tag = new Tag();
            tag.Id = petId;
            tag.Name = "csharp sample tag name1";
            List<Tag> tags = new List<Tag>(new Tag[] { tag });
            p.Tags = tags;
            p.Category = category;
            p.PhotoUrls = photoUrls;

            return p;
        }

        /// <summary>
        /// Convert string to byte array
        /// </summary>
        private byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public PetApiTests()
        {
            instance = new PetApi();

            // create pet
            Pet p = createPet();

            // add pet before testing
            PetApi petApi = new PetApi("http://petstore.swagger.io/v2/");
            petApi.AddPet(p);
        }

        /// <summary>
        /// Test an instance of PetApi
        /// </summary>
        [Fact]
        public void InstanceTest()
        {
            Assert.IsType<PetApi>(instance);
        }


        /// <summary>
        /// Test AddPet
        /// </summary>
        [Fact]
        public void AddPetTest()
        {
            // create pet
            Pet p = createPet();
            instance.AddPet(p);
        }

        /// <summary>
        /// Test DeletePet
        /// </summary>
        [Fact]
        public void DeletePetTest()
        {
            // no need to test as it'c covered by Cleanup() already
        }

        /// <summary>
        /// Test FindPetsByStatus
        /// </summary>
        [Fact]
        public void FindPetsByStatusTest()
        {
            PetApi petApi = new PetApi();
            List<String> tagsList = new List<String>(new String[] { "available" });

            List<Pet> listPet = petApi.FindPetsByTags(tagsList);
            foreach (Pet pet in listPet) // Loop through List with foreach.
            {
                Assert.IsType<Pet>(pet);
                Assert.Equal("available", pet.Tags[0].Name);
            }
        }

        /// <summary>
        /// Test FindPetsByTags
        /// </summary>
        [Fact]
        public void FindPetsByTagsTest()
        {
            List<string> tags = new List<String>(new String[] { "pet" });
            var response = instance.FindPetsByTags(tags);
            Assert.IsType<List<Pet>>(response);
        }

        /// <summary>
        /// Test GetPetById
        /// </summary>
        [Fact]
        public void GetPetByIdTest()
        {
            // set timeout to 10 seconds
            Configuration c1 = new Configuration();
            c1.Timeout = TimeSpan.FromSeconds(10);
            c1.UserAgent = "TEST_USER_AGENT";

            PetApi petApi = new PetApi(c1);
            Pet response = petApi.GetPetById(petId);
            Assert.IsType<Pet>(response);

            Assert.Equal("Csharp test", response.Name);
            Assert.Equal(Pet.StatusEnum.Available, response.Status);

            Assert.IsType<List<Tag>>(response.Tags);
            Assert.Equal(petId, response.Tags[0].Id);
            Assert.Equal("csharp sample tag name1", response.Tags[0].Name);

            Assert.IsType<List<String>>(response.PhotoUrls);
            Assert.Equal("sample photoUrls", response.PhotoUrls[0]);

            Assert.IsType<Category>(response.Category);
            Assert.Equal(56, response.Category.Id);
            Assert.Equal("sample category name2", response.Category.Name);
        }

        /// <summary>
        /// Test GetPetByIdAsync
        /// </summary>
        [Fact]
        public void TestGetPetByIdAsync()
        {
            PetApi petApi = new PetApi();
            var task = petApi.GetPetByIdAsync(petId);
            Pet response = task.Result;
            Assert.IsType<Pet>(response);

            Assert.Equal("Csharp test", response.Name);
            Assert.Equal(Pet.StatusEnum.Available, response.Status);

            Assert.IsType<List<Tag>>(response.Tags);
            Assert.Equal(petId, response.Tags[0].Id);
            Assert.Equal("csharp sample tag name1", response.Tags[0].Name);

            Assert.IsType<List<String>>(response.PhotoUrls);
            Assert.Equal("sample photoUrls", response.PhotoUrls[0]);

            Assert.IsType<Category>(response.Category);
            Assert.Equal(56, response.Category.Id);
            Assert.Equal("sample category name2", response.Category.Name);
        }

        /* a simple test for binary response. no longer in use.
        [Fact]
        public void TestGetByIdBinaryResponse()
        {
            PetApi petApi = new PetApi(c1);
            Stream response = petApi.GetPetByIdBinaryResponse(petId);
            Assert.IsType<System.IO.MemoryStream>(response);
            StreamReader reader = new StreamReader(response);
            // the following will fail for sure
            //Assert.Equal("something", reader.ReadToEnd());
        }
        */

        /// <summary>
        /// Test GetPetByIdWithHttpInfoAsync
        /// </summary>
        [Fact]
        public void TestGetPetByIdWithHttpInfoAsync()
        {
            PetApi petApi = new PetApi();
            var task = petApi.GetPetByIdWithHttpInfoAsync(petId);

            Assert.Equal(200, (int)task.Result.StatusCode);
            Assert.True(task.Result.Headers.ContainsKey("Content-Type"));
            Assert.Equal("application/json", task.Result.Headers["Content-Type"][0]);

            Pet response = task.Result.Data;
            Assert.IsType<Pet>(response);

            Assert.Equal("Csharp test", response.Name);
            Assert.Equal(Pet.StatusEnum.Available, response.Status);

            Assert.IsType<List<Tag>>(response.Tags);
            Assert.Equal(petId, response.Tags[0].Id);
            Assert.Equal("csharp sample tag name1", response.Tags[0].Name);

            Assert.IsType<List<String>>(response.PhotoUrls);
            Assert.Equal("sample photoUrls", response.PhotoUrls[0]);

            Assert.IsType<Category>(response.Category);
            Assert.Equal(56, response.Category.Id);
            Assert.Equal("sample category name2", response.Category.Name);
        }

        /// <summary>
        /// Test UpdatePet
        /// </summary>
        [Fact]
        public void UpdatePetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            // create pet
            Pet p = createPet();
            instance.UpdatePet(p);

        }

        /// <summary>
        /// Test UpdatePetWithForm
        /// </summary>
        [Fact]
        public void UpdatePetWithFormTest()
        {
            PetApi petApi = new PetApi();
            petApi.UpdatePetWithForm(petId, "new form name", "pending");

            Pet response = petApi.GetPetById(petId);
            Assert.IsType<Pet>(response);
            Assert.IsType<Category>(response.Category);
            Assert.IsType<List<Tag>>(response.Tags);

            Assert.Equal("new form name", response.Name);
            Assert.Equal(Pet.StatusEnum.Pending, response.Status);

            Assert.Equal(petId, response.Tags[0].Id);
            Assert.Equal(56, response.Category.Id);

            // test optional parameter
            petApi.UpdatePetWithForm(petId, "new form name2");
            Pet response2 = petApi.GetPetById(petId);
            Assert.Equal("new form name2", response2.Name);
        }

        /// <summary>
        /// Test UploadFile
        /// </summary>
        [Fact]
        public void UploadFileTest()
        {
            Assembly _assembly = Assembly.GetExecutingAssembly();
            Stream _imageStream = _assembly.GetManifestResourceStream("Org.OpenAPITools.Test.linux-logo.png");
            PetApi petApi = new PetApi();
            // test file upload with form parameters
            petApi.UploadFile(petId, "new form name", _imageStream);

            // test file upload without any form parameters
            // using optional parameter syntax introduced at .net 4.0
            petApi.UploadFile(petId: petId, file: _imageStream);
        }

        /// <summary>
        /// Test UploadFileWithRequiredFile
        /// </summary>
        [Fact]
        public void UploadFileWithRequiredFileTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //long? petId = null;
            //System.IO.Stream requiredFile = null;
            //string additionalMetadata = null;
            //var response = instance.UploadFileWithRequiredFile(petId, requiredFile, additionalMetadata);
            //Assert.IsType<ApiResponse> (response, "response is ApiResponse");
        }

        /// <summary>
        /// Test status code
        /// </summary>
        [Fact]
        public void TestStatusCodeAndHeader()
        {
            PetApi petApi = new PetApi();
            var response = petApi.GetPetByIdWithHttpInfo(petId);
            //Assert.Equal("OK", response.StatusCode);
            Assert.Equal(200, (int)response.StatusCode);
            Assert.True(response.Headers.ContainsKey("Content-Type"));
            Assert.Equal("application/json", response.Headers["Content-Type"][0]);
        }

        /// <summary>
        /// Test default header (should be deprecated)
        /// </summary>
        [Fact]
        public void TestDefaultHeader()
        {
            //PetApi petApi = new PetApi();
            // commented out the warning test below as it's confirmed the warning is working as expected
            // there should be a warning for using AddDefaultHeader (deprecated) below
            //petApi.AddDefaultHeader ("header_key", "header_value");
            // the following should be used instead as suggested in the doc
            //petApi.Configuration.AddDefaultHeader("header_key2", "header_value2");
        }

        [Fact]
        public void TestArrayOfString()
        {
            ArrayTest at = new ArrayTest();
            JsonSerializerSettings _serializerSettings = new JsonSerializerSettings
            {
                // OpenAPI generated types generally hide default constructors.
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy
                    {
                        OverrideSpecifiedNames = false
                    }
                }
            };
            Assert.Equal("{}", JsonConvert.SerializeObject(at, _serializerSettings));

            at.ArrayOfString = new List<string> { "Something here ..." };

            Assert.Equal("{\"array_of_string\":[\"Something here ...\"]}", JsonConvert.SerializeObject(at, _serializerSettings));
        }

        public void Dispose()
        {
            // remove the pet after testing
            PetApi petApi = new PetApi();
            petApi.DeletePet(petId, "test key");
        }
    }
}

﻿using Okra.Sharing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Xunit;

namespace Okra.Tests.Sharing
{
    public class SharePackageFixture
    {
        [Fact]
        public void Constructor_ThrowsException_IfDataPackageIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new SharePackage(null));
        }

        [Fact]
        public async Task SetData_SetsDataOnDataPackage()
        {
            DataPackage dataPackage = new DataPackage();
            SharePackage sharePackage = new SharePackage(dataPackage);

            sharePackage.SetData<string>("Test Format", "Test Value");

            object data = await dataPackage.GetView().GetDataAsync("Test Format");
            Assert.Equal("Test Value", data);
        }

        [Fact]
        public void SetData_ThrowsException_IfFormatIdIsNull()
        {
            DataPackage dataPackage = new DataPackage();
            SharePackage sharePackage = new SharePackage(dataPackage);

            Assert.Throws<ArgumentException>(() => sharePackage.SetData<string>(null, "Test Value"));
        }

        [Fact]
        public void SetData_ThrowsException_IfFormatIdIsEmpty()
        {
            DataPackage dataPackage = new DataPackage();
            SharePackage sharePackage = new SharePackage(dataPackage);

            Assert.Throws<ArgumentException>(() => sharePackage.SetData<string>("", "Test Value"));
        }

        [Fact]
        public async Task SetAsyncData_SetsDataOnDataPackage()
        {
            DataPackage dataPackage = new DataPackage();
            SharePackage sharePackage = new SharePackage(dataPackage);

            sharePackage.SetAsyncData("Test Format", async (state) =>
                {
                    await Task.Delay(200);
                    return "Test Value";
                });

            object data = await dataPackage.GetView().GetDataAsync("Test Format");
            Assert.Equal("Test Value", data);
        }

        [Fact]
        public void SetAsyncData_ThrowsException_IfFormatIdIsNull()
        {
            DataPackage dataPackage = new DataPackage();
            SharePackage sharePackage = new SharePackage(dataPackage);

            Assert.Throws<ArgumentException>(() => sharePackage.SetAsyncData<string>(null, async (state) =>
            {
                await Task.Delay(200);
                return "Test Value";
            }));
        }

        [Fact]
        public void SetAsyncData_ThrowsException_IfFormatIdIsEmpty()
        {
            DataPackage dataPackage = new DataPackage();
            SharePackage sharePackage = new SharePackage(dataPackage);

            Assert.Throws<ArgumentException>(() => sharePackage.SetAsyncData<string>("", async (state) =>
            {
                await Task.Delay(200);
                return "Test Value";
            }));
        }

        [Fact]
        public void SetAsyncData_ThrowsException_IfDataProviderIsNull()
        {
            DataPackage dataPackage = new DataPackage();
            SharePackage sharePackage = new SharePackage(dataPackage);

            Assert.Throws<ArgumentNullException>(() => sharePackage.SetAsyncData<string>("Test Format", null));
        }

        [Fact]
        public void Properties_Description_SetsValueOnDataPackage()
        {
            DataPackage dataPackage = new DataPackage();
            SharePackage sharePackage = new SharePackage(dataPackage);

            sharePackage.Properties.Description = "Test Value";

            Assert.Equal("Test Value", dataPackage.Properties.Description);
        }

        [Fact]
        public void Properties_Description_GetsValueFromDataPackage()
        {
            DataPackage dataPackage = new DataPackage();
            SharePackage sharePackage = new SharePackage(dataPackage);

            dataPackage.Properties.Description = "Test Value";

            Assert.Equal("Test Value", sharePackage.Properties.Description);
        }

        [Fact]
        public void Properties_Title_SetsValueOnDataPackage()
        {
            DataPackage dataPackage = new DataPackage();
            SharePackage sharePackage = new SharePackage(dataPackage);

            sharePackage.Properties.Title = "Test Value";

            Assert.Equal("Test Value", dataPackage.Properties.Title);
        }

        [Fact]
        public void Properties_Title_GetsValueFromDataPackage()
        {
            DataPackage dataPackage = new DataPackage();
            SharePackage sharePackage = new SharePackage(dataPackage);

            dataPackage.Properties.Title = "Test Value";

            Assert.Equal("Test Value", sharePackage.Properties.Title);
        }
    }
}

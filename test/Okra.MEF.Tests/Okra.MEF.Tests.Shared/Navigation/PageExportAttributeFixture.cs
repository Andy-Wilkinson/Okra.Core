﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Okra.Navigation;
using Xunit;

namespace Okra.MEF.Tests.Navigation
{
    public class PageExportAttributeFixture
    {
        // *** Constructor Tests ***

        [Fact]
        public void Constructor_SetsPageName_ByString()
        {
            PageExportAttribute attribute = new PageExportAttribute("Page X");

            Assert.Equal("Page X", attribute.PageName);
        }

        [Fact]
        public void Constructor_SetsPageName_ByType()
        {
            PageExportAttribute attribute = new PageExportAttribute(typeof(PageExportAttributeFixture));

            Assert.Equal("Okra.MEF.Tests.Navigation.PageExportAttributeFixture", attribute.PageName);
        }

        [Fact]
        public void Constructor_ThrowsException_IfPageNameIsNull()
        {
            var e = Assert.Throws<ArgumentException>(() => new PageExportAttribute((string)null));

            Assert.Equal("The argument cannot be null or an empty string.\r\nParameter name: pageName", e.Message);
            Assert.Equal("pageName", e.ParamName);
        }

        [Fact]
        public void Constructor_ThrowsException_IfPageNameIsEmpty()
        {
            var e = Assert.Throws<ArgumentException>(() => new PageExportAttribute(""));

            Assert.Equal("The argument cannot be null or an empty string.\r\nParameter name: pageName", e.Message);
            Assert.Equal("pageName", e.ParamName);
        }

        [Fact]
        public void Constructor_ThrowsException_IfPageTypeIsNull()
        {
            var e = Assert.Throws<ArgumentNullException>(() => new PageExportAttribute((Type)null));

            Assert.Equal("Value cannot be null.\r\nParameter name: type", e.Message);
            Assert.Equal("type", e.ParamName);
        }

        // *** Property Tests ***

        [Fact]
        public void ContractName_IsCorrect()
        {
            PageExportAttribute attribute = new PageExportAttribute("Page X");

            Assert.Equal("OkraPage", attribute.ContractName);
        }

        [Fact]
        public void ContractType_IsObject()
        {
            PageExportAttribute attribute = new PageExportAttribute("Page X");

            Assert.Equal(typeof(object), attribute.ContractType);
        }
    }
}

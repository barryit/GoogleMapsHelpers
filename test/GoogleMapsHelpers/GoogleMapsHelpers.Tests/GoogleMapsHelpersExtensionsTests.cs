﻿using System;
using System.Web;
using System.Web.Mvc;
using GoogleMapsHelpers.Factories;
using GoogleMapsHelpers.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleMapsHelpers.Tests
{
    [TestClass]
    public class GoogleMapsHelpersExtensionsTests
    {
        [TestMethod]
        public void GoogleMapsHelpersExtensions_GoogleMaps_Test()
        {
            var expected = new HtmlString("<div id=\"map-canvas\"></div>").ToString();
            var actual = new HtmlHelper(new ViewContext(), new ViewPage()).GoogleMaps(null).ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GoogleMapsHelpersExtensions_GoogleMaps_htmlAttributeTest()
        {
            var expected = new HtmlString("<div id=\"map-canvas\" style=\"width: 100%;\"></div>").ToString();
            var actual = new HtmlHelper(new ViewContext(), new ViewPage()).GoogleMaps(new { @style = "width: 100%;" }).ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GoogleMapsHelpersExtension_StaticMapsApi_Test()
        {
            var expected = new HtmlString("<script src=\"" + SourceAddressFactory.GetSourceAddress(null, true, Libraries.None) + "\" type=\"text/javascript\"></script>").ToString();
            var actual = new HtmlHelper(new ViewContext(), new ViewPage()).StaticMapsApi(null, true, null).ToString();

            StringAssert.Contains(actual, expected);
        }

        [TestMethod]
        public void GoogleMapsHelpersExtension_StaticMapsApi_ConfigTest()
        {
            var expected = new HtmlString("<script src=\"" + SourceAddressFactory.GetSourceAddress(null, true, Libraries.None) + "\" type=\"text/javascript\"></script>").ToString();
            var actual = new HtmlHelper(new ViewContext(), new ViewPage()).StaticMapsApi(new MapOptions("Baltimore, MD")).ToString();

            StringAssert.Contains(actual, expected);
        }
    }
}

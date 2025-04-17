using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace SoreBiblioteca.Tests
{
    [TestClass]
    public class LibrosUITests
    {
        private IWebDriver driver;
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [TestMethod]
        public void CargarPaginaLibros_DeberiaMostrarBotonCrear()
        {
            // Cambia esta URL a donde corre tu app
            driver.Navigate().GoToUrl("https://localhost:7050/Home/LibrosPage");

            // Buscar el botón "Crear"
            var botonCrear = driver.FindElement(By.LinkText("Crear"));

            // Verificar que existe
            Assert.IsNotNull(botonCrear);

            // Guardar screenshot
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            var fileName = Path.Combine(TestContext.ResultsDirectory, "LibrosPage.png");
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}

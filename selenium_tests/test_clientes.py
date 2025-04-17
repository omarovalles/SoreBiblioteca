import pytest
from selenium import webdriver
from selenium.webdriver.chrome.service import Service
from webdriver_manager.chrome import ChromeDriverManager

def test_agregar_cliente(browser):
    browser.get("https://localhost:7050/Home/PrestamosDisp")
    browser.find_element("css selector", "form[action='/Clientes/Create'] button[type='submit']").click()
    browser.find_element("name", "Nombre").send_keys("Juan")
    browser.find_element("name", "Apellido").send_keys("Perez")
    browser.find_element("name", "Correo").send_keys("juan@example.com")
    browser.find_element("name", "Direccion").send_keys("Calle Falsa 123")
    browser.find_element("name", "Telefono").send_keys("8091234567")
    browser.find_element("name", "Estado").send_keys("N")
    browser.save_screenshot("evidencias/cliente_creado.png")
    browser.find_element("css selector", "form[action='/Clientes/Create'] button[type='submit']").click()

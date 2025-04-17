import pytest
from selenium import webdriver
from selenium.webdriver.chrome.service import Service
from webdriver_manager.chrome import ChromeDriverManager

def test_agregar_libro(browser):
    browser.get("https://localhost:7050/Home/LibrosPage")
    browser.find_element("name", "autor").send_keys("Autor de prueba")
    browser.find_element("name", "titulo").send_keys("Título de prueba")
    browser.find_element("name", "id_proveedor").send_keys("1")
    browser.find_element("name", "stock").send_keys("10")
    browser.save_screenshot("evidencias/libro_creado.png")
    browser.find_element("css selector", "form button[type='submit']").click()
